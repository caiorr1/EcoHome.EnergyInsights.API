using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;
using EcoHome.EnergyInsights.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoHome.EnergyInsights.Infrastructure.Repositories
{
    public class NotificationLogRepository : INotificationLogRepository
    {
        private readonly EnergyInsightsContext _context;

        public NotificationLogRepository(EnergyInsightsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NotificationLogEntity>> GetAllAsync()
        {
            return await _context.NotificationLogs.ToListAsync();
        }

        public async Task<IEnumerable<NotificationLogEntity>> GetByUserAsync(string externalUserId)
        {
            return await _context.NotificationLogs
                .Where(n => n.ExternalUserId == externalUserId)
                .ToListAsync();
        }

        public async Task AddAsync(NotificationLogEntity entity)
        {
            await _context.NotificationLogs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int id)
        {
            var entity = await _context.NotificationLogs.FindAsync(id);
            if (entity != null)
            {
                entity.IsRead = true;
                _context.NotificationLogs.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.NotificationLogs.FindAsync(id);
            if (entity != null)
            {
                _context.NotificationLogs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
