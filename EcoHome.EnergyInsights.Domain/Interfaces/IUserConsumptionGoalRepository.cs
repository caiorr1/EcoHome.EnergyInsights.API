﻿using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface IUserConsumptionGoalRepository
    {
        Task<IEnumerable<UserConsumptionGoalEntity>> GetAllAsync();
        Task<UserConsumptionGoalEntity> GetByIdAsync(int id);
        Task<IEnumerable<UserConsumptionGoalEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(UserConsumptionGoalEntity entity);
        Task UpdateAsync(UserConsumptionGoalEntity entity);
        Task DeleteAsync(int id);
    }
}
