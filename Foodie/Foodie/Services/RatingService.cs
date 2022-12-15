using Foodie.Helper;
using Foodie.Repositories.Interfaces;
using Foodie.Services.Interfaces;

namespace Foodie.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDbHelper _dbHelper;
        private readonly IUserRepository _userRepository;
        public RatingService(IRestaurantRepository restaurantRepository, IUserRepository userRepository, IDbHelper dbHelper)
        {
            _restaurantRepository= restaurantRepository;
            _userRepository = userRepository;
            _dbHelper = dbHelper;
        }

        public void create(int restaurantId,int userId,int dishId,float rating)
        {
            if (restaurantId == 0) throw new ArgumentException("Restaurant Id should not be Zero");
            else if (userId == 0) throw new ArgumentException("User Id should not be Zero");
            else if (dishId == 0) throw new ArgumentException("Dish Id should not be Zero");
            
            var restaurant = _restaurantRepository.GetById(restaurantId);
            if( restaurant == null ) { throw new KeyNotFoundException("Restaurant Not Found!"); }

            var user = _userRepository.GetById(userId);
            if( user == null ) { throw new KeyNotFoundException("User Not Found!"); }

            if (_dbHelper.GetDishIdsByRestaurant(restaurantId).Contains(dishId) == null) { throw new KeyNotFoundException("Dish Not Found!"); }
        }
    }
}
