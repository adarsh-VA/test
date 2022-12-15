using Foodie.Models.RequestModels;
using Foodie.Models.ResponseModels;

namespace Foodie.Services.Interfaces
{
    public interface IDishService
    {
        public List<DishResponse> GetAll();
        public DishResponse Get(int id);
        public int Create(DishRequest dishRequest);
    }
}
