using Foodie.Models.DbModels;
using Foodie.Repositories.Interfaces;
using Foodie.Repository;

namespace Foodie.Repositories
{
    public class UserRepository : BaseRepository<User> , IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public User GetById(int id)
        {
            var query = @"SELECT [Id]
                             ,[Name]
                             ,[Age]
                         FROM [Foodie].[dbo].[Users] WITH (NOLOCK)
                         WHERE Id = @Id;";
            return Get(query, new { Id = id });
        }
    }
}
