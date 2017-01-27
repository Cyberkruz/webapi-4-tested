using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TestedWebsite.Web.Tests
{
    [TestFixture]
    public class Integration
    {
        private HttpServer BuildServer()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var server = new HttpServer(config);
            return server;
        }

        [Test]
        public async Task HelloWorldAsync()
        {
            var server = BuildServer();

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("http://localhost/api/values/5")
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Method = HttpMethod.Get;

            var client = new HttpClient(server);
            var response = await client.SendAsync(request);

            Assert.IsNotNull(response.Content);
        }
    }
}
