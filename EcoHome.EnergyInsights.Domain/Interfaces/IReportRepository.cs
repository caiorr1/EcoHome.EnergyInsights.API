using EcoHome.EnergyInsights.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface IReportRepository
    {
        Task<ReportEntity> GetByIdAsync(int id);
        Task<IEnumerable<ReportEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(ReportEntity report);
        Task DeleteAsync(int id);
    }
}
