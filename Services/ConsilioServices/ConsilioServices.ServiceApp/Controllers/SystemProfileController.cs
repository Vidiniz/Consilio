using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Exceptions;
using ConsilioServices.Infrastructure.CrossCutting.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ConsilioServices.ServiceApp.Controllers
{
    [AccessControl("SystemProfile")]
    [Route("api/[controller]")]
    [ApiController]
    public class SystemProfileController : ControllerBase
    {
        private readonly ISystemProfileAppService _systemProfileAppService;

        private readonly ILogger<SystemProfileController> _logger;

        public SystemProfileController(ISystemProfileAppService systemProfileAppService, ILogger<SystemProfileController> logger)
        {
            _systemProfileAppService = systemProfileAppService;

            _logger = logger;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult GetAll(int pageNumber = 1, int recordNumbers = 10)
        {
            try
            {
                return Ok(_systemProfileAppService.GetAll(pageNumber, recordNumbers));
            }
            catch(BusisnessException ex)
            {
                return BadRequest(new { Erros = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(new { Errors = $"Erro não catalogado. Entre em contato com Administrador. Erro - {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        [Route("ObterPorId")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _systemProfileAppService.GetById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
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
        [Route("ObterPorNome")]
        public IActionResult GetByName(string value, int pageNumber = 1, int recordNumbers = 10)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return BadRequest(new { Error = "Parametro é obrigatório" });

                var result = _systemProfileAppService.GetByName(value, pageNumber, recordNumbers);

                if (result == null)
                    return NotFound();

                return Ok(result);
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

        [HttpPost]
        [Route("SalvarPerfil")]
        public IActionResult PostProfile([FromBody] SystemProfileViewModel value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _systemProfileAppService.Save(value);
                    return NoContent();
                }

                return BadRequest(new { Errors = ModelState });
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

        [HttpPut("{id}")]
        [Route("AlterarPerfil")]
        public IActionResult PutProfile(int id, [FromBody] SystemProfileViewModel value)
        {
            try
            {
                var result = _systemProfileAppService.GetById(id);

                if (result == null)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    _systemProfileAppService.Update(value);
                    return NoContent();
                }

                return BadRequest(new { Errors = ModelState });
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

        [HttpDelete("{id}")]
        [Route("RemoverPerfil")]
        public IActionResult DeleteProfile(int id)
        {
            try
            {
                var result = _systemProfileAppService.GetById(id);

                if (result == null)
                    return NotFound();

                _systemProfileAppService.Remove(id);

                return NoContent();
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
