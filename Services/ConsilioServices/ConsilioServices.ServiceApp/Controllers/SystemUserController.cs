﻿using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Exceptions;
using ConsilioServices.Infrastructure.CrossCutting.AccessControl;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ConsilioServices.ServiceApp.Controllers
{
    [EnableCors("DefaultPolicy")]
    [AccessControl("SystemUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserController : ControllerBase
    {
        private readonly ISystemUserAppService _systemUserAppService;

        private readonly ILogger<SystemUserController> _logger;

        public SystemUserController(ISystemUserAppService systemUserAppService, ILogger<SystemUserController> logger)
        {
            _systemUserAppService = systemUserAppService;

            _logger = logger;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult GetAll(int pageNumber = 1, int recordNumbers = 10)
        {
            try
            {
                return Ok(_systemUserAppService.GetAll(pageNumber, recordNumbers));
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

        [HttpGet("{id}")]
        [Route("ObterPorId")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _systemUserAppService.GetById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (BusisnessException ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(new { Errors = $"Erro não catalogado. Entre em contato com Administrador. Erro - {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("ObterPorNome")]
        public IActionResult GetByName(string name, int pageNumber = 1, int recordNumbers = 10)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return BadRequest(new { Error = "Parametro é obrigatório" });

                var result = _systemUserAppService.GetByName(name, pageNumber, recordNumbers);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (BusisnessException ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest(new { Errors = $"Erro não catalogado. Entre em contato com Administrador. Erro - {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("SalvarUsuario")]
        public IActionResult PostUser([FromBody]SystemUserViewModel  value)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _systemUserAppService.Save(value);
                    return NoContent();
                }
                
                return BadRequest(new { Errors = ModelState });
                
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

        [HttpPut]
        [Route("AlterarUsuario")]
        public IActionResult PutUser(int id, [FromBody] SystemUserViewModel value)
        {
            try
            {
                var result = _systemUserAppService.GetById(id);

                if (result == null)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    _systemUserAppService.Update(value);
                    return NoContent();
                }

                return BadRequest(new { Errors = ModelState });
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

        [HttpDelete]
        [Route("RemoverUsuario")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var result = _systemUserAppService.GetById(id);

                if (result == null)
                    return NotFound();

                _systemUserAppService.Remove(id);

                return NoContent();
            }
            catch (BusisnessException ex)
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
