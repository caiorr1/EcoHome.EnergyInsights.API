﻿using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.Domain.Interfaces
{
    public interface INotificationLogRepository
    {
        Task<IEnumerable<NotificationLogEntity>> GetAllAsync();
        Task<IEnumerable<NotificationLogEntity>> GetByUserAsync(string externalUserId);
        Task AddAsync(NotificationLogEntity entity);
        Task MarkAsReadAsync(int id);
        Task DeleteAsync(int id);
    }
}
