using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contracts;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            this._eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await _eventService.GetAllEventsAsync(true);
                if (events == null) return NotFound("Nenhum evento encontrado.");

                return Ok(events);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try{
                var _event = await _eventService.GetEventByIdAsync(id, true);
                if (_event == null) return NotFound("Evento por ID não encontrado.");

                return Ok(_event);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }    
        }

        [HttpGet("{theme}/theme")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try{
                var _event = await _eventService.GetAllEventsByThemeAsync(theme, true);
                if (_event == null) return NotFound("Eventos por tema não encontrados.");

                return Ok(_event);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }    
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try{
                var _event = await _eventService.AddEvents(model);
                if (_event == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(_event);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            try{
                var _event = await _eventService.UpdateEvent(id, model);
                if (_event == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(_event);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventService.DeleteEvent(id) ?
                    Ok("Deletado") : 
                    BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }        
    }
}
