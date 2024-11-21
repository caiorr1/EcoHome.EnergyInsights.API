using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Infrastructure.Data.Repositories
{
    public class InsightRepository : IInsightRepository
    {
        private readonly EnergyInsightsContext _context;

        public InsightRepository(EnergyInsightsContext context)
        {
            _context = context;
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

        public async Task AddAsync(InsightEntity insight)
        {
            await _context.Insights.AddAsync(insight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InsightEntity insight)
        {
            _context.Insights.Update(insight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var insight = await GetByIdAsync(id);
            if (insight != null)
            {
                _context.Insights.Remove(insight);
                await _context.SaveChangesAsync();
            }
        }
    }
}
