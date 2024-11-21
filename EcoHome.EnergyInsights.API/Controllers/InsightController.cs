using Microsoft.AspNetCore.Mvc;
using EcoHome.EnergyInsights.Application.Services;
using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.API.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar os insights.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class InsightController : ControllerBase
    {
        private readonly IInsightService _service;

        public InsightController(IInsightService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os insights.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var insights = await _service.GetAllAsync();
            return Ok(insights);
        }

        /// <summary>
        /// Retorna um insight específico pelo ID.
        /// </summary>
        /// <param name="id">ID do insight.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var insight = await _service.GetByIdAsync(id);
            if (insight == null) return NotFound();
            return Ok(insight);
        }

        /// <summary>
        /// Adiciona um novo insight.
        /// </summary>
        /// <param name="insight">Dados do insight.</param>
        [HttpPost]
        public async Task<IActionResult> Add(InsightEntity insight)
        {
            await _service.AddAsync(insight);
            return CreatedAtAction(nameof(GetById), new { id = insight.Id }, insight);
        }

        /// <summary>
        /// Atualiza um insight existente.
        /// </summary>
        /// <param name="id">ID do insight.</param>
        /// <param name="insight">Dados atualizados.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InsightEntity insight)
        {
            if (id != insight.Id) return BadRequest();
            await _service.UpdateAsync(insight);
            return NoContent();
        }

        /// <summary>
        /// Deleta um insight pelo ID.
        /// </summary>
        /// <param name="id">ID do insight.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
