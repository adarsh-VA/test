using Foodie.Models.DbModels;

namespace Foodie.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User GetById(int id);
    }
}
