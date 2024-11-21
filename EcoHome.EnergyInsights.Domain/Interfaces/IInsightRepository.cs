using EcoHome.EnergyInsights.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface IInsightRepository
    {
        Task<InsightEntity> GetByIdAsync(int id);
        Task<IEnumerable<InsightEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(InsightEntity insight);
        Task UpdateAsync(InsightEntity insight);
        Task DeleteAsync(int id);
    }
}
