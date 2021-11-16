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
    public class MoviesController : ControllerBase
    {
        public IRepository _repo { get; }

        public MoviesController(IRepository repo)
        {
            _repo = repo;
        }

        private async Task<bool> CheckIfExists(Movies movie)
        {
            var movies = await _repo.GetAllMoviesAsync();
            
            foreach(var m in movies)
            {
                if (m.Title == movie.Title) return true;
            }

            return false;
        }

        // Http calls
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllMoviesAsync();
                Console.WriteLine($"Movies Get() {result.Count()} items");
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }
        }

        [HttpGet("{movie_id}")]
        public async Task<IActionResult> GetByMovieId(int movie_id)
        {
            try
            {
                var result = await _repo.GetMovieAsyncById(movie_id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }
        }

        [HttpGet("by-session/{session_id}")]
        public async Task<IActionResult> GetBySessionId(int session_id)
        {
            try
            {
                var result = await _repo.GetMovieAsyncBySessionId(session_id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Movies model)
        {
            try
            {
                if (!await CheckIfExists(model))
                {
                    _repo.Add(model);

                    if (await _repo.SaveChangesAsync())
                    {
                        return Created($"/api/movies/{model.MovieId}", model);
                    }
                }
                //return this.StatusCode(StatusCodes.Status100Continue,"Registo já existente.");
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }

            return BadRequest();
        }

        [HttpPut("{movie_id}")]
        public async Task<IActionResult> Put(int movie_id, Movies model)
        {
            try
            {
                var movie = await _repo.GetMovieAsyncById(movie_id);

                if (movie == null) return NotFound("Não encontrado");

                if (movie.Title != model.Title)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangesAsync())
                    {
                        // get movie again, once it has changed,
                        movie = await _repo.GetMovieAsyncById(movie_id);
                        return Created($"/api/movies/{model.MovieId}", movie);
                    }
                }
                //return this.StatusCode(StatusCodes.Status100Continue, "Registo já existente.");
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }

            return BadRequest();
        }

        [HttpDelete("{movie_id}")]
        public async Task<IActionResult> Delete(int movie_id)
        {
            try
            {
                var movie = await _repo.GetMovieAsyncById(movie_id);

                if (movie == null) return NotFound();

                if (movie.Sessions.Count > 0) return StatusCode(200, "Não foi possível excluir, existem sessões vinculadas ao filme.");

                _repo.Delete(movie);

                if (await _repo.SaveChangesAsync()) return Ok("Filme deletado");

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }

            return BadRequest();
        }

    }
}
