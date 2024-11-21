using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Application.Services
{
    public interface IUserConsumptionGoalService
    {
        Task<IEnumerable<UserConsumptionGoalEntity>> GetAllAsync();
        Task<UserConsumptionGoalEntity> GetByIdAsync(int id);
        Task<IEnumerable<UserConsumptionGoalEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(UserConsumptionGoalEntity goal);
        Task UpdateAsync(UserConsumptionGoalEntity goal);
        Task DeleteAsync(int id);
    }
}
