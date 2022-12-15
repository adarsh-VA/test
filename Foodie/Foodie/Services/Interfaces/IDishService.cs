using Foodie.Models.RequestModels;
using Foodie.Models.ResponseModels;

namespace Foodie.Services.Interfaces
{
    public interface IDishService
    {
        public DishResponse Get(int id);
        public int Create(DishRequest dishRequest);
    }
}
