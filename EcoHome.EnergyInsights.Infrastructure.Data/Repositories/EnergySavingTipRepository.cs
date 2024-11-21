using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;
using EcoHome.EnergyInsights.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoHome.EnergyInsights.Infrastructure.Repositories
{
    public class EnergySavingTipRepository : IEnergySavingTipRepository
    {
        private readonly EnergyInsightsContext _context;

        public EnergySavingTipRepository(EnergyInsightsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EnergySavingTipEntity>> GetAllAsync()
        {
            return await _context.EnergySavingTips.ToListAsync();
        }

        public async Task<EnergySavingTipEntity> GetByIdAsync(int id)
        {
            return await _context.EnergySavingTips.FindAsync(id);
        }

        public async Task AddAsync(EnergySavingTipEntity entity)
        {
            await _context.EnergySavingTips.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EnergySavingTipEntity entity)
        {
            _context.EnergySavingTips.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.EnergySavingTips.FindAsync(id);
            if (entity != null)
            {
                _context.EnergySavingTips.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
