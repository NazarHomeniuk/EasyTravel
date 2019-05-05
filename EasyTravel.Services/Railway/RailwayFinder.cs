using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Core.Config;
using EasyTravel.Core.Models.Railway;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EasyTravel.Services.Railway
{
    public class RailwayFinder : ITripFinder
    {
        private readonly IHttpService httpService;
        private readonly IDateFormatter dateFormatter;
        private readonly RailwayConfig config;
        private readonly IMapsService mapsService;
        private readonly ILinkBuilder linkBuilder;

        public RailwayFinder(IHttpService httpService, IDateFormatter dateFormatter, IOptions<RailwayConfig> options,
            IMapsService mapsService, ILinkBuilder linkBuilder)
        {
            this.httpService = httpService;
            this.dateFormatter = dateFormatter;
            this.mapsService = mapsService;
            this.linkBuilder = linkBuilder;
            config = options.Value;
        }

        public async Task<IEnumerable<ITrip>> FindTripsAsync(string from, string to, DateTime departureDate)
        {
            var fromStation = await GetStationsInfo(from);
            var toStation = await GetStationsInfo(to);
            if (!fromStation.Any() || !toStation.Any())
            {
                return new List<ITrip>();
            }

            var data = $"from={fromStation.First().Value}";
            data += $"&to={toStation.First().Value}";
            data += $"&date={dateFormatter.RailwayDate(departureDate)}";
            data += $"&time={dateFormatter.RailwayTime(departureDate)}";
            var response = await httpService.MakePostRequestAsync(config.ApiUrl, data);
            var responseString = await new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()).ReadToEndAsync();
            var result = JsonConvert.DeserializeObject<TrainsInfo>(responseString);
            result.Data.List.RemoveAll(i => i.Types.Length == 0);
            foreach (var train in result.Data.List)
            {
                train.DepartureDate = DateTime.Parse(train.From.Date.Split(',')[1]);
                train.DepartureDate += train.From.Time;
                train.ArrivalDate = DateTime.Parse(train.To.Date.Split(',')[1]);
                train.ArrivalDate += train.To.Time;
                train.BookingLink = linkBuilder.BuildRailwayLink(train);
            }

            return result.Data.List;
        }

        public async Task<IEnumerable<ITrip>> FindAllTripsAsync(string @from, string to, DateTime departureDate)
        {
            var trains = new List<ITrip>();
            var locations = (await mapsService.FindLocationsBetweenAsync(from, to)).ToList();
            for (var i = locations.Count - 1; i >= 1; --i)
            {
                var result = await FindTripsAsync(from, locations[i], departureDate);
                trains.AddRange(result);
            }

            return trains;
        }

        public async Task<List<StationInfo>> GetStationsInfo(string name)
        {
            var term = HttpUtility.UrlEncode(name);
            var url = config.StationInfoUrl.Replace("{term}", term);
            var response = await httpService.MakeGetRequestAsync(url, null);
            var responseString = await new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<List<StationInfo>>(responseString);
            return data;
        }
    }
}
