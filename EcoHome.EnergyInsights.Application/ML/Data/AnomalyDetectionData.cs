using Microsoft.ML.Data;

namespace EcoHome.EnergyInsights.Application.ML.Data
{
    public class AnomalyDetectionData
    {
        [LoadColumn(0)]
        public float HourOfDay { get; set; }

        [LoadColumn(1)]
        public float Consumption { get; set; }
    }
}
