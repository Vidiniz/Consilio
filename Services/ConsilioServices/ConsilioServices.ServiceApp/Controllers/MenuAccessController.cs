using ConsilioServices.Application.Interfaces;
using ConsilioServices.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ConsilioServices.ServiceApp.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuAccessController : ControllerBase
    {
        private readonly IMenuAccessAppService _menuAccessAppService;

        private readonly ILogger<MenuAccessController> _logger;

        public MenuAccessController(IMenuAccessAppService menuAccessAppService, ILogger<MenuAccessController> logger)
        {
            _menuAccessAppService = menuAccessAppService;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_menuAccessAppService.GetAll());
            }
            catch (BusisnessException ex)
            {
                return BadRequest(new { Erros = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(new { Errors = $"Erro não catalogado. Entre em contato com Administrador. Erro - {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("ObterTopicos")]
        public IActionResult GetTopicsWithMenuAccess()
        {
            try
            {
                return Ok(_menuAccessAppService.GetAllWithMenuAccess());
            }
            catch (BusisnessException ex)
            {
                return BadRequest(new { Erros = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(new { Errors = $"Erro não catalogado. Entre em contato com Administrador. Erro - {ex.Message}" });
            }
        }
    }
}