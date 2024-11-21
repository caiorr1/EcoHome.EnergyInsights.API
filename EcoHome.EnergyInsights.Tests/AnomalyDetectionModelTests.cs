using EcoHome.EnergyInsights.Application.ML.Model;
using EcoHome.EnergyInsights.Application.ML.Data;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace EcoHome.EnergyInsights.Tests
{
    public class AnomalyDetectionModelTests
    {
        private readonly string _dataPath;
        private readonly string _modelPath;

        public AnomalyDetectionModelTests()
        {
            _dataPath = Path.Combine(Path.GetTempPath(), "AnomalyDetectionData.csv");
            _modelPath = Path.Combine(Directory.GetCurrentDirectory(), "ML", "Model", "AnomalyDetectionModel.zip");
        }

        [Fact]
        public void TrainModel_WithValidDataPath_ShouldNotThrowException()
        {
            if (File.Exists(_modelPath))
                File.Delete(_modelPath);

            File.WriteAllText(_dataPath, "HoraDoDia,Consumo\n0,202.6\n1,145.42");
            var model = new AnomalyDetectionModel();

            var exception = Record.Exception(() => model.TrainModel(_dataPath));

            Assert.Null(exception);

            if (File.Exists(_modelPath))
                File.Delete(_modelPath);
        }

        [Fact]
        public void DetectAnomaliesFromApi_WithValidData_ShouldReturnExpectedResults()
        {
            if (File.Exists(_modelPath))
                File.Delete(_modelPath);

            var dataPath = Path.Combine(Path.GetTempPath(), "AnomalyDetectionData.csv");
            File.WriteAllText(dataPath, "HoraDoDia,Consumo\n0,202.6\n1,145.42");
            var model = new AnomalyDetectionModel();

            model.TrainModel(dataPath);

            var testData = new List<AnomalyDetectionRequest>
            {
                new AnomalyDetectionRequest { HourOfDay = 0, Consumption = 202.6f },
                new AnomalyDetectionRequest { HourOfDay = 1, Consumption = 500.0f }
            };

            var exception = Record.Exception(() => model.DetectAnomaliesFromApi(testData));

            Assert.Null(exception);

            if (File.Exists(_modelPath))
                File.Delete(_modelPath);
            if (File.Exists(dataPath))
                File.Delete(dataPath);
        }
    }
}
