namespace EcoHome.EnergyInsights.Application.ML.Data
{
    public class AnomalyDetectionResponse
    {
        public bool IsAnomaly { get; set; } 
        public double PValue { get; set; }  
        public double Score { get; set; }  
    }
}
