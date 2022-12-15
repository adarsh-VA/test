using Dapper;
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
                                    		,URD.DishId
                                    	FROM Restaurants_Dishes RD
                                    	JOIN Users_Restaurants_Dishes URD ON RD.RestaurantId = URD.RestaurantId
                                    		AND RD.DishId = URD.DishId
                                    	WHERE RD.RestaurantId = @Id
                                    	GROUP BY URD.DishId
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
    }
}
