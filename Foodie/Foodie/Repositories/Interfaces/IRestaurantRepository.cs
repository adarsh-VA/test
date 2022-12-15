using Foodie.Models.DbModels;

namespace Foodie.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        public List<Restaurant> GetAll();
        public Restaurant GetById(int id);
        public int Create(Restaurant restaurant, string DishIds);
    }
}
