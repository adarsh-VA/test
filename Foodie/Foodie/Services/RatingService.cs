using Foodie.Helper;
using Foodie.Models.ResponseModels;
using Foodie.Repositories.Interfaces;
using Foodie.Services.Interfaces;

namespace Foodie.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDbHelper _dbHelper;
        private readonly IUserRepository _userRepository;
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRestaurantRepository restaurantRepository, IUserRepository userRepository, IDbHelper dbHelper, IRatingRepository ratingRepository)
        {
            _restaurantRepository = restaurantRepository;
            _userRepository = userRepository;
            _dbHelper = dbHelper;
            _ratingRepository = ratingRepository;
        }


        public List<UserRatingResponse> GetAllUserRatings(int userId,int restaurantId)
        {
            var restaurant = _restaurantRepository.GetById(restaurantId);
            if (restaurant == null) { throw new KeyNotFoundException("Restaurant Not Found!"); }

            var user = _userRepository.GetById(userId);
            if (user == null) { throw new KeyNotFoundException("User Not Found!"); }

            var response = _ratingRepository.GetRatings(userId, restaurantId);
            if(response.Count == 0) { throw new KeyNotFoundException("No Ratings Found!"); }
            return response;
        }

        public void create(int restaurantId,int userId,int dishId,float rating)
        {
            if (restaurantId == 0) throw new ArgumentException("Restaurant Id should not be Zero");
            else if (userId == 0) throw new ArgumentException("User Id should not be Zero");
            else if (dishId == 0) throw new ArgumentException("Dish Id should not be Zero");
            else if (rating <= 0 || rating > 5) throw new ArgumentException("Rating should be in 1 to 5");

            var restaurant = _restaurantRepository.GetById(restaurantId);
            if( restaurant == null ) { throw new KeyNotFoundException("Restaurant Not Found!"); }

            var user = _userRepository.GetById(userId);
            if( user == null ) { throw new KeyNotFoundException("User Not Found!"); }

            if (_dbHelper.GetDishIdsByRestaurant(restaurantId).Contains(dishId) != true) { throw new KeyNotFoundException("Dish Not Found!"); }
            if(_dbHelper.GetDishRatingOfUser(userId, restaurantId,dishId) != 0) { throw new ArgumentException("You Have Already Rated!"); }

            _ratingRepository.Create(restaurantId, userId, dishId, rating);
        }
    }
}
