using Dapper;
using Foodie.Models.ResponseModels;
using Microsoft.Data.SqlClient;

namespace Foodie.Helper
{
    public class DbHelper : IDbHelper
    {
        private string _connectionString;
        public DbHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FoodieDB");
        }

        public float GetRestaurantRatingById(int restaurantId)
        {
            var restaurantQuery = @"SELECT cast((SUM(DishAvg.RATING) / COUNT(DishAvg.RATING)) AS DECIMAL(2, 1)) AS Rating
                                    FROM (
                                    	SELECT AVG(URD.Rating) AS RATING
                                    	FROM Restaurants_Dishes RD
                                    	JOIN Users_Restaurants_Dishes URD ON RD.RestaurantId = URD.RestaurantId
                                    		AND RD.DishId = URD.DishId
                                    	WHERE RD.RestaurantId = @Id
                                    	) AS DishAvg;";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<float>(restaurantQuery, new { Id = restaurantId });
            }
        }

        public List<int> GetDishIdsByRestaurant(int restaurantId)
        {
            var restaurantQuery = @"SELECT DishId
                                    FROM Restaurants_Dishes
                                    WHERE RestaurantId = @Id;";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<int>(restaurantQuery, new { Id = restaurantId }).ToList();
            }
        }

        public List<RestaurantDishResponse> GetAllDishByRestaurant(int restaurantId)
        {
            var restaurantQuery = @"SELECT D.Id
                                    	,D.Name
                                    	,(
                                    		SELECT AVG(Rating)
                                    		FROM Users_Restaurants_Dishes
                                    		WHERE DishId = D.Id
                                    			AND RestaurantId = @RestaurantId
                                    		GROUP BY DishId
                                    		) AS AvgRating
                                    FROM Dishes D
                                    JOIN Restaurants_Dishes RD ON RD.DishId = D.Id
                                    WHERE RD.RestaurantId = @RestaurantId;";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<RestaurantDishResponse>(restaurantQuery, new { RestaurantId = restaurantId }).ToList();
            }
        }

        public float GetDishRatingOfUser(int userId,int restaurantId,int dishId)
        {
            var query = @"SELECT Rating
                          FROM Users_Restaurants_Dishes
                          WHERE UserId = @UserId
                          	AND RestaurantId = @RestaurantId
                          	AND DishId = @DishId;";
            float result = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                result = connection.ExecuteScalar<int>(query, new {UserId = userId,RestaurantId = restaurantId,DishId = dishId});
            }
            return result;
        }
    }
}
