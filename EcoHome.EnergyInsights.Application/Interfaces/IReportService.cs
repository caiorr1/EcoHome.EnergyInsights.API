using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Application.Services
{
    public interface IReportService
    {
        Task<IEnumerable<ReportEntity>> GetAllAsync();
        Task<ReportEntity> GetByIdAsync(int id);
        Task<IEnumerable<ReportEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(ReportEntity report);
        Task DeleteAsync(int id);
    }
}
