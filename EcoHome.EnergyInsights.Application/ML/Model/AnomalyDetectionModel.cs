using EcoHome.EnergyInsights.Application.ML.Data;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
using System.IO;

namespace EcoHome.EnergyInsights.Application.ML.Model
{
    public class AnomalyDetectionModel
    {
        private static readonly string ModelPath = Path.Combine(Environment.CurrentDirectory, "ML", "Model", "AnomalyDetectionModel.zip");

        /// <summary>
        /// Treina o modelo de detecção de anomalias com base em um arquivo CSV.
        /// </summary>
        /// <param name="dataPath">Caminho para o arquivo de dados.</param>
        public void TrainModel(string dataPath)
        {
            if (!File.Exists(dataPath))
            {
                throw new FileNotFoundException($"Arquivo de dados não encontrado: {dataPath}");
            }

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

            Directory.CreateDirectory(Path.GetDirectoryName(ModelPath));

            context.Model.Save(model, data.Schema, ModelPath);
            Console.WriteLine($"Modelo treinado e salvo em {ModelPath}");
        }

        /// <summary>
        /// Detecta anomalias a partir de dados recebidos via API.
        /// </summary>
        /// <param name="data">Dados de entrada para a detecção.</param>
        /// <returns>Lista de respostas com informações sobre as anomalias detectadas.</returns>
        public List<AnomalyDetectionResponse> DetectAnomaliesFromApi(List<AnomalyDetectionRequest> data)
        {
            var context = new MLContext();

            var dataView = context.Data.LoadFromEnumerable(data);

            if (!File.Exists(ModelPath))
            {
                throw new FileNotFoundException($"Modelo não encontrado no caminho: {ModelPath}. Treine o modelo antes de tentar detectá-lo.");
            }

            var model = context.Model.Load(ModelPath, out _);

            var transformedData = model.Transform(dataView);

            var predictions = context.Data.CreateEnumerable<AnomalyPrediction>(transformedData, reuseRowObject: false);

            var results = new List<AnomalyDetectionResponse>();
            foreach (var prediction in predictions)
            {
                results.Add(new AnomalyDetectionResponse
                {
                    IsAnomaly = prediction.PredictedAnomaly[0] == 1,
                    PValue = prediction.PredictedAnomaly[1],
                    Score = prediction.PredictedAnomaly[2]
                });
            }

            return results;
        }
    }

    /// <summary>
    /// Classe para os dados de entrada do treinamento e detecção.
    /// </summary>
    public class AnomalyDetectionData
    {
        [LoadColumn(0)]
        public float HourOfDay { get; set; }

        [LoadColumn(1)]
        public float Consumption { get; set; }
    }

    /// <summary>
    /// Classe para as previsões de anomalia.
    /// </summary>
    public class AnomalyPrediction
    {
        [VectorType(3)]
        public double[] PredictedAnomaly { get; set; }
    }
}
