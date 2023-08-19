using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation_NUnitTests.Base
{
    public abstract class TestBase
    {
        [ThreadStatic] public static RestClient Client = new RestClient();

        public static string BASE_URL = "https://reqres.in";

    }

    public static class EndPoints
    {
        public const string LIST_USERS = "/api/users?page={0}";
        public const string SINGLE_USERS = "/api/users/{0}";
        public const string CREATE = "/api/users";
        public const string UPDATE = "/api/users/{0}";
        public const string DELETE = "/api/users/{0}";
    }


}
