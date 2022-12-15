using Foodie.Models.DbModels;
using Foodie.Repositories.Interfaces;
using Foodie.Repository;

namespace Foodie.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public Restaurant GetById(int id)
        {
            var query = @"SELECT [Id]
                             ,[Name]
                         FROM [Foodie].[dbo].[Restaurants] WITH (NOLOCK)
                         WHERE Id = @Id;";
            return Get(query, new { Id = id });
        }
    }
}
