using Foodie.Models.DbModels;
using Foodie.Repositories.Interfaces;
using Foodie.Repository;
using System.Runtime.InteropServices;

namespace Foodie.Repositories
{
    public class DishRepository : BaseRepository<Dish> , IDishRepository 
    {
        public DishRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Dish GetById(int id)
        {
            var query = @"SELECT [Id]
                             ,[Name]
                         FROM [Foodie].[dbo].[Dishes] WITH (NOLOCK)
                         WHERE Id = @Id;";
            return Get(query, new { Id = id });
        }

        public int Create(Dish dish)
        {
            return Add("[usp_AddDish]", new { Name = dish.Name });
        }
    }
}
