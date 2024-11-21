using EcoHome.EnergyInsights.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface INotificationLogRepository
    {
        Task<NotificationLogEntity> GetByIdAsync(int id);
        Task<IEnumerable<NotificationLogEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(NotificationLogEntity notification);
        Task MarkAsReadAsync(int id);
        Task DeleteAsync(int id);
    }
}
