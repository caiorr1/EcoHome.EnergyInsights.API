using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EcoHome.EnergyInsights.Infrastructure.Data;
using EcoHome.EnergyInsights.Domain.Interfaces;
using EcoHome.EnergyInsights.Infrastructure.Data.Repositories;

namespace EcoHome.EnergyInsights.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EnergyInsightsContext>(options =>
                options.UseOracle(connectionString));

            services.AddScoped<IInsightRepository, InsightRepository>();
            services.AddScoped<IUserConsumptionGoalRepository, UserConsumptionGoalRepository>();
            services.AddScoped<INotificationLogRepository, NotificationLogRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IEnergySavingTipRepository, EnergySavingTipRepository>();

            return services;
        }
    }
}
