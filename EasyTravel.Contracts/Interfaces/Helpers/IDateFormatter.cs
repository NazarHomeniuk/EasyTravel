using System;

namespace EasyTravel.Contracts.Interfaces.Helpers
{
    public interface IDateFormatter
    {
        string BlaBlaCarDate(DateTime date);
        string RailwayDate(DateTime date);
        string RailwayTime(DateTime time);
        string BusDate(DateTime date);
    }
}