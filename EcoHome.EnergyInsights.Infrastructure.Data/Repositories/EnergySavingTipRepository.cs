using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Infrastructure.Data.Repositories
{
    public class EnergySavingTipRepository : IEnergySavingTipRepository
    {
        private readonly EnergyInsightsContext _context;

        public EnergySavingTipRepository(EnergyInsightsContext context)
        {
            _context = context;
        }

        public async Task<EnergySavingTipEntity> GetByIdAsync(int id)
        {
            return await _context.EnergySavingTips.FindAsync(id);
        }

        public async Task<IEnumerable<EnergySavingTipEntity>> GetAllActiveAsync()
        {
            return await _context.EnergySavingTips
                .Where(t => t.IsActive)
                .ToListAsync();
        }

        public async Task AddAsync(EnergySavingTipEntity tip)
        {
            await _context.EnergySavingTips.AddAsync(tip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EnergySavingTipEntity tip)
        {
            _context.EnergySavingTips.Update(tip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tip = await GetByIdAsync(id);
            if (tip != null)
            {
                _context.EnergySavingTips.Remove(tip);
                await _context.SaveChangesAsync();
            }
        }
    }
}
