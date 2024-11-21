using Microsoft.AspNetCore.Mvc;
using EcoHome.EnergyInsights.Application.Services;
using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.API.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar relatórios.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os relatórios.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reports = await _service.GetAllAsync();
            return Ok(reports);
        }

        /// <summary>
        /// Adiciona um novo relatório.
        /// </summary>
        /// <param name="report">Dados do relatório.</param>
        [HttpPost]
        public async Task<IActionResult> Add(ReportEntity report)
        {
            await _service.AddAsync(report);
            return CreatedAtAction(nameof(GetAll), null, report);
        }

        /// <summary>
        /// Deleta um relatório pelo ID.
        /// </summary>
        /// <param name="id">ID do relatório.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
