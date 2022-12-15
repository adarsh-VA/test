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
    [Scope(Feature = "Dish Resource")]
    public class DishSteps : BaseSteps
    {
        public DishSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => DishMock.dishMockRepo.Object);
                });
            }))
        {

        }

        [BeforeScenario]
        public void Mocks()
        {
            DishMock.MockGetAll();
            DishMock.MockGetById();
            DishMock.MockCreate();
        }
    }
}
