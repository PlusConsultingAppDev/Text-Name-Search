using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTests
{
    [TestClass]
    public class SearchAPITests
    {
        const string ServiceUrl = "http://localhost:51707/api/DocumentSearch";

        [TestMethod]
        public async Task DocumentSearchTest()
        {
            var expectedResult = GetExpectedResult();
            var jsonObjectAsString = GetRequestPayload();
            var content = new StringContent(jsonObjectAsString, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(ServiceUrl, content);
                Assert.IsNotNull(response);
                Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
                var actualResult = await response.Content.ReadAsStringAsync();
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        private static string GetExpectedResult()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            sb.Append(@"{""fullName"":""David Warren Black"",""numberOfOccurrences"":4},");
            sb.Append(@"{""fullName"":""Seth David Greenly"",""numberOfOccurrences"":3},");
            sb.Append(@"{""fullName"":""Connor Gary Smith"",""numberOfOccurrences"":3}");
            sb.Append(@"]");

            return sb.ToString();
        }

        private static string GetRequestPayload()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            sb.Append(@"{ ""firstName"": ""David"", ""lastName"": ""Black"", ""middleName"": ""Warren"" },");
            sb.Append(@"{ ""firstName"": ""Seth"", ""lastName"": ""Greenly"", ""middleName"": ""David"" },");
            sb.Append(@"{ ""firstName"": ""Connor"", ""lastName"": ""Smith"", ""middleName"": ""Gary"" }");
            sb.Append("]");

            return sb.ToString();
        }
    }
}
