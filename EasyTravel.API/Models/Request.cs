using System;

namespace EasyTravel.API.Models
{
    public class Request
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
