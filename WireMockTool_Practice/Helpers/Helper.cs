using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMockTool_Practice.Base;

namespace WireMockTool_Practice.Helpers
{
    public class Helper : TestBase
    {
        public static void CreateHelloWorldStub()
        {
            // This defines a mock API response that responds to an incoming HTTP GET
            // to the `/hello-world` endpoint with a response with HTTP status code 200,
            // a Content-Type header with value `text/plain` and a response body
            // containing the text `Hello, world!`
            server.Given(
                Request.Create().WithPath("/hello-world").UsingGet()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithHeader("Content-Type", "text/plain")
                    .WithBody("Hello, world!")
            );
        }

        public static void CreateStubHeaderMatching()
        {
            server.Given(
                Request.Create().WithPath("/header-matching").UsingGet()
                    // this makes the mock only respond to requests that contain
                    // a 'Content-Type' header with the exact value 'application/json'
                    .WithHeader("Content-Type", new ExactMatcher("application/json"))
                    // this makes the mock only respond to requests that do not contain
                    // the 'ShouldNotBeThere' header
                    .WithHeader("ShouldNotBeThere", ".*", matchBehaviour: MatchBehaviour.RejectOnMatch)
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody("Header matching successful")
            );
        }

        public static void CreateStubRequestBodyMatching()
        {
            server.Given(
                Request.Create().WithPath("/request-body-matching").UsingPost()
                // this makes the mock only respond to requests with a JSON request body
                // that produces a match for the specified JSON path expression
                .WithBody(new JsonPathMatcher("$.cars[?(@.make == 'tata car')]"))
            )
            .RespondWith(
                Response.Create()
                .WithStatusCode(201)
            );
        }

        public static void CreateStubReturningDelayedResponse()
        {
            server.Given(
                Request.Create().WithPath("/delay").UsingGet()
            )
            .RespondWith(
                Response.Create()
                   .WithStatusCode(200)
                   // this returns the response after a 2000ms delay
                   .WithDelay(TimeSpan.FromMilliseconds(2000))
            );
        }

        public static void CreateStubReturningFault()
        {
            server.Given(
                Request.Create().WithPath("/fault").UsingGet()
            )
            .RespondWith(
                Response.Create()
                    // returns a response with HTTP status code 200
                    // and garbage in the response body
                    .WithFault(FaultType.MALFORMED_RESPONSE_CHUNK)
            );
        }


        public static void CreateStatefulStub()
        {
            server.Given(
                Request.Create().WithPath("/todo/items").UsingGet()
            )
            // In this scenario, when the current state is 'TodoList State Started',
            // a call to an HTTP GET will only return 'Buy milk'
           .InScenario("To do list")
           .WillSetStateTo("TodoList State Started")
           .RespondWith(
                Response.Create().WithBody("Buy milk")
           );

            server.Given(
                Request.Create().WithPath("/todo/items").UsingPost()
            )
            // In this scenario, when the current state is 'TodoList State Started',
            // a call to an HTTP POST will trigger a state transition to new state
            // 'Cancel newspaper item added'
            .InScenario("To do list")
            .WhenStateIs("TodoList State Started")
            .WillSetStateTo("Cancel newspaper item added")
            .RespondWith(
                Response.Create().WithStatusCode(201)
            );

            server.Given(
                Request.Create().WithPath("/todo/items").UsingGet()
            )
            // In this scenario, when the current state is 'Cancel newspaper item added',
            // a call to an HTTP GET will return 'Buy milk;Cancel newspaper subscription'
            .InScenario("To do list")
            .WhenStateIs("Cancel newspaper item added")
            .RespondWith(
                Response.Create().WithBody("Buy milk;Cancel newspaper subscription")
            );
        }

        public static void CreateStubEchoHttpMethod()
        {
            server.Given(
                Request.Create().WithPath("/echo-http-method").UsingAnyMethod()
            )
            .RespondWith(
                Response.Create()
                .WithStatusCode(200)
                // The {{request.method}} handlebar extracts the HTTP method from the request
                .WithBody("HTTP method used was {{request.method}}")
                // This enables response templating for this specific mock response
                .WithTransformer()
            );
        }

        public static void CreateStubEchoJsonRequestElement()
        {
            server.Given(
                Request.Create().WithPath("/echo-json-request-element").UsingPost()
            )
            .RespondWith(
                Response.Create()
                .WithStatusCode(200)
                // This extracts the book.title element from the JSON request body
                // (using a JsonPath expression) and repeats it in the response body
                .WithBody("The specified book title is {{JsonPath.SelectToken request.body \"$.book.title\"}}")
                .WithTransformer()
            );
        }
    }
}
