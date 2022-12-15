using Foodie.Models.RequestModels;
using Foodie.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService= restaurantService;
        }

        [HttpGet("{restaurantId}")]
        public IActionResult GetById([FromRoute] int restaurantId)
        {
            return Ok(_restaurantService.Get(restaurantId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] RestaurantRequest restaurantRequest)
        {
            var id = _restaurantService.Create(restaurantRequest);
            return CreatedAtAction("GetById", new { restaurantId = id }, id);
        }
    }
}
