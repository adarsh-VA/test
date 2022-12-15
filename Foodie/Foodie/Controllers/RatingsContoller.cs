﻿using Foodie.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Controllers
{
    [Route("Restaurants")]
    [ApiController]
    public class RatingsContoller : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingsContoller(IRatingService ratingService)
        {
            _ratingService= ratingService;
        }

        [HttpGet("{restaurantId}/users/{userId}/ratings")]
        public IActionResult GetUserDishRatings([FromRoute] int restaurantId, [FromRoute] int userId) {

            return Ok(_ratingService.GetAllUserRatings(userId,restaurantId));
        }

        [HttpPost("{restaurantId}/users/{userId}/dishes/{dishId}/ratings")]
        public IActionResult CreateUserDishRatings([FromRoute] int restaurantId, [FromRoute] int userId, [FromRoute]int dishId, [FromBody] float rating)
        {
            _ratingService.create(restaurantId, userId, dishId, rating);
            return Ok("You Rated "+rating);
        }
    }
}