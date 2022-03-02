using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft;
//using Newtonsoft.Json.JsonConvert;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace TestProject1
{
    [TestClass]

    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange -
            // - Setup REST client
            RestClient client = new RestClient("https://digitalapi.auspost.com.au");

            // - setup Rest request
            string apiKey = "2b8a3246-3dfc-412b-9837-6f713f2970ea";
            RestRequest request = new RestRequest("postcode/search.json");
            request.AddHeader("auth-key", apiKey).
                AddParameter("q", "Paralowie").
                AddParameter("state", "SA");

            // Act -
            // - Execute request
            Task<RestResponse> response = client.ExecuteAsync(request);

            // Assert -
            // - response content (dynamic for now, not really maintainable)
            //Console.WriteLine(response.ToString() );

            string jsonBody = response.Result.Content;
            Auspost_PCSearch pcresult = (Auspost_PCSearch)JsonConvert.DeserializeObject<Auspost_PCSearch>(jsonBody);
            //dynamic jsonResponse = JsonConvert.DeserializeObject(jsonBody);

            // - Assert the postcode
            //Assert.IsTrue(jsonResponse.localities.locality.postcode == 5108);
            Assert.AreEqual(pcresult.localities.locality.postcode, 5108);
        }
    }

}
