using Foodie.Models.ResponseModels;

namespace Foodie.Helper
{
    public interface IDbHelper
    {
        public float GetRestaurantRatingById(int restaurantId);
        public List<int> GetDishIdsByRestaurant(int restaurantId);
        public List<RestaurantDishResponse> GetAllDishByRestaurant(int restaurantId);
        public float GetDishRatingOfUser(int userId, int restaurantId, int dishId);
    }
}
