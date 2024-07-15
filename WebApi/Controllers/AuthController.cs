using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Services;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pela autenticação na API.
    /// </summary>
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {/// <summary>
     /// Autentica um usuário com base no nome de usuário e senha fornecidos.
     /// </summary>
     /// <param name="username">Nome de usuário.</param>
     /// <param name="password">Senha.</param>
     /// <returns>Token de autenticação.</returns>
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "Eduardo" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Domain.Model.EmployeeAggregate.Employee());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}