using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Infrastructure.Data;
using EcoHome.EnergyInsights.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace EcoHome.EnergyInsights.Tests
{ 

        public class InsightRepositoryTests
        {
        private readonly DbContextOptions<EnergyInsightsContext> _options;

        public InsightRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<EnergyInsightsContext>()
                .UseInMemoryDatabase(databaseName: "EnergyInsightsDb")
                .Options;
        }

        [Fact]
        public async Task AddAsync_ShouldAddInsightToDatabase()
        {
            using var context = new EnergyInsightsContext(_options);
            var repository = new InsightRepository(context);

            var insight = new InsightEntity { Title = "New Insight", Description = "Description", ExternalUserId = "User1" };

            await repository.AddAsync(insight);

            var storedInsight = await context.Insights.FirstOrDefaultAsync();
            Assert.NotNull(storedInsight);
            Assert.Equal("New Insight", storedInsight.Title);
        }
    }
}
