using Foodie.Models.DbModels;
using Foodie.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Tests.MockResources
{
    public class RatingMock
    {
        public static readonly Mock<IRatingRepository> ratingMockRepo = new Mock<IRatingRepository>();

        private static List<Dish> _dishes = new List<Dish>()
        {
            new Dish() { Id = 1,Name="Samosa"},
            new Dish() { Id = 2,Name="Curd"},
            new Dish() { Id = 3,Name="Chicken"}
        };

        private static List<Tuple<int, int, int, float>> _users_restaurants_dishes = new List<Tuple<int, int, int, float>>
        {
            Tuple.Create(1,1,1,4.0f),
            Tuple.Create(1,1,2,3.5f),
            Tuple.Create(2,2,1,4.0f),
            Tuple.Create(2,2,3,5.0f)
        };
        public static void MockCreate()
        {
            ratingMockRepo.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<float>()));
        }
        public static void MockGet()
        {
            ratingMockRepo.Setup(x => x.GetRatings(It.IsAny<int>(), It.IsAny<int>())).Returns((int userId, int restaurantId) =>
            {
                var userRatingResponse = _users_restaurants_dishes.Where()
            });
        }
    }
}
