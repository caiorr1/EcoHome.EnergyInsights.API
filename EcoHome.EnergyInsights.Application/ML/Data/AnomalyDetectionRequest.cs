namespace EcoHome.EnergyInsights.Application.ML.Data
{
    public class AnomalyDetectionRequest
    {
        public int HoraDoDia { get; set; }
        public float Consumo { get; set; }
    }
}
