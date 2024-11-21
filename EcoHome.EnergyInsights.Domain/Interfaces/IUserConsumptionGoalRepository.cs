using EcoHome.EnergyInsights.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface IUserConsumptionGoalRepository
    {
        Task<UserConsumptionGoalEntity> GetByIdAsync(int id);
        Task<IEnumerable<UserConsumptionGoalEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(UserConsumptionGoalEntity goal);
        Task UpdateAsync(UserConsumptionGoalEntity goal);
        Task DeleteAsync(int id);
    }
}
