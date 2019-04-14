using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Core.Config;
using EasyTravel.Core.Models.BlaBlaCar;
using Newtonsoft.Json;

namespace EasyTravel.Services.BlaBlaCar
{
    public class BlaBlaCarFinder : ITripFinder
    {
        private readonly IHttpService httpService;
        private readonly IDateFormatter dateFormatter;
        private readonly BlaBlaCarConfig config;

        public BlaBlaCarFinder(IHttpService httpService, IDateFormatter dateFormatter, BlaBlaCarConfig config)
        {
            this.httpService = httpService;
            this.dateFormatter = dateFormatter;
            this.config = config;
        }

        public async Task<IEnumerable<ITrip>> FindTripsAsync(string from, string to, DateTime departureDate, TimeSpan departureTime)
        {
            var date = dateFormatter.BlaBlaCarDate(departureDate, departureTime);
            var url = config.ApiUrl.Replace("{from}", from).Replace("{to}", to).Replace("{date}", date);
            var headers = new WebHeaderCollection
            {
                {"Key", config.ApiKey}
            };
            var response = await httpService.MakeGetRequestAsync(url, headers);
            var responseString = await new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Trips>(responseString);
            return data.AvailableTrips;
        }
    }
}
