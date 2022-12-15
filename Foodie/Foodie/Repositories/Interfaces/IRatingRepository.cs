using Foodie.Models.ResponseModels;

namespace Foodie.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        public void Create(int restaurantId, int userId, int dishId, float rating);
        public List<UserRatingResponse> GetRatings(int userId, int restaurantId);
    }
}
