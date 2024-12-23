﻿using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface IEnergySavingTipRepository
    {
        Task<IEnumerable<EnergySavingTipEntity>> GetAllAsync();
        Task<EnergySavingTipEntity> GetByIdAsync(int id);
        Task AddAsync(EnergySavingTipEntity entity);
        Task UpdateAsync(EnergySavingTipEntity entity);
        Task DeleteAsync(int id);
    }
}
