using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using BingMapsRESTToolkit;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using Microsoft.Extensions.Options;

namespace EasyTravel.Services.BingMaps
{
    public class MapsService : IMapsService
    {
        private readonly DataContext dataContext;
        private readonly BingMapsConfig config;

        public MapsService(DataContext dataContext, IOptions<BingMapsConfig> options)
        {
            this.dataContext = dataContext;
            config = options.Value;
        }

        public async Task<IEnumerable<string>> FindLocationsBetweenAsync(string @from, string to)
        {
            var names = dataContext.GeoNames.ToList();
            Route route = null;
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                var url = config.ApiUrl.Replace("{from}", from).Replace("{to}", to).Replace("{key}", config.ApiKey);
                var response = await client.DownloadStringTaskAsync(url);

                var ser = new DataContractJsonSerializer(typeof(Response));
                using (var es = new MemoryStream(Encoding.UTF8.GetBytes(response)))
                {
                    if (ser.ReadObject(es) is Response mapResponse) route = (Route) mapResponse.ResourceSets.First().Resources.First();
                }
            }

            var result = new List<string> {from};
            if (route != null)
            {
                var points = route.RouteLegs[0].ItineraryItems;
                foreach (var itineraryItem in points)
                {
                    var x = itineraryItem.ManeuverPoint.Coordinates[0];
                    var y = itineraryItem.ManeuverPoint.Coordinates[1];
                    var name = names.Find(n => n.Longitude != null && (n.Latitude != null && (Math.Abs(n.Latitude.Value - x) <= 0.1 && Math.Abs(n.Longitude.Value - y) <= 0.1)));
                    var res = name?.AlternateNames;
                    if (!result.Contains(res)) result.Add(res);
                }
            }

            result.Add(to);
            return result.Distinct();
        }
    }
}
