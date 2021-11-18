using CineManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using CineManager.Models;

namespace CineManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        public IRepository _repo { get; }

        public SessionsController(IRepository repo)
        {
            _repo = repo;
        }

        // Http calls
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllSessionsAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Sessions model)
        {
            /*
                A mesma sala não pode passar dois ou mais filmes ao mesmo tempo.
                
                O ideal seria mostrar um calendário no frontend com os horários ocupados bloqueados.
                O UX do sistema seria melhor                                 
             */
            try
            {
                var sessions = await _repo.GetAllSessionsAsync();
                var modelDate = model.IniTime.Date;
                var modelRoom = model.RoomId;
                var modelInitTime = model.IniTime.TimeOfDay;
                var modelEndTime = model.EndTime.TimeOfDay;

                foreach (var session in sessions)
                {
                    var sessionDate = session.IniTime.Date;
                    var sessionRoom = session.RoomId;

                    if (sessionDate == modelDate && sessionRoom == modelRoom)
                    {
                        var sessionInitTime = session.IniTime.TimeOfDay;
                        var sessionEndTime = session.EndTime.TimeOfDay;

                        if (modelInitTime <= sessionEndTime && modelEndTime >= sessionInitTime)
                            return this.StatusCode(StatusCodes.Status401Unauthorized, "Conflito de horários!");
                    }
                }

                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                    return Created($"/api/session/{model.SessionId}", model);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }
            return BadRequest();
        }

        [HttpDelete("{session_id}")]
        public async Task<IActionResult> Delete(int session_id)
        {
            try
            {
                var session = await _repo.GetSessionAsyncById(session_id);

                if (session == null) return NotFound();

                //Uma sessão só pode ser removida se faltar 10 dias ou mais para que ela ocorra
                DateTime dateNow = DateTime.Now.AddDays(10);
                DateTime sessionDate = session.IniTime;

                if (DateTime.Compare(dateNow, sessionDate) < 0)
                {
                    _repo.Delete(session);
                    Console.WriteLine("Pode deletar");
                    if (await _repo.SaveChangesAsync()) return Ok();
                }
                else
                {
                    Console.WriteLine("Data menor que 10 dias");
                    return this.StatusCode(StatusCodes.Status401Unauthorized, "Esta sessão é em menos de 10 dias!");
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }
            return BadRequest();
        }
    }
}
