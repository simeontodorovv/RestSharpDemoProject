
using Exercise;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;



namespace ApiTests
{
    public class UnitTest1
    {
        private RestClient client;
        private const string baseUrl = "https://api.github.com";
        private const string partialUrl = "repos/dimosoftuni/postman/issues";

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient(baseUrl);
        }

        [Test]
        public void Test_GitHubApiRequest()
        {
            
            client.Authenticator = new HttpBasicAuthenticator("simeontodorovv", "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");

            var request = new RestRequest($"{partialUrl}/1", Method.Get);
            
            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var issue = JsonSerializer.Deserialize<Issue>(response.Content);

            Assert.That(issue.title, Is.EqualTo("EDITED: Test issue from REstSharp 638113072326540668"));

            Assert.That(issue.number, Is.EqualTo(1));
            
        }
        [Test]
        public void Test_AllIssues()
        {      
            client.Authenticator = new HttpBasicAuthenticator("simeontodorovv", "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");

            var request = new RestRequest($"{partialUrl}/1", Method.Get);

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var issue = JsonSerializer.Deserialize<Issue>(response.Content);
        }
        
    }
}
