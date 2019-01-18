using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTests.EmployeeSearchConfigApiTests
{
    [TestClass]
    public class EmployeeSearchConfigApiTests
    {
        const string ServiceUrl = "http://localhost:53808/api/EmployeeSearch";

        [TestMethod]
        public async Task EmployeeConfigPostTest()
        {
            // var expectedResult = GetExpectedResult();
            var jsonObjectAsString = GetRequestPayload();
            var content = new StringContent(jsonObjectAsString, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(ServiceUrl, content);
                Assert.IsNotNull(response);
                Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
                var actualResult = await response.Content.ReadAsStringAsync();
                Assert.IsNotNull(actualResult);
            }
        }

        private static string GetRequestPayload()
        {
            return @"{id:0, firstName:""Luke"", lastName:""Skywalker"", middleInitial:""Jedi""}";
        }

    }
}
