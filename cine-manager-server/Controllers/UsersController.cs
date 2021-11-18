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
    public class UsersController : ControllerBase
    {
        public IRepository _repo { get; }

        public UsersController(IRepository repo)
        {
            _repo = repo;
        }

        // Http calls
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllUsersAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Users model)
        {
            try
            {   // Verificação ingênua, apenas para executar o fluxo da requisição
                var users = await _repo.GetAllUsersAsync();
                string token = "naiveuselesstoken";
                string adminToken = "naiveuselesstokenadmin";
                bool passwordOk = false;
                bool userOk = false;
                bool isAdmin = false;

                foreach(var user in users){ 
                    if(user.UserEmail == model.UserEmail){
                        userOk = true;                    
                        if(user.Password == model.Password){
                            passwordOk = true;
                            isAdmin = user.IsAdmin;
                            break;
                        }
                    }
                }                
                if(userOk && passwordOk && isAdmin) 
                    return this.StatusCode(StatusCodes.Status202Accepted, adminToken);

                if(userOk && passwordOk && !isAdmin)
                    return this.StatusCode(StatusCodes.Status202Accepted, token);

                if(!userOk)
                    return this.StatusCode(StatusCodes.Status401Unauthorized, "Usuário não encontrado!");
                
                if(!passwordOk)
                    return this.StatusCode(StatusCodes.Status401Unauthorized, "Senha inválida!");
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados.");
            }
            return BadRequest();
        }

    }
}
