using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;
using EcoHome.EnergyInsights.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoHome.EnergyInsights.Infrastructure.Repositories
{
    public class InsightRepository : IInsightRepository
    {
        private readonly EnergyInsightsContext _context;

        public InsightRepository(EnergyInsightsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InsightEntity>> GetAllAsync()
        {
            return await _context.Insights.ToListAsync();
        }

        public async Task<InsightEntity> GetByIdAsync(int id)
        {
            return await _context.Insights.FindAsync(id);
        }

        public async Task<IEnumerable<InsightEntity>> GetByUserAsync(string externalUserId)
        {
            return await _context.Insights
                .Where(i => i.ExternalUserId == externalUserId)
                .ToListAsync();
        }

        public async Task AddAsync(InsightEntity entity)
        {
            await _context.Insights.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InsightEntity entity)
        {
            _context.Insights.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Insights.FindAsync(id);
            if (entity != null)
            {
                _context.Insights.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
