namespace Foodie.Helper
{
    public interface IDbHelper
    {
        public float GetRestaurantRatingById(int restaurantId);
        public List<int> GetDishIdsByRestaurant(int restaurantId);
    }
}
