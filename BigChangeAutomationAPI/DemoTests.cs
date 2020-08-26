using NUnit.Framework;
using RestSharp;
using System.Net;

namespace BigChangeAutomationAPI
{

    public class DemoTests
    {
        private IRestClient _restClient;
        private static string code = "LS15 8ZB";
        private static string BaseUrl = "https://api.postcodes.io/postcodes/";

        [SetUp]
        public void Setup()
        {
            _restClient = new RestClient(BaseUrl);
        }

        [Test]
        public void LookUpCode()
        {
            var request = new RestRequest($"{code}/", Method.GET);

            var response = _restClient.Execute(request);

            /// Required Refactoring. Possble to use DTO or json format
            const string expectedResult = "{\"status\":200,\"result\":{\"postcode\":\"LS15 8ZB\",\"quality\":1,\"eastings\":437878,\"northings\":433543,\"country\":\"England\",\"nhs_ha\":\"Yorkshire and the Humber\",\"longitude\":-1.426439,\"latitude\":53.796822,\"european_electoral_region\":\"Yorkshire and The Humber\",\"primary_care_trust\":\"Leeds\",\"region\":\"Yorkshire and The Humber\",\"lsoa\":\"Leeds 073A\",\"msoa\":\"Leeds 073\",\"incode\":\"8ZB\",\"outcode\":\"LS15\",\"parliamentary_constituency\":\"Elmet and Rothwell\",\"admin_district\":\"Leeds\",\"parish\":\"Austhorpe\",\"admin_county\":null,\"admin_ward\":\"Garforth & Swillington\",\"ced\":null,\"ccg\":\"NHS Leeds\",\"nuts\":\"Leeds\",\"codes\":{\"admin_district\":\"E08000035\",\"admin_county\":\"E99999999\",\"admin_ward\":\"E05011393\",\"parish\":\"E04000188\",\"parliamentary_constituency\":\"E14000689\",\"ccg\":\"E38000225\",\"ccg_id\":\"15F\",\"ced\":\"E99999999\",\"nuts\":\"UKE42\"}}}";
            

            Assert.That(response.StatusCode == HttpStatusCode.OK, response.StatusCode + " wrong status code");
            Assert.AreEqual(response.Content, expectedResult, "Actual result dosen't match expected result");
        }

        [Test]
        public void CodeShouldBeValide()
        {
            var request = new RestRequest($"{code}/validate/", Method.GET);

            var response = _restClient.Execute(request);
            const string expectedResult = "{\"status\":200,\"result\":true}";


            Assert.That(response.StatusCode == HttpStatusCode.OK, response.StatusCode + " wrong status code");
            Assert.AreEqual(response.Content, expectedResult, "Actual result dosen't match expected result");
        }

        [Test]
        public void ValidateInvlaideCode()
        {
            var request = new RestRequest($"{code} + 1/validate/", Method.GET);

            var response = _restClient.Execute(request);
            const string expectedResult = "{\"status\":200,\"result\":false}";


            Assert.That(response.StatusCode == HttpStatusCode.OK, response.StatusCode + " wrong status code");
            Assert.AreEqual(response.Content, expectedResult, "Actual result dosen't match expected result");
        }
    }
}