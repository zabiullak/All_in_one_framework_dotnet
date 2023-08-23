using API_Automation_NUnitTests.Base;
using API_Automation_NUnitTests.JsonDeserializer;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Automation_NUnitTests.Tests
{
    [TestFixture]
    public class ReqResponseDotcomTests : TestBase
    {
        [Test]
        public async Task GetListUsers()
        {
            var request = new RestRequest(BASE_URL + string.Format(EndPoints.LIST_USERS, 2), Method.Get);
            RestResponse response = await Client.ExecuteAsync(request);
            Assert.That(response.Content, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetSingleUser()
        {
            var request = new RestRequest(BASE_URL + string.Format(EndPoints.SINGLE_USERS, 2), Method.Get);
            RestResponse response = await Client.ExecuteAsync(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.Content, Is.Not.Null.Or.Empty);
                Assert.That(response.Content, Does.Contain("2"));
            });
        }

        string employee_id;
        [Test]
        public async Task CreateUser()
        {
            var request = new RestRequest(BASE_URL + EndPoints.CREATE, Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonConvert.SerializeObject(new
            {
                name = "mohamad",
                job = "qa_tester"
            }));
            RestResponse response = await Client.ExecuteAsync(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.Content, Is.Not.Null.Or.Empty);
                Assert.That(response.Content, Does.Contain("mohamad"));
                Assert.That(response.Content, Does.Contain("qa_tester"));
            });

            employee_id = JsonConvert.DeserializeObject<Employee>(response.Content).id;
        }

        [Test]
        public async Task UpdateUser()
        {
            CreateUser();
            var request = new RestRequest(BASE_URL + string.Format(EndPoints.UPDATE, employee_id), Method.Put);

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonConvert.SerializeObject(new
            {
                name = "mohamad",
                job = "test_automation_developer"
            }));
            RestResponse response = await Client.ExecuteAsync(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.Content, Is.Not.Null.Or.Empty);
                Assert.That(response.Content, Does.Contain("mohamad"));
                Assert.That(response.Content, Does.Contain("test_automation_developer"));
            });
        }

        [Test]
        public async Task DeleteUser()
        {
            CreateUser();
            var request = new RestRequest(BASE_URL + string.Format(EndPoints.DELETE, employee_id), Method.Delete);

            RestResponse response = await Client.ExecuteAsync(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.Content, Is.Null.Or.Empty);
                Assert.That(Convert.ToInt32(response.StatusCode), Is.EqualTo(204));
            });
        }
    }
}
