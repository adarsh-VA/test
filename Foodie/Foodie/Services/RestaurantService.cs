using Foodie.Helper;
using Foodie.Models.ResponseModels;
using Foodie.Repositories.Interfaces;
using Foodie.Services.Interfaces;

namespace Foodie.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDbHelper _dbHelper;
        public RestaurantService(IRestaurantRepository restaurantRepository, IDbHelper dbHelper)
        {
            _restaurantRepository = restaurantRepository;
            _dbHelper = dbHelper;
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
            };
            return response;
        }
    }
}
