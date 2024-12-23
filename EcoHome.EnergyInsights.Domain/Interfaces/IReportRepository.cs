﻿using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<ReportEntity>> GetAllAsync();
        Task<ReportEntity> GetByIdAsync(int id);
        Task<IEnumerable<ReportEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(ReportEntity entity);
        Task DeleteAsync(int id);
    }
}
