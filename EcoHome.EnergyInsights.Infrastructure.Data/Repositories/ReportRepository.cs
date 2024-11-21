using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Infrastructure.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly EnergyInsightsContext _context;

        public ReportRepository(EnergyInsightsContext context)
        {
            _context = context;
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

        public async Task AddAsync(ReportEntity report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var report = await GetByIdAsync(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
            }
        }
    }
}
