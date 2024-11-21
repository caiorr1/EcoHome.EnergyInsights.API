using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Application.Services
{
    public class EnergySavingTipService : IEnergySavingTipService
    {
        private readonly IEnergySavingTipRepository _repository;

        public EnergySavingTipService(IEnergySavingTipRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EnergySavingTipEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<EnergySavingTipEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(EnergySavingTipEntity tip)
        {
            await _repository.AddAsync(tip);
        }

        public async Task UpdateAsync(EnergySavingTipEntity tip)
        {
            await _repository.UpdateAsync(tip);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
