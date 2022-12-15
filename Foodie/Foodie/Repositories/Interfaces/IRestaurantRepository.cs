using Foodie.Models.DbModels;

namespace Foodie.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        public Restaurant GetById(int id);
    }
}
