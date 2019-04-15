using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsilioServices.ServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IAuthenticationAppService _authenticationAppService;

        private readonly IServiceCollection _services;

        public AuthenticationController(IConfiguration configuration, IAuthenticationAppService authenticationAppService)
        {
            _configuration = configuration;

            _authenticationAppService = authenticationAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]        
        public IActionResult Login([FromBody]LoginViewModel login)
        {
            try
            {                
                return Ok(new { Token = _authenticationAppService.Login(login, _configuration["SecurityKey"].ToCharArray()) });
            }
            catch (BusisnessException ex)
            {
                return BadRequest(new { Login = ex.Message });
            }
            catch (Exception ex)
            {
                // TODO: Implementar Log
                return BadRequest(new { Errors = ex.Message });
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

                return Ok();
            }
            catch(BusisnessException ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
            catch(Exception ex)
            {
                // TODO: Implementar Log
                return BadRequest(new { Errors = ex.Message });
            }            
        }

    }
}
