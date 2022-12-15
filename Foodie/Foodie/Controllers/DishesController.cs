using Foodie.Models.RequestModels;
using Foodie.Services;
using Foodie.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Controllers
{
    [Route("dishes")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishService _dishService;
        public DishesController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dishService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_dishService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] DishRequest dishRequest)
        {
            var id = _dishService.Create(dishRequest);
            return CreatedAtAction("GetById", new { Id = id }, id);
        }
    }
}
