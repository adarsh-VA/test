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
    [Scope(Feature = "Rating Resource")]
    public class RatingSteps : BaseSteps
    {
        public RatingSteps(CustomWebApplicationFactory factory)
          : base(factory.WithWebHostBuilder(builder =>
          {
              builder.ConfigureServices(services =>
              {
                  services.AddScoped(_ => RatingMock.ratingMockRepo.Object);
                  services.AddScoped(_ => DbHelperMock.dbHelperMockRepo.Object);
              });
          }))
        {

        }

        [BeforeScenario]
        public void Mocks()
        {
            RatingMock.MockGet();
            RatingMock.MockCreate();
            DbHelperMock.MockDbHelper();
        }
    }
}
