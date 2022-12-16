using Foodie.Models.DbModels;
using Foodie.Models.ResponseModels;
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

        private static Dictionary<int, List<int>> _restaurants_dishes = new Dictionary<int, List<int>>()
        {
            {1,new List<int>{1,2} },
            {2,new List < int > { 1,3} }
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
                var restaurantDishes = _restaurants_dishes[restaurantId];
                float myRating = 0;

                var response = new List<UserRatingResponse>();
                foreach (var restaurantDish in restaurantDishes)
                {
                    myRating = _users_restaurants_dishes.FirstOrDefault(x => x.Item1 == userId && x.Item2 == restaurantId).Item4;
                    var dishes = _users_restaurants_dishes.Where(x => x.Item3 == restaurantDish).Select(x => x.Item4).ToList();
                    float avgRating = (dishes.Sum() / dishes.Count);
                    response.Add(
                        new UserRatingResponse
                        {
                            Id = restaurantDish,
                            Name = _dishes.FirstOrDefault(d => d.Id == restaurantDish).Name,
                            MyRating = myRating,
                            AvgRating = avgRating
                        }
                        ) ;
                }
                return response;
            });
        }
    }
}
