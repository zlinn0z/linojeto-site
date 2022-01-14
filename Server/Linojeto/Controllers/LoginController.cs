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

        private readonly string loginTeste = "admin@admin.com";
        private readonly string senhaTeste = "Admin1234@";


        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto requisicao)
        {
            try
            {
                if(requisicao == null || string.IsNullOrEmpty(requisicao.Login) || string.IsNullOrEmpty(requisicao.Senha))
                {
                    return BadRequest(new ErrorLogsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Parâmetros de entrada inválidos!"
                    });
                }

                return Ok(new LoginRespostaDto()
                {
                    Email = loginTeste,
                    Name = "Usuário de Teste",
                    Token = ""
                });
            }
            catch(Exception e)
            {
                _logger.LogError("Ocorreu erro ao efeftuar login", e, requisicao);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorLogsDto() 
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Error = "Ocorreu erro ao efetuar login, tente novamente!"
                });
            }
        }
    }
}
