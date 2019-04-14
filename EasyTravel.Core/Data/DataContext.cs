using EasyTravel.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTravel.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<GeoName> GeoNames { get; set; }
    }
}
