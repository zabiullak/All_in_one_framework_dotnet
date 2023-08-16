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
    }
}
