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


        public List<DishResponse> GetAll()
        {
            var dishes = _dishRepository.GetAll();
            var response = new List<DishResponse>();

            foreach (var dish in dishes)
            {
                response.Add(
                    new DishResponse
                    {
                        Id= dish.Id,
                        Name= dish.Name
                    }
                    );
            }
            return response;
        }
        public DishResponse Get(int id)
        {
            if(id == 0) { throw new ArgumentException("Id should not be zero"); }
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
            if (string.IsNullOrWhiteSpace(dishRequest.Name))
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
