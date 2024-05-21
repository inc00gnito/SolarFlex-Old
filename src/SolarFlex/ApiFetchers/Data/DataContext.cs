using ApiFetchers.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFetchers.Data
{
    public  class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base (opt){
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<SolarPower> SolarForecast { get; set; }
        //public DbSet<Wind> WindForecast { get; set;}


    }
}
