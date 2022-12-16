using Foodie.Helper;
using Foodie.Models.DbModels;
using Foodie.Models.ResponseModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Tests.MockResources
{
    public class DbHelperMock
    {
        public static readonly Mock<IDbHelper> dbHelperMockRepo = new Mock<IDbHelper>();

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
           /*UserId,RestaurantId,DishId,Rating*/

            Tuple.Create(1,1,1,4.0f),
            Tuple.Create(1,1,2,3.5f),
            Tuple.Create(2,2,1,4.0f),
            Tuple.Create(2,2,3,5.0f)
        };

        public static void MockDbHelper()
        {
            dbHelperMockRepo.Setup(x => x.GetAllDishByRestaurant(It.IsAny<int>())).Returns((int restaurantId) =>
            {
                var restaurantDishes = _users_restaurants_dishes.Where(x => x.Item2 == restaurantId);
                var restaurantResponse = new List<RestaurantDishResponse>();

                foreach (var restaurantDish in restaurantDishes)
                {
                    var dishRatings = restaurantDishes.Where(x => x.Item3 == restaurantDish.Item3).Select(x=>x.Item4).ToList();
                    float avgRating = (dishRatings.Sum() / dishRatings.Count);
                    restaurantResponse.Add(
                        new RestaurantDishResponse
                        {
                            Id = restaurantDish.Item3,
                            Name = _dishes.FirstOrDefault(d=>d.Id==restaurantDish.Item3).Name,
                            AvgRating = avgRating
                        }
                        );
                }
                return restaurantResponse;
            });

            dbHelperMockRepo.Setup(x => x.GetRestaurantRatingById(It.IsAny<int>())).Returns((int restaurantId) =>
            {
                var restaurantDishes = _restaurants_dishes[restaurantId];
                var restaurantDishesRatings = _users_restaurants_dishes.Where(x => x.Item2 == restaurantId);
                var avgRatings =new  List<float>();
                foreach (var dishId in restaurantDishes)
                {
                    var dishRatings = restaurantDishesRatings.Where(x => x.Item3 == dishId && x.Item2 == restaurantId).Select(x => x.Item4).ToList();
                     avgRatings.Add((dishRatings.Sum() / dishRatings.Count));
                }
                return avgRatings.Sum() / avgRatings.Count;
            });

            dbHelperMockRepo.Setup(x => x.GetDishIdsByRestaurant(It.IsAny<int>())).Returns((int restaurantId) =>
            {
                return _restaurants_dishes[restaurantId];
            });

            dbHelperMockRepo.Setup(x=>x.GetDishRatingOfUser(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns((int userId, int restaurantId, int dishId) =>
            {
                return 0;
            });
        }
            
    }
}
