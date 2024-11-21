using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Infrastructure.Data.Repositories
{
    public class NotificationLogRepository : INotificationLogRepository
    {
        private readonly EnergyInsightsContext _context;

        public NotificationLogRepository(EnergyInsightsContext context)
        {
            _context = context;
        }

        public async Task<NotificationLogEntity> GetByIdAsync(int id)
        {
            return await _context.NotificationLogs.FindAsync(id);
        }

        public async Task<IEnumerable<NotificationLogEntity>> GetByUserAsync(string externalUserId)
        {
            return await _context.NotificationLogs
                .Where(n => n.ExternalUserId == externalUserId)
                .ToListAsync();
        }

        public async Task AddAsync(NotificationLogEntity notification)
        {
            await _context.NotificationLogs.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int id)
        {
            var notification = await GetByIdAsync(id);
            if (notification != null)
            {
                notification.IsRead = true;
                _context.NotificationLogs.Update(notification);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await GetByIdAsync(id);
            if (notification != null)
            {
                _context.NotificationLogs.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }
    }
}
