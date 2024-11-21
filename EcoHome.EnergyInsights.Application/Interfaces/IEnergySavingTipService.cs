using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Application.Services
{
    public interface IEnergySavingTipService
    {
        Task<IEnumerable<EnergySavingTipEntity>> GetAllAsync();
        Task<EnergySavingTipEntity> GetByIdAsync(int id);
        Task AddAsync(EnergySavingTipEntity tip);
        Task UpdateAsync(EnergySavingTipEntity tip);
        Task DeleteAsync(int id);
    }
}
