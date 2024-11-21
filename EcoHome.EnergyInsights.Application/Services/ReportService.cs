using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReportEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ReportEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ReportEntity>> GetByUserAsync(string externalUserId)
        {
            return await _repository.GetByUserAsync(externalUserId);
        }

        public async Task AddAsync(ReportEntity report)
        {
            await _repository.AddAsync(report);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
