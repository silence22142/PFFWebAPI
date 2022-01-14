using Microsoft.AspNetCore.Mvc;
using PFFWebAPI.Data;
using PFFWebAPI.Models;

namespace PFFWebAPI.Controllers
{

    [ApiController]
    public class PresentsController : ControllerBase
    {
        private IPresentData _presentData;

        public PresentsController(IPresentData presentData)
        {
            _presentData = presentData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPresents()
        {
            return Ok(_presentData.GetPresents());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPresent(int id)
        {
            var present = _presentData.GetPresent(id);
            if (present != null)
                return Ok(_presentData.GetPresent(id));
            return NotFound($"Present with ID: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddPresent(Present present)
        {
            _presentData.AddPresent(present);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                           + HttpContext.Request.Path + "/" + present.Id, present);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeletePresent(int id)
        {
            var present = _presentData.GetPresent(id);
            if (present != null)
            {
                _presentData.DeletePresent(present);
                return Ok();
            }

            return NotFound($"Present with ID: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditPresent(int id, Present present)
        {
            var existingPresent = _presentData.GetPresent(id);
            if (existingPresent != null)
            {
                present.Id = existingPresent.Id;
                _presentData.EditPresent(present);
            }

            return Ok(present);
        }
    }
}