using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Entities
{
    public class NotificationLogEntity
    {
        public int Id { get; set; }
        public string ExternalUserId { get; set; }
        public string NotificationType { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }

}
