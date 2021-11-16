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
                Deve-se permitir somente selecionar salas que estão com horário disponível, ou
                seja, se uma sala já estiver vinculada a outra sessão que contém o horário dentro
                do intervalo do horário selecionado para a sessão sendo criada, então esta sala
                não deve ser exibida. Resumidamente, a mesma sala não pode passar dois ou
                mais filmes ao mesmo tempo.
                As opções de salas são mostradas no frontend para a escolha, fazer essa validação no frontend?
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
                // verificar o datetime.now e subtrair o datetime da data
                // se for maior que 10 dias pode deletar.

                _repo.Delete(session);

                if (await _repo.SaveChangesAsync()) return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }

            return BadRequest();
        }
    }
}
