using Microsoft.AspNetCore.Mvc;
using EcoHome.EnergyInsights.Application.ML.Model;
using System.IO;
using EcoHome.EnergyInsights.Application.ML.Data;

namespace EcoHome.EnergyInsights.API.Controllers
{
    /// <summary>
    /// Controlador responsável por detecção de anomalias no consumo de energia.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AnomalyDetectionController : ControllerBase
    {
        private readonly string _dataPath = Path.Combine(
            Environment.CurrentDirectory,
            "..",
            "EcoHome.EnergyInsights.Application",
            "ML",
            "Data",
            "AnomalyDetectionData.csv");

        /// <summary>
        /// Detecta anomalias em dados de consumo fornecidos.
        /// </summary>
        /// <param name="data">Dados de consumo.</param>
        /// <returns>Resultados da detecção de anomalias.</returns>
        [HttpPost("detect")]
        public IActionResult DetectAnomalies([FromBody] List<AnomalyDetectionRequest> data)
        {
            if (data == null || data.Count == 0)
            {
                return BadRequest("Os dados fornecidos estão vazios ou inválidos.");
            }

            try
            {
                var model = new AnomalyDetectionModel();
                var results = model.DetectAnomaliesFromApi(data);
                return Ok(results);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao detectar anomalias: {ex.Message}");
            }
        }

        /// <summary>
        /// Treina o modelo de detecção de anomalias.
        /// </summary>
        [HttpPost("train")]
        public IActionResult TrainModel()
        {
            if (!System.IO.File.Exists(_dataPath))
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_dataPath));
                    System.IO.File.WriteAllText(_dataPath, "HoraDoDia,Consumo\n0,202.6\n1,145.42\n2,111.08\n3,72.5\n4,48.63\n5,59.99\n6,52.44\n7,29.67\n8,65.58\n9,85.57\n10,59.31\n11,74.44");

                    return NotFound($"Arquivo de dados não encontrado. Um arquivo de exemplo foi criado em: {_dataPath}");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Erro ao criar o arquivo de dados: {ex.Message}");
                }
            }

            try
            {
                var model = new AnomalyDetectionModel();
                model.TrainModel(_dataPath);
                return Ok("Modelo treinado e salvo com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao treinar o modelo: {ex.Message}");
            }
        }
    }
}
