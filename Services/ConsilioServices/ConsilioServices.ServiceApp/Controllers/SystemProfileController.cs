using System;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using Microsoft.AspNetCore.Mvc;

namespace ConsilioServices.ServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemProfileController : ControllerBase
    {
        private readonly ISystemProfileAppService _systemProfileAppService;

        public SystemProfileController(ISystemProfileAppService systemProfileAppService)
        {
            _systemProfileAppService = systemProfileAppService;
        }

        [HttpGet]
        public IActionResult Get(int pageNumber = 1, int recordNumbers = 10)
        {
            try
            {
                return Ok(_systemProfileAppService.GetAll(pageNumber, recordNumbers));
            }
            catch(Exception ex)
            {
                return BadRequest(new { Erros = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _systemProfileAppService.GetById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Erros = ex.Message });
            }
        }

        [HttpGet]
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
            catch(Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] SystemProfileViewModel value)
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
            catch(Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SystemProfileViewModel value)
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
            catch (Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _systemProfileAppService.GetById(id);

                if (result == null)
                    return NotFound();

                _systemProfileAppService.Remove(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }
    }
}
