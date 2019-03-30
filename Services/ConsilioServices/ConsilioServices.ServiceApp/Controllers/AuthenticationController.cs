using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConsilioServices.ServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ISystemUserAppService _systemUserAppService;

        public AuthenticationController(IConfiguration configuration, ISystemUserAppService systemUserAppService)
        {
            _configuration = configuration;

            _systemUserAppService = systemUserAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginViewModel login, char[] config)
        {
            try
            {                
                return Ok(new { Token = _systemUserAppService.Login(login, _configuration["SecurityKey"].ToCharArray()) });
            }
            catch (BusisnessException ex)
            {
                return NotFound(new { Login = ex.Message });
            }
        }

    }
}
