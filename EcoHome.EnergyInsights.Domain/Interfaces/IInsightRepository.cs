﻿using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface IInsightRepository
    {
        Task<IEnumerable<InsightEntity>> GetAllAsync();
        Task<InsightEntity> GetByIdAsync(int id);
        Task<IEnumerable<InsightEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(InsightEntity entity);
        Task UpdateAsync(InsightEntity entity);
        Task DeleteAsync(int id);
    }
}
