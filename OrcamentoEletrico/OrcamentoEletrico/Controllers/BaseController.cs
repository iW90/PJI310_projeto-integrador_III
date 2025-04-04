using Microsoft.AspNetCore.Mvc;

namespace OrcamentoEletrico.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult HandleActionResult<T>(T result)
        {
            if (result == null)
            {
                //Retorna um status 404 (Not Found).
                return NotFound(new
                {
                    success = false,
                    message = "Não encontrado."
                });
            }
            else
            {
                //Retorna um status 200 (Success).
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
        }

        //Retorna um status 404 (Not Found).
        protected ActionResult HandleNotFoundResult(string errorMessage)
        {
            return NotFound(errorMessage);
        }

        //Retorna um status 204 (No Content).
        protected ActionResult HandleNoContentResult()
        {
            return NoContent();
        }

        //Retorna um status 400 (Bad Request).
        protected ActionResult HandleBadRequestResult(string errorMessage)
        {
            return BadRequest(new
            {
                success = false,
                message = errorMessage
            });
        }

        //Retorna um status 500 (Internal Server Error).
        protected ActionResult HandleInternalServerErrorResult(string errorMessage)
        {
            return StatusCode(500, new
            {
                success = false,
                message = errorMessage
            });
        }

    }
}

