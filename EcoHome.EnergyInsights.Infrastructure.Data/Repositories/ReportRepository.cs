using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;
using EcoHome.EnergyInsights.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoHome.EnergyInsights.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly EnergyInsightsContext _context;

        public ReportRepository(EnergyInsightsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReportEntity>> GetAllAsync()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<ReportEntity> GetByIdAsync(int id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public async Task<IEnumerable<ReportEntity>> GetByUserAsync(string externalUserId)
        {
            return await _context.Reports
                .Where(r => r.ExternalUserId == externalUserId)
                .ToListAsync();
        }

        public async Task AddAsync(ReportEntity entity)
        {
            await _context.Reports.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Reports.FindAsync(id);
            if (entity != null)
            {
                _context.Reports.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
