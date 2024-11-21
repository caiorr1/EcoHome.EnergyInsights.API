using Microsoft.AspNetCore.Mvc;
using EcoHome.EnergyInsights.Application.Services;
using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.API.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar metas de consumo de energia.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserConsumptionGoalController : ControllerBase
    {
        private readonly IUserConsumptionGoalService _service;

        public UserConsumptionGoalController(IUserConsumptionGoalService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todas as metas de consumo.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var goals = await _service.GetAllAsync();
            return Ok(goals);
        }

        /// <summary>
        /// Retorna uma meta de consumo específica pelo ID.
        /// </summary>
        /// <param name="id">ID da meta.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var goal = await _service.GetByIdAsync(id);
            if (goal == null) return NotFound();
            return Ok(goal);
        }

        /// <summary>
        /// Adiciona uma nova meta de consumo.
        /// </summary>
        /// <param name="goal">Dados da meta.</param>
        [HttpPost]
        public async Task<IActionResult> Add(UserConsumptionGoalEntity goal)
        {
            await _service.AddAsync(goal);
            return CreatedAtAction(nameof(GetById), new { id = goal.Id }, goal);
        }

        /// <summary>
        /// Atualiza uma meta de consumo existente.
        /// </summary>
        /// <param name="id">ID da meta.</param>
        /// <param name="goal">Dados atualizados.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserConsumptionGoalEntity goal)
        {
            if (id != goal.Id) return BadRequest();
            await _service.UpdateAsync(goal);
            return NoContent();
        }

        /// <summary>
        /// Deleta uma meta de consumo pelo ID.
        /// </summary>
        /// <param name="id">ID da meta.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
