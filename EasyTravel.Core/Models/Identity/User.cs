using System.Collections.Generic;
using EasyTravel.Core.Models.Monitoring;
using Microsoft.AspNetCore.Identity;

namespace EasyTravel.Core.Models.Identity
{
    public class User : IdentityUser
    {
        public ICollection<RailwayMonitoring> RailwayMonitoring { get; set; }
        public ICollection<BlaBlaCarMonitoring> BlaBlaCarMonitoring { get; set; }
        public ICollection<BusMonitoring> BusMonitoring { get; set; }
    }
}
