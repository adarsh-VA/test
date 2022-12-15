using Foodie.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Restaurant Resource")]
    public class RestaurantSteps : BaseSteps
    {
        public RestaurantSteps(CustomWebApplicationFactory factory)
           : base(factory.WithWebHostBuilder(builder =>
           {
               builder.ConfigureServices(services =>
               {
                   services.AddScoped(_ => RestaurantMock.restaurantMockRepo.Object);
                   services.AddScoped(_ => DbHelperMock.dbHelperMockRepo.Object);
               });
           }))
        {

        }

        [BeforeScenario]
        public void Mocks()
        {
            RestaurantMock.MockGetAll();
            RestaurantMock.MockGetById();
            RestaurantMock.MockCreate();
            DbHelperMock.MockDbHelper();
        }
    }
}
