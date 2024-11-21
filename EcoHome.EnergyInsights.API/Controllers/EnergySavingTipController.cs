using Microsoft.AspNetCore.Mvc;
using EcoHome.EnergyInsights.Application.Services;
using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.API.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar dicas de economia de energia.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EnergySavingTipController : ControllerBase
    {
        private readonly IEnergySavingTipService _service;

        public EnergySavingTipController(IEnergySavingTipService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todas as dicas de economia de energia.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tips = await _service.GetAllAsync();
            return Ok(tips);
        }

        /// <summary>
        /// Adiciona uma nova dica de economia de energia.
        /// </summary>
        /// <param name="tip">Dados da dica de economia.</param>
        [HttpPost]
        public async Task<IActionResult> Add(EnergySavingTipEntity tip)
        {
            await _service.AddAsync(tip);
            return CreatedAtAction(nameof(GetAll), null, tip);
        }

        /// <summary>
        /// Atualiza uma dica de economia de energia existente.
        /// </summary>
        /// <param name="id">ID da dica de economia.</param>
        /// <param name="tip">Dados atualizados da dica.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EnergySavingTipEntity tip)
        {
            if (id != tip.Id) return BadRequest();
            await _service.UpdateAsync(tip);
            return NoContent();
        }

        /// <summary>
        /// Deleta uma dica de economia de energia pelo ID.
        /// </summary>
        /// <param name="id">ID da dica de economia.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
