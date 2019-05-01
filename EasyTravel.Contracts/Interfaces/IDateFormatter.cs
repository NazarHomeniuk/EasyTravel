using System;

namespace EasyTravel.Contracts.Interfaces
{
    public interface IDateFormatter
    {
        string BlaBlaCarDate(DateTime date);
        string RailwayDate(DateTime date);
        string RailwayTime(DateTime time);
        string BusDate(DateTime date);
    }
}