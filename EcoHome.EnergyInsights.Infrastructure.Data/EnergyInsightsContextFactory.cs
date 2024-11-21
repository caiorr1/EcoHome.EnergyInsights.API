using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EcoHome.EnergyInsights.Infrastructure.Data
{
    public class EnergyInsightsContextFactory : IDesignTimeDbContextFactory<EnergyInsightsContext>
    {
        public EnergyInsightsContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<EnergyInsightsContext>();
            optionsBuilder.UseOracle(connectionString);

            return new EnergyInsightsContext(optionsBuilder.Options);
        }
    }
}
