using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Application.Services
{
    public interface INotificationLogService
    {
        Task<IEnumerable<NotificationLogEntity>> GetAllAsync();
        Task<IEnumerable<NotificationLogEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(NotificationLogEntity notification);
        Task MarkAsReadAsync(int id);
        Task DeleteAsync(int id);
    }
}
