using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EcoHome.EnergyInsights.Infrastructure.Data;
using EcoHome.EnergyInsights.Domain.Interfaces;
using EcoHome.EnergyInsights.Infrastructure.Repositories;
using EcoHome.EnergyInsights.Application.Services;

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

            services.AddScoped<IInsightService, InsightService>();
            services.AddScoped<IUserConsumptionGoalService, UserConsumptionGoalService>();
            services.AddScoped<INotificationLogService, NotificationLogService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IEnergySavingTipService, EnergySavingTipService>();

            return services;
        }
    }
}
