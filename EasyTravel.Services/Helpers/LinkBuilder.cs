using System.Text;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Core.Config;
using EasyTravel.Core.Models.Railway;
using Microsoft.Extensions.Options;
using Trip = EasyTravel.Core.Models.Bus.Trip;

namespace EasyTravel.Services.Helpers
{
    public class LinkBuilder : ILinkBuilder
    {
        private readonly BusConfig busConfig;
        private readonly RailwayConfig railwayConfig;
        private readonly IDateFormatter dateFormatter;

        public LinkBuilder(IDateFormatter dateFormatter,
            IOptions<BusConfig> busOptions, IOptions<RailwayConfig> railwayOptions)
        {
            busConfig = busOptions.Value;
            railwayConfig = railwayOptions.Value;
            this.dateFormatter = dateFormatter;
        }

        public string BuildBlaBlaCarLink(ITrip trip)
        {
            return ((Core.Models.BlaBlaCar.Trip)trip).Links.Front;
        }

        public string BuildRailwayLink(ITrip trip)
        {
            var stringBuilder = new StringBuilder(railwayConfig.BookingUrl);
            var train = (Train)trip;
            stringBuilder.Replace("{from_code}", train.From.Code)
                .Replace("{to_code}", train.To.Code)
                .Replace("{date}", dateFormatter.RailwayDate(train.DepartureDate))
                .Replace("{time}", dateFormatter.RailwayTime(train.DepartureDate))
                .Replace("{train_number}", train.Num)
                .Replace("{type}", "П");
            return stringBuilder.ToString();
        }

        public string BuildBusLink(ITrip trip)
        {
            var stringBuilder = new StringBuilder(busConfig.BookingUrl);
            var bus = (Trip)trip;
            stringBuilder.Replace("{email}", "gomenyuknazar@gmail.com")
                .Replace("{from_code}", bus.FromCode)
                .Replace("{to_code}", bus.ToCode)
                .Replace("{local_from_code}", bus.LocalPointFrom)
                .Replace("{local_to_code}", bus.LocalPointTo)
                .Replace("{date}", dateFormatter.BusDate(bus.DepartureDate))
                .Replace("{round_num}", bus.RoundNum)
                .Replace("{bus_code}", bus.BusCode);
            return stringBuilder.ToString();
        }
    }
}
