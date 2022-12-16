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
    public class DishMock
    {
        public static readonly Mock<IDishRepository> dishMockRepo = new Mock<IDishRepository>();

        private static List<Dish> _dishes = new List<Dish>()
        {
            new Dish() { Id = 1,Name="Samosa"},
            new Dish() { Id = 2,Name="Curd"},
            new Dish() { Id = 3,Name="Chicken"}
        };
        public static void MockGetAll()
        {
            dishMockRepo.Setup(x => x.GetAll()).Returns(_dishes);
        }

        public static void MockGetById()
        {
            dishMockRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => _dishes.FirstOrDefault(d => d.Id == id));
        }
        public static void MockCreate()
        {
            dishMockRepo.Setup(x => x.Create(It.IsAny<Dish>())).Returns((Dish dish) =>
            {
                dish.Id = _dishes.Max(d => d.Id) + 1;

                return dish.Id;
            });
        }

    }
}
