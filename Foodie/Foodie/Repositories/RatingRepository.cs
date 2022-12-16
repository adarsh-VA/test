using Dapper;
using Foodie.Models.DbModels;
using Foodie.Models.ResponseModels;
using Foodie.Repositories.Interfaces;
using Foodie.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Foodie.Repositories
{
    public class RatingRepository : BaseRepository<UserRatingResponse> , IRatingRepository 
    {
        public RatingRepository(IConfiguration configuration):base(configuration)
        {
        }

        public void Create(int restaurantId, int userId, int dishId, float rating)
        {
            var query = @"INSERT INTO Users_Restaurants_Dishes (
                            	UserId
                            	,RestaurantId
                            	,DishId
                            	,Rating
                            	)
                            VALUES (
                            	@UserId
                            	,@RestaurantId
                            	,@DishId
                            	,@Rating
                            	);";

            ExecuteQuery(query, new { UserId = userId, RestaurantId = restaurantId, DishId = dishId, Rating = rating });
        }

        public List<UserRatingResponse> GetRatings(int userId, int restaurantId)
        {

            var query = @"SELECT D.Id
                           	,Name
                           	,Rating AS MyRating
                           	,(
                           		SELECT AVG(Rating)
                           		FROM Users_Restaurants_Dishes
                           		WHERE DishId = D.Id
                           			AND RestaurantId = @RestaurantId
                           		) AS AvgRating
                           FROM Dishes D
                           JOIN Restaurants_Dishes RD ON RD.DishId = D.Id
                           LEFT JOIN Users_Restaurants_Dishes URD ON URD.DishId = RD.DishId
                           AND URD.RestaurantId = RD.RestaurantId
                           AND UserId = @UserId
                           WHERE RD.RestaurantId = @RestaurantId;";

            return GetWithValue(query, new { RestaurantId = restaurantId, UserId = userId });
        }
    }
}
