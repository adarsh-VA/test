using Foodie.Helper;
using Foodie.Models.DbModels;
using Foodie.Models.RequestModels;
using Foodie.Models.ResponseModels;
using Foodie.Repositories.Interfaces;
using Foodie.Services.Interfaces;

namespace Foodie.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDbHelper _dbHelper;
        private readonly IDishRepository _dishRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository, IDbHelper dbHelper, IDishRepository dishRepository)
        {
            _restaurantRepository = restaurantRepository;
            _dbHelper = dbHelper;
            _dishRepository = dishRepository;
        }

        public List<int> validateDishes(string dishIds)
        {
            if (dishIds == "")
                throw new ArgumentException("ActorsId should not be Empty");

            int dId;
            var MappedDishIds = new List<int>();

            foreach (var d in dishIds.Split(','))
            {
                try
                {
                    dId = Convert.ToInt32(d);
                }
                catch (System.Exception)
                {
                    throw new ArgumentException("Actor Id Format Error!");
                }
                if (_dishRepository.GetById(dId) == null)
                    throw new KeyNotFoundException("Actor Not Found!");
                MappedDishIds.Add(dId);
            }
            return MappedDishIds;
        }

        public RestaurantResponse Get(int id)
        {
            var restaurent = _restaurantRepository.GetById(id);
            if (id == 0)
                throw new ArgumentException("Id should not be Zero");
            if (restaurent == null)
                throw new KeyNotFoundException("Restaurant Not Found!");

            var response = new RestaurantResponse
            {
                Id= id,
                Name= restaurent.Name,
                Rating = _dbHelper.GetRestaurantRatingById(id),
                Dishes = _dbHelper.GetAllDishByRestaurant(id)
            };
            return response;
        }

        public int Create(RestaurantRequest restaurantRequest)
        {
            validateDishes(restaurantRequest.DishIds);

            var restaurant = new Restaurant
            {
                Name = restaurantRequest.Name
            };

            
            return _restaurantRepository.Create(restaurant, restaurantRequest.DishIds);
        }
    }
}
