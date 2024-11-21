using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Entities
{
    public class ReportEntity
    {
        public int Id { get; set; }
        public string ExternalUserId { get; set; }
        public string ReportType { get; set; }
        public string Data { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
