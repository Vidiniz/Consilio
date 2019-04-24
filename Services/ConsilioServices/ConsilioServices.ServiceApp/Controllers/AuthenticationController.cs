using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConsilioServices.ServiceApp.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IAuthenticationAppService _authenticationAppService;

        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IConfiguration configuration, IAuthenticationAppService authenticationAppService,
            ILogger<AuthenticationController> logger)
        {
            _configuration = configuration;

            _authenticationAppService = authenticationAppService;

            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]        
        public async Task<IActionResult> Login([FromBody]LoginViewModel login)
        {
            try
            {                
                return Ok(_authenticationAppService.Login(login, _configuration["SecurityKey"].ToCharArray()) );
            }
            catch (BusisnessException ex)
            {
                return BadRequest(new { Login = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(new { Errors = $"Erro não catalogado. Entre em contato com Administrador. Erro - {ex.Message}" });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ValidateToken")]
        public IActionResult ValidateToken([FromBody]TokenViewModel token)
        {
            try
            {
                if (token == null)
                    return BadRequest(new { Error = "Token nulo ou inválido!" });

                if (string.IsNullOrEmpty(token.Token))
                    return BadRequest(new { Error = "Token nulo ou inválido!" });

                if (!_authenticationAppService.ValidateToken(token.Token, _configuration["SecurityKey"].ToCharArray()))
                    throw new BusisnessException("Token Inválido!");

                return Ok("Token Válido");
            }
            catch(BusisnessException ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(new { Errors = $"Erro não catalogado. Entre em contato com Administrador. Erro - {ex.Message}" });
            }
        }

    }
}
