using System;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsilioServices.ServiceApp.Controllers
{
    [Authorize]
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
        public IActionResult Get(int pageNumber = 1, int recordNumbers = 10)
        {
            try
            {
                return Ok(_systemUserAppService.GetAll(pageNumber, recordNumbers));
            }
            catch(Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }            
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _systemUserAppService.GetById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }            
        }

        [HttpGet]
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
            catch(Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpPost]
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
            catch(Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpPut("{id}")]
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
            catch(Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpDelete("{id}")]
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
            catch (Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }
        
    }
}
