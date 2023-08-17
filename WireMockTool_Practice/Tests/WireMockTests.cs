using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
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

        [Test]
        public async Task TestStubDelay()
        {
            Helper.CreateStubReturningDelayedResponse();

            RestRequest request = new RestRequest("/delay", Method.Get);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RestResponse response = await client.ExecuteAsync(request);

            stopwatch.Stop();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(2000));
        }

        [Test]
        public async Task TestStubFault()
        {
            Helper.CreateStubReturningFault();

            RestRequest request = new RestRequest("/fault", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.Throws<JsonReaderException>(() => JObject.Parse(response.Content));
        }


        [Test]
        public async Task TestStatefulStub()
        {
            Helper.CreateStatefulStub();

            RestRequest request = new RestRequest("/todo/items", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.Content, Is.EqualTo("Buy milk"));

            request = new RestRequest("/todo/items", Method.Post);

            response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            request = new RestRequest("/todo/items", Method.Get);

            response = await client.ExecuteAsync(request);

            Assert.That(response.Content, Is.EqualTo("Buy milk;Cancel newspaper subscription"));
        }

        [TestCase(Method.Get, "GET", TestName = "Check that GET method is echoed successfully")]
        [TestCase(Method.Post, "POST", TestName = "Check that POST method is echoed successfully")]
        [TestCase(Method.Delete, "DELETE", TestName = "Check that DELETE method is echoed successfully")]
        public async Task TestStubEchoHttpMethod(Method method, string expectedResponseMethod)
        {
            Helper.CreateStubEchoHttpMethod();

            RestRequest request = new RestRequest("/echo-http-method", method);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.EqualTo($"HTTP method used was {expectedResponseMethod}"));
        }

        [TestCase("Pillars of the Earth", "Ken Follett", TestName = "Check for Pillars of the Earth")]
        [TestCase("The Secret History", "Donna Tartt", TestName = "Check for The Secret History")]
        public async Task TestStubEchoRequestJSONBodyElementValue(string title, string author)
        {
            Helper.CreateStubEchoJsonRequestElement();

            var requestBody = new
            {
                book = new
                {
                    title = title,
                    author = author
                }
            };

            RestRequest request = new RestRequest("/echo-json-request-element", Method.Post);

            request.AddJsonBody(requestBody);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.EqualTo($"The specified book title is {title}"));
        }
    }
}