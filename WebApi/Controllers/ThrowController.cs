using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller para manipulação de erros.
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : ControllerBase
    {
        /// <summary>
        /// Manipula erros de maneira genérica.
        /// </summary>
        /// <returns>Problema genérico.</returns>

        [Route("/error")]
        public IActionResult HandleError() =>
            Problem();
        
        /// <summary>
        /// Manipula erros em ambiente de desenvolvimento.
        /// </summary>
        /// <param name="hostEnvironment">Ambiente de hospedagem.</param>
        /// <returns>Problema com detalhes do erro em ambiente de desenvolvimento.</returns>

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
        [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }

    }
}