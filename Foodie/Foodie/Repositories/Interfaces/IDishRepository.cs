using Foodie.Models.DbModels;

namespace Foodie.Repositories.Interfaces
{
    public interface IDishRepository
    {
        public List<Dish> GetAll();
        public Dish GetById(int id);
        public int Create(Dish dish);
    }
}
