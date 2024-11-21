using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoHome.EnergyInsights.Domain.Entities;
using EcoHome.EnergyInsights.Domain.Interfaces;

namespace EcoHome.EnergyInsights.Infrastructure.Data.Repositories
{
    public class UserConsumptionGoalRepository : IUserConsumptionGoalRepository
    {
        private readonly EnergyInsightsContext _context;

        public UserConsumptionGoalRepository(EnergyInsightsContext context)
        {
            _context = context;
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

        public async Task AddAsync(UserConsumptionGoalEntity goal)
        {
            await _context.UserConsumptionGoals.AddAsync(goal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserConsumptionGoalEntity goal)
        {
            _context.UserConsumptionGoals.Update(goal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var goal = await GetByIdAsync(id);
            if (goal != null)
            {
                _context.UserConsumptionGoals.Remove(goal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
