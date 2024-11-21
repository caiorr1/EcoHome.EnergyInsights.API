using EcoHome.EnergyInsights.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface IEnergySavingTipRepository
    {
        Task<EnergySavingTipEntity> GetByIdAsync(int id);
        Task<IEnumerable<EnergySavingTipEntity>> GetAllActiveAsync();
        Task AddAsync(EnergySavingTipEntity tip);
        Task UpdateAsync(EnergySavingTipEntity tip);
        Task DeleteAsync(int id);
    }
}
