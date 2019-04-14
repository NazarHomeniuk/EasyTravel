using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Core.Config;
using EasyTravel.Core.Models.BlaBlaCar;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EasyTravel.Services.BlaBlaCar
{
    public class BlaBlaCarFinder : ITripFinder
    {
        private readonly IHttpService httpService;
        private readonly IDateFormatter dateFormatter;
        private readonly BlaBlaCarConfig config;

        public BlaBlaCarFinder(IHttpService httpService, IDateFormatter dateFormatter, IOptions<BlaBlaCarConfig> options)
        {
            this.httpService = httpService;
            this.dateFormatter = dateFormatter;
            config = options.Value;
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
            const string format = "dd/MM/yyyy HH:mm:ss";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var data = JsonConvert.DeserializeObject<Trips>(responseString, dateTimeConverter);
            return data.AvailableTrips;
        }
    }
}
