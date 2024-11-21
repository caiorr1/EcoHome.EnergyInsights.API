using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;
using EcoHome.EnergyInsights.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoHome.EnergyInsights.Infrastructure.Repositories
{
    public class UserConsumptionGoalRepository : IUserConsumptionGoalRepository
    {
        private readonly EnergyInsightsContext _context;

        public UserConsumptionGoalRepository(EnergyInsightsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserConsumptionGoalEntity>> GetAllAsync()
        {
            return await _context.UserConsumptionGoals.ToListAsync();
        }

        public async Task<UserConsumptionGoalEntity> GetByIdAsync(int id)
        {
            return await _context.UserConsumptionGoals.FindAsync(id);
        }

        public async Task<IEnumerable<UserConsumptionGoalEntity>> GetByUserAsync(string externalUserId)
        {
            return await _context.UserConsumptionGoals
                .Where(g => g.ExternalUserId == externalUserId)
                .ToListAsync();
        }

        public async Task AddAsync(UserConsumptionGoalEntity entity)
        {
            await _context.UserConsumptionGoals.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserConsumptionGoalEntity entity)
        {
            _context.UserConsumptionGoals.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.UserConsumptionGoals.FindAsync(id);
            if (entity != null)
            {
                _context.UserConsumptionGoals.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
