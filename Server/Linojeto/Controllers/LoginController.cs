using Linojeto.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linojeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto requisicao)
        {
            try
            {
                if(requisicao == null || requisicao.Login == null || requisicao.Senha == null)
                {
                    return BadRequest(new ErrorLogsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Parâmetros de entrada inválidos!"
                    });
                }

                return Ok("Usuário autenticado com sucesso!");
            }
            catch(Exception e)
            {
                _logger.LogError("Ocorreu erro ao efeftuar login", e, requisicao);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorLogsDto() {
                    Status = StatusCodes.Status500InternalServerError,
                    Error = "Ocorreu erro ao efetuar login, tente novamente!"
                });
            }
        }
    }
}
