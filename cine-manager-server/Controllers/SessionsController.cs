using CineManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Sem a opção de selecionar. O backend já recebe o dado validado.

                Algoritmo para Verificar se há alguma sessão existente no mesmo horário no backend:            
                sala da sessão inserida != sala de alguma sessão
                data da sessão inserida != data de alguma sessão
                início da sessão inserida >= endTime  da sessão anterior
                final da sessão inserida <= initTime da próxima sessão                    
                 
             */
            try
            {   
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/session/{model.SessionId}", model);
                }
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

                if (DateTime.Compare(dateNow , sessionDate)<0)
                {
                    _repo.Delete(session);
                    Console.WriteLine("Pode deletar");
                    if (await _repo.SaveChangesAsync()) return Ok();
                }
                else
                {
                    Console.WriteLine("Data menor que 10 dias");
                    return NotFound( new { 
                        message = "Ação não realizada. Esta sessão é em menos de 10 dias!",
                        error=true
                    });
                }

                // Ver pra mandar a resposta/mensagem corretamente para o client no caso de operação não permitida

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }

            return BadRequest();
        }
    }
}
