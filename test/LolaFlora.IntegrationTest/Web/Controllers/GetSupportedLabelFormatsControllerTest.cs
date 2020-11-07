using LolaFlora.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LolaFlora.IntegrationTest.Web.Controllers
{
    public class GetSupportedLabelFormatsControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GetSupportedLabelFormatsControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/v1/GetSupportedLabelFormats")]
        public async Task TestGetSupportedLabelFormats(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsync(url, null);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            client.Dispose();

            var supportedLabels = await response.Content.ReadAsStringAsync();
            var labels = JsonConvert.DeserializeObject<IEnumerable<string>>(supportedLabels);
            IEnumerable<string> defaultFormats = new List<string>() { "PDF", "ZPL", "PNG" };

            Assert.Equal(defaultFormats, labels);
            response.Content.Dispose();
        }
    }
}
