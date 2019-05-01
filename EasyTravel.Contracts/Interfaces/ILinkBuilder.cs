namespace EasyTravel.Contracts.Interfaces
{
    public interface ILinkBuilder
    {
        string BuildBlaBlaCarLink(ITrip car);

        string BuildRailwayLink(ITrip train);

        string BuildBusLink(ITrip trip);
    }
}