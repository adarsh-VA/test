using Foodie.Models.ResponseModels;

namespace Foodie.Services.Interfaces
{
    public interface IRatingService
    {
        public void create(int restaurantId, int userId, int dishId, float rating);
        public List<UserRatingResponse> GetAllUserRatings(int userId, int restaurantId);
    }
}
