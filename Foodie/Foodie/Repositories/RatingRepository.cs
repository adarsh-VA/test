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
        private string _connectionString;

        public RatingRepository(IConfiguration configuration):base(configuration)
        {
            _connectionString = configuration.GetConnectionString("FoodieDB");
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

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new {UserId = userId,RestaurantId = restaurantId,DishId = dishId,Rating = rating});
            }
        }

        public List<UserRatingResponse> GetRatings(int userId, int restaurantId)
        {

            var query = @"SELECT D.Id AS Id
                           	,D.Name AS Name
                           	,URD.Rating AS MyRating
                           	,(
                           		SELECT AVG(Rating)
                           		FROM Users_Restaurants_Dishes
                           		WHERE DishId = D.Id
                           			AND RestaurantId = @RestaurantId
                           		GROUP BY DishId
                           		) AS AvgRating
                           FROM Dishes D
                           JOIN Users_Restaurants_Dishes URD ON URD.DishId = D.Id
                           WHERE URD.UserId = @UserId
                           	AND URD.RestaurantId = @RestaurantId;";

            return GetWithValue(query, new { RestaurantId = restaurantId, UserId = userId });
        }
    }
}
