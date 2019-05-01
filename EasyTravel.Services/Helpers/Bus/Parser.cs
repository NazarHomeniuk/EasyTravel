using System;
using System.Collections.Generic;
using System.Linq;
using EasyTravel.Core.Models.Bus;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace EasyTravel.Services.Helpers.Bus
{
    public static class Parser
    {
        public static IEnumerable<Station> ParseAllStations(string html)
        {
            var result = new List<Station>();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var htmlBody = htmlDoc.GetElementbyId("point_from").Descendants("option").ToList();
            htmlBody.RemoveAt(0);
            foreach (var htmlNode in htmlBody)
            {
                result.Add(ParseStation(htmlNode));
            }

            return result;
        }

        private static Station ParseStation(HtmlNode html)
        {
            var name = html.InnerHtml.Replace(" ", "").Replace("\n", "");
            var code = html.Attributes["value"].Value;
            return new Station
            {
                Code = code,
                Location = name
            };
        }

        public static IEnumerable<Station> ParseStations(string json)
        {
            var start = json.IndexOf(@"""codes""", StringComparison.Ordinal);
            json = json.Remove(0, start + 8);
            var end = json.IndexOf(@",""data""", StringComparison.Ordinal);
            json = json.Remove(end, json.Length - end);
            var stations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var result = new List<Station>();
            foreach (var keyValuePair in stations)
            {
                result.Add(new Station
                {
                    Code = keyValuePair.Key,
                    Location = keyValuePair.Value
                });
            }

            return result;
        }

        public static IEnumerable<Trip> ParseTrips(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var htmlBody = htmlDoc.DocumentNode.Descendants()
                .Where(d => d.HasClass("trip"));
            return htmlBody.Select(htmlNode => ParseTrip(htmlNode.InnerHtml)).ToList();
        }

        private static Trip ParseTrip(string html)
        {
            var result = new Trip();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var descendants = htmlDoc.DocumentNode.Descendants("small").ToArray();
            result.From = descendants[0].InnerHtml.Replace("\n", "").Replace(" ", "");
            result.To = descendants[2].InnerHtml.Replace("\n", "").Replace(" ", "");
            result.BusName = descendants[4].InnerHtml.Replace("\n", "").Replace(" ", "");
            descendants = htmlDoc.DocumentNode.Descendants("b").ToArray();
            TimeSpan.TryParse(descendants[0].InnerHtml, out var departureTime);
            result.DepartureTime = departureTime;
            descendants = htmlDoc.DocumentNode.Descendants("td").Where(d => d.HasAttributes).ToArray();
            DateTime.TryParse(descendants[0].InnerHtml, out var departureDate);
            result.Date = departureDate;
            var temp = descendants[2].InnerText.Replace("\n", "").Replace(" ", "");
            var arrivalTime = temp.Remove(5, temp.Length - 5);
            TimeSpan.TryParse(arrivalTime, out var arrivalTimeResult);
            result.ArrivalTime = arrivalTimeResult;
            var price = descendants[3].InnerText.Replace(".", ",");
            double.TryParse(price, out var priceResult);
            result.Price = priceResult;
            var distance = descendants[4].InnerText;
            int.TryParse(distance, out var distanceResult);
            result.Distance = distanceResult;
            result.DepartureDate = result.Date.Add(result.DepartureTime);
            result.ArrivalDate = result.Date.Add(result.ArrivalTime);
            return result;
        }
    }
}
