using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Controllers
{
    [Route("Restaurants")]
    [ApiController]
    public class RatingsContollers : ControllerBase
    {
        [HttpGet("{restaurantId}/users/{userId}/ratings")]
        public IActionResult GetUserDishRatings([FromRoute] int restaurantId, [FromRoute] int userId)
        {
            return Ok(restaurantId);
        }
    }
}