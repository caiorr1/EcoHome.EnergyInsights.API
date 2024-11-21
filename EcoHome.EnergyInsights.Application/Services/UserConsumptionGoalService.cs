using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Application.Services
{
    public class UserConsumptionGoalService : IUserConsumptionGoalService
    {
        private readonly IUserConsumptionGoalRepository _repository;

        public UserConsumptionGoalService(IUserConsumptionGoalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserConsumptionGoalEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserConsumptionGoalEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserConsumptionGoalEntity>> GetByUserAsync(string externalUserId)
        {
            return await _repository.GetByUserAsync(externalUserId);
        }

        public async Task AddAsync(UserConsumptionGoalEntity goal)
        {
            await _repository.AddAsync(goal);
        }

        public async Task UpdateAsync(UserConsumptionGoalEntity goal)
        {
            await _repository.UpdateAsync(goal);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
