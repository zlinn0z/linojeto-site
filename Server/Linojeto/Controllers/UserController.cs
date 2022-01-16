using Linojeto.Dtos;
using Linojeto.Models;
using Linojeto.Repository;
using Linojeto.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Linojeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _usuarioRepository;

       public UserController(ILogger<UserController> logger, IUserRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveUser([FromBody]Usuario usuario)
        {
            try
            {
                var erros = new List<string>();
                if(string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrWhiteSpace(usuario.Nome) || usuario.Nome.Length <= 2)
                {
                    erros.Add("Nome inválido");
                }

                if(string.IsNullOrEmpty(usuario.Senha) || string.IsNullOrWhiteSpace(usuario.Senha) 
                    || usuario.Senha.Length <= 4 && Regex.IsMatch(usuario.Senha, "[a-zA-Z0-9]+", RegexOptions.IgnoreCase))
                {
                    erros.Add("Senha inválida");
                }

                Regex regex = new Regex(@"^([\w\.\-\+\D]@([\w\-]+))((\.(\w){2,3})+)$");

                if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Email)
                    || regex.Match(usuario.Email).Success)
                {
                    erros.Add("Email inválido");
                }

                if (_usuarioRepository.HasUserByEmail(usuario.Email))
                {
                    erros.Add("Já existe uma conta com o email informado");
                }

                if(erros.Count > 0)
                {
                    return BadRequest(new ErrorLogsDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Errors = erros
                    });
                }

                usuario.Email = usuario.Email.ToLower();
                usuario.Senha = MD5Utils.GenerateHashMD5(usuario.Senha);
                _usuarioRepository.Save(usuario);

                return Ok(new { msg = "Usuário criado com sucesso!"});
            } 
            catch(Exception e)
            {
                _logger.LogError("Ocorreu um erro ao obter usuário", e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorLogsDto()
                {
                   Status = StatusCodes.Status500InternalServerError,
                   Error = "Ocorreu um erro ao efetuar login, tente novamente!"
                });
            }
        }
    }
}
