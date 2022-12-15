using Foodie.Helper;
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
    public class RestaurantMock
    {
        public static readonly Mock<IRestaurantRepository> restaurantMockRepo = new Mock<IRestaurantRepository>();
        public static readonly Mock<IDbHelper> dbHelperMockRepo = new Mock<IDbHelper>();

        private static List<Restaurant> _restaurants = new List<Restaurant>()
        {
            new Restaurant() { Id = 1,Name="ABC" },
            new Restaurant() { Id = 2,Name="EFG" }
        };

        private static Dictionary<int, List<int>> _restaurants_dishes = new Dictionary<int, List<int>>()
        {
            {1,new List<int>{1,2} },
            {2,new List < int > { 1,3} }
        };

        public static void MockGetAll()
        {
            restaurantMockRepo.Setup(x => x.GetAll()).Returns(_restaurants);
        }

        public static void MockGetById()
        {
            restaurantMockRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => _restaurants.FirstOrDefault(r => r.Id == id));
        }
        public static void MockCreate()
        {
            restaurantMockRepo.Setup(x => x.Create(It.IsAny<Restaurant>(), It.IsAny<string>())).Returns((Restaurant restaurant, string dishIds) =>
            {
                return 3;
            });
        }
    }
}
