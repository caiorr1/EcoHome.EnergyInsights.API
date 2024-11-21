using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Entities
{
    public class UserConsumptionGoalEntity
    {
        public int Id { get; set; }
        public string ExternalUserId { get; set; }
        public string Category { get; set; }
        public double Goal { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
