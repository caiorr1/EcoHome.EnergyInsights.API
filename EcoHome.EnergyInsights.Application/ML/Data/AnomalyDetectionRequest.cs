namespace EcoHome.EnergyInsights.Application.ML.Data
{
    public class AnomalyDetectionRequest
    {
        public float HourOfDay { get; set; }
        public float Consumption { get; set; } 
    }
}
