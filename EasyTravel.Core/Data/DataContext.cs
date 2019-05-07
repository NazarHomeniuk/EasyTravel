using EasyTravel.Core.Models;
using EasyTravel.Core.Models.BlaBlaCar;
using EasyTravel.Core.Models.Identity;
using EasyTravel.Core.Models.Monitoring;
using EasyTravel.Core.Models.Railway;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyTravel.Core.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<GeoName> GeoNames { get; set; }
        public DbSet<BusMonitoring> BusMonitoring { get; set; }
        public DbSet<RailwayMonitoring> RailwayMonitoring { get; set; }
        public DbSet<BlaBlaCarMonitoring> BlaBlaCarMonitoring { get; set; }
        public DbSet<Trip> BlaBlaCarTrips { get; set; }
        public DbSet<Models.Bus.Trip> BusTrips { get; set; }
        public DbSet<Train> RailwayTrips { get; set; }
    }
}
