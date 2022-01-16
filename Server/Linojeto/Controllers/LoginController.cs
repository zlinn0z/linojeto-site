using Linojeto.Dtos;
using Linojeto.Models;
using Linojeto.Repository;
using Linojeto.Services;
using Linojeto.Utils;
using Microsoft.AspNetCore.Authorization;
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
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserRepository _usuarioRepository;

        public LoginController(ILogger<LoginController> logger, IUserRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [AllowAnonymous]
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

                var usuario = _usuarioRepository.GetUserByLoginPassword(requisicao.Login, MD5Utils.GenerateHashMD5(requisicao.Senha));

                if(usuario == null)
                {
                    return BadRequest(new ErrorLogsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Usuário ou senha inválidos!"
                    });
                }

                var token = TokenService.GenerateToken(usuario);


                return Ok(new LoginRespostaDto()
                {
                    Email = usuario.Email,
                    Name = usuario.Nome,
                    Token = token
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
