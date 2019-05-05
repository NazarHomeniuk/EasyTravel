using System;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Contracts.Interfaces.Helpers;

namespace EasyTravel.Services.Helpers
{
    public class DateFormatter : IDateFormatter
    {
        public string BlaBlaCarDate(DateTime date)
        {
            var timeString = date.ToString("HH':'mm':'ss");
            var dateString = date.ToString("yyyy-MM-dd");
            return $"{dateString} {timeString}";
        }

        public string RailwayDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public string RailwayTime(DateTime date)
        {
            return date.ToString("HH':'mm");
        }

        public string BusDate(DateTime date)
        {
            return date.ToString("dd.MM.yy");
        }
    }
}
