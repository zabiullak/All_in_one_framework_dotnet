using RestSharp;
using System.Net;
using WireMock.Server;
using WireMockTool_Practice.Base;
using WireMockTool_Practice.Helpers;

namespace WireMockTool_Practice.Tests
{
    public class WireMockTests : TestBase
    {

        [Test]
        public async Task TestHelloWorldStub()
        {
            // This creates the mock API response we defined earlier
            Helper.CreateHelloWorldStub();

            // Define the HTTP request to be sent
            //client = new RestClient("http://localhost:9876");

            RestRequest request = new RestRequest("/hello-world", Method.Get);

            // Send the HTTP request to the mock server
            RestResponse response = await client.ExecuteAsync(request);

            // Check that the response returned by the mock server contains the expected properties
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo("text/plain"));
            Assert.That(response.Content, Is.EqualTo("Hello, world!"));
        }

        [Test]
        public async Task TestStubHeaderMatching()
        {
            Helper.CreateStubHeaderMatching();
            //client = new RestClient("http://localhost:9876");

            RestRequest request = new RestRequest("/header-matching", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.EqualTo("Header matching successful"));
        }

        [Test]
        public async Task TestStubRequestBodyMatching()
        {
            Helper.CreateStubRequestBodyMatching();
            //client = new RestClient("http://localhost:9876");
            var requestBody = new
            {
                cars = new[]
                {
                    new { make = "tata car" },
                    new { make = "suzuki" }
                }.ToList()
            };

            RestRequest request = new RestRequest("/request-body-matching", Method.Post);

            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(requestBody);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}