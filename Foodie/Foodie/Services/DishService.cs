using Foodie.Models.DbModels;
using Foodie.Models.RequestModels;
using Foodie.Models.ResponseModels;
using Foodie.Repositories.Interfaces;
using Foodie.Services.Interfaces;

namespace Foodie.Services
{
    public class DishService : IDishService
    {
        private IDishRepository _dishRepository;
        public DishService(IDishRepository dishRepository)
        {
            _dishRepository= dishRepository;
        }

        public DishResponse Get(int id)
        {
            var dish = _dishRepository.GetById(id);

            if (dish == null) { throw new KeyNotFoundException("Dish Not Found!"); }

            return new DishResponse
            {
                Id = dish.Id,
                Name = dish.Name,
            };
        }

        public int Create(DishRequest dishRequest)
        {
            if (dishRequest.Name == "")
                throw new ArgumentException("Name Should Not be Empty!");
            var dish = new Dish
            {
                Name = dishRequest.Name,
            };
            var id = _dishRepository.Create(dish);
            return id;
        }
    }
}
