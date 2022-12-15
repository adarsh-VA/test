using Dapper;
using Foodie.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Foodie.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private string _connectionString;

        public RatingRepository(IConfiguration configuration)
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
    }
}
