using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.Server;

namespace WireMockTool_Practice.Base
{
    /// <summary>
    ///  blog post : https://www.ontestautomation.com/api-mocking-in-csharp-with-wiremock-net/
    ///  gitHub: https://github.com/basdijkstra/wiremock-net-examples/tree/main/WireMockNetExamples
    /// </summary>
    public abstract class TestBase
    {
        public static WireMockServer server;
        public RestClient client;
        public const string BASE_URL = "http://localhost:9876";

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [SetUp]
        public void StartServer()
        {
            // This starts a new mock server instance listening at port 9876
            server = WireMockServer.Start(9876);
        }
        [TearDown]
        public void StopServer()
        {
            // This stops the mock server to clean up after ourselves
            server.Stop();
        }
    }
}
