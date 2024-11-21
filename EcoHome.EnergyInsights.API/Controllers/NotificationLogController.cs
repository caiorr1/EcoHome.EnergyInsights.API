using Microsoft.AspNetCore.Mvc;
using EcoHome.EnergyInsights.Application.Services;
using EcoHome.EnergyInsights.Domain.Entities;

namespace EcoHome.EnergyInsights.API.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar logs de notificações.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationLogController : ControllerBase
    {
        private readonly INotificationLogService _service;

        public NotificationLogController(INotificationLogService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os logs de notificações.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _service.GetAllAsync();
            return Ok(logs);
        }

        /// <summary>
        /// Adiciona um novo log de notificação.
        /// </summary>
        /// <param name="log">Dados do log.</param>
        [HttpPost]
        public async Task<IActionResult> Add(NotificationLogEntity log)
        {
            await _service.AddAsync(log);
            return CreatedAtAction(nameof(GetAll), null, log);
        }

        /// <summary>
        /// Marca uma notificação como lida.
        /// </summary>
        /// <param name="id">ID do log.</param>
        [HttpPut("mark-as-read/{id}")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _service.MarkAsReadAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Deleta um log de notificação pelo ID.
        /// </summary>
        /// <param name="id">ID do log.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
