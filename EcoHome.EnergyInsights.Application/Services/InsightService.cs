using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Application.Services
{
    public class InsightService : IInsightService
    {
        private readonly IInsightRepository _repository;

        public InsightService(IInsightRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InsightEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<InsightEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<InsightEntity>> GetByUserAsync(string externalUserId)
        {
            return await _repository.GetByUserAsync(externalUserId);
        }

        public async Task AddAsync(InsightEntity insight)
        {
            await _repository.AddAsync(insight);
        }

        public async Task UpdateAsync(InsightEntity insight)
        {
            await _repository.UpdateAsync(insight);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
