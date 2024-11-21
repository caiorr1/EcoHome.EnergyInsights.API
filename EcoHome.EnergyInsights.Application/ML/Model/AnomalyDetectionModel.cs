using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace EcoHome.EnergyInsights.Application.ML.Model
{
    public class AnomalyDetectionModel
    {
        private static readonly string ModelPath = Path.Combine(Environment.CurrentDirectory, "ML", "Model", "AnomalyDetectionModel.zip");

        public static void TrainModel(string dataPath)
        {
            var context = new MLContext();

            IDataView data = context.Data.LoadFromTextFile<AnomalyDetectionData>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ',');

            var pipeline = context.Transforms.DetectIidSpike(
                outputColumnName: "PredictedAnomaly",
                inputColumnName: "Consumption",
                confidence: 95,
                pvalueHistoryLength: 10);

            var model = pipeline.Fit(data);

            context.Model.Save(model, data.Schema, ModelPath);
            Console.WriteLine($"Modelo de Detecção de Anomalias salvo em {ModelPath}");
        }

        public static void DetectAnomalies(string dataPath)
        {
            var context = new MLContext();
            ITransformer model = context.Model.Load(ModelPath, out _);

            IDataView data = context.Data.LoadFromTextFile<AnomalyDetectionData>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ',');

            IDataView predictions = model.Transform(data);
            var anomalies = context.Data.CreateEnumerable<AnomalyPrediction>(predictions, reuseRowObject: false);

            foreach (var anomaly in anomalies)
            {
                Console.WriteLine($"Anomalia: {anomaly.PredictedAnomaly[0]}, P-Value: {anomaly.PredictedAnomaly[1]}");
            }
        }
    }

    public class AnomalyDetectionData
    {
        public float Consumption { get; set; }
    }

    public class AnomalyPrediction
    {
        [VectorType(3)]
        public double[] PredictedAnomaly { get; set; }
    }
}
