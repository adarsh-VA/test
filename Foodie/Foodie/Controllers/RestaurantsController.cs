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
        public IActionResult GetUserDishRatings([FromRoute] int restaurantId)
        {
            return Ok(_restaurantService.Get(restaurantId));
        }
    }
}
