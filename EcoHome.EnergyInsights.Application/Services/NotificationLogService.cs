using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Application.Services
{
    public class NotificationLogService : INotificationLogService
    {
        private readonly INotificationLogRepository _repository;

        public NotificationLogService(INotificationLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NotificationLogEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<NotificationLogEntity>> GetByUserAsync(string externalUserId)
        {
            return await _repository.GetByUserAsync(externalUserId);
        }

        public async Task AddAsync(NotificationLogEntity notification)
        {
            await _repository.AddAsync(notification);
        }

        public async Task MarkAsReadAsync(int id)
        {
            await _repository.MarkAsReadAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
