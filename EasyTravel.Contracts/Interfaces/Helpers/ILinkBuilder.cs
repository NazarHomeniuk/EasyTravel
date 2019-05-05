using EasyTravel.Contracts.Interfaces.Core;

namespace EasyTravel.Contracts.Interfaces.Helpers
{
    public interface ILinkBuilder
    {
        string BuildBlaBlaCarLink(ITrip car);

        string BuildRailwayLink(ITrip train);

        string BuildBusLink(ITrip trip);
    }
}