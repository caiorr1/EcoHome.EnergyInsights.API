using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Application.Services
{
    public interface IInsightService
    {
        Task<IEnumerable<InsightEntity>> GetAllAsync();
        Task<InsightEntity> GetByIdAsync(int id);
        Task<IEnumerable<InsightEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(InsightEntity insight);
        Task UpdateAsync(InsightEntity insight);
        Task DeleteAsync(int id);
    }
}
