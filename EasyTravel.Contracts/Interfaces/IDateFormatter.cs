using System;

namespace EasyTravel.Contracts.Interfaces
{
    public interface IDateFormatter
    {
        string BlaBlaCarDate(DateTime date, TimeSpan time);
        string RailwayDate(DateTime date);
        string RailwayTime(TimeSpan time);
        string BusDate(DateTime date);
    }
}