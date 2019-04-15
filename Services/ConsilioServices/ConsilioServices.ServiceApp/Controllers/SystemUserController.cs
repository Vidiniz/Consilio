using System;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Exceptions;
using ConsilioServices.Infrastructure.CrossCutting.AccessControl;
using Microsoft.AspNetCore.Mvc;

namespace ConsilioServices.ServiceApp.Controllers
{
    [AccessControl("SystemUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserController : ControllerBase
    {
        private readonly ISystemUserAppService _systemUserAppService;

        public SystemUserController(ISystemUserAppService systemUserAppService)
        {
            _systemUserAppService = systemUserAppService;
        }

        [HttpGet]
        [ActionName("ObterTodos")]
        public IActionResult Get(int pageNumber = 1, int recordNumbers = 10)
        {
            try
            {
                return Ok(_systemUserAppService.GetAll(pageNumber, recordNumbers));
            }
            catch(BusisnessException ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
            catch(Exception ex)
            {
                // TODO: Implementar log
                return BadRequest(new { Errors = ex.Message });
            }            
        }

        [HttpGet("{id}")]
        [ActionName("ObterPorId")]
        public IActionResult Get(int id)
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
                // TODO: Implementar log
                return BadRequest(new { Errors = ex.Message });
            }            
        }

        [HttpGet]
        [ActionName("ObterPorNome")]
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
                // TODO: Implementar log
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpPost]
        [ActionName("SalvarUsuario")]
        public IActionResult Post([FromBody]SystemUserViewModel  value)
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
            catch(Exception ex)
            {
                // TODO: Implementar log
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ActionName("AlterarUsuario")]
        public IActionResult Put(int id, [FromBody] SystemUserViewModel value)
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
            catch(Exception ex)
            {
                // TODO: Implementar log
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ActionName("RemoverUsuario")]
        public IActionResult Delete(int id)
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
                // TODO: Implementar log
                return BadRequest(new { Errors = ex.Message });
            }
        }
        
    }
}
