using Foodie.Models.DbModels;
using Foodie.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Tests.MockResources
{
    public class UserMock
    {
        public static readonly Mock<IUserRepository> userMockRepo = new Mock<IUserRepository>();

        private static List<User> _users = new List<User>()
        {
            new User() { Id = 1,Name="U1",Age=18 },
            new User() { Id = 2,Name="U2",Age = 18 }
        };

        public static void MockGetById()
        {
            userMockRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => _users.FirstOrDefault(u => u.Id == id));
        }
    }
}
