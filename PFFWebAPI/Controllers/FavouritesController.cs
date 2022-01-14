using Microsoft.AspNetCore.Mvc;
using PFFWebAPI.Data;
using PFFWebAPI.Models;

namespace PFFWebAPI.Controllers
{
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private IFavouritesData _favouritesData;

        public FavouritesController(IFavouritesData favouritesData)
        {
            _favouritesData = favouritesData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPresents()
        {
            return Ok(_favouritesData.GetFavourites());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetFavourites(int id)
        {
            var present = _favouritesData.GetFavourites(id);
            if (present != null)
                return Ok(_favouritesData.GetFavourites(id));
            return NotFound($"Present with ID: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddPresent(Favourites favourites)
        {
            _favouritesData.AddFavourites(favourites);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                           + HttpContext.Request.Path + "/" + favourites.Id, favourites);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeletePresent(int id)
        {
            var favourites = _favouritesData.GetFavourites(id);
            if (favourites != null)
            {
                _favouritesData.DeleteFavourites(favourites);
                return Ok();
            }

            return NotFound($"Favourites with ID: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditPresent(int id, Favourites favourites)
        {
            var existingFavourites = _favouritesData.GetFavourites(id);
            if (existingFavourites != null)
            {
                favourites.Id = existingFavourites.Id;
                _favouritesData.EditFavourites(favourites);
            }

            return Ok(favourites);
        }
    }
}
