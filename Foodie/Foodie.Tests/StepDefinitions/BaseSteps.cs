using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Tests.StepDefinitions
{
    public class BaseSteps
    {
        protected WebApplicationFactory<TestStartup> Factory;
        protected HttpClient Client { get; set; }
        protected HttpResponseMessage Response { get; set; }

        public BaseSteps(WebApplicationFactory<TestStartup> baseFactory)
        {
            Factory = baseFactory;
        }

        [Given(@"I am a client")]
        public void ImClient()
        {
            Client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost/")
            });
        }

        [When(@"I make GET Request '(.*)'")]
        public virtual async Task MakeGet(string resourceEndpoint)
        {
            var uri = new Uri(resourceEndpoint, UriKind.Relative);
            Response = await Client.GetAsync(uri);
        }

        [Then(@"response code must be '(.*)'")]
        public void ResponseCompare(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }

        [Then(@"response data must look like '(.*)'")]
        public async void ThenResponseDataMustLookLike(string expected)
        {
            var responseData = await Response.Content.ReadAsStringAsync();
            string response = responseData;
            
            Assert.Equal(expected, response);
        }

        [When(@"I make POST Request '([^']*)' with following data '([^']*)'")]
        public virtual async Task WhenIMakePOSTRequestWithFollowingData(string endpoint, string data)
        {
            var uri = new Uri(endpoint, UriKind.Relative);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            Response = await Client.PostAsync(uri, content);
        }
    }
}
