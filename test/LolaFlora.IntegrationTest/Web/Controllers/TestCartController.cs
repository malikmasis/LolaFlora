using LolaFlora.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LolaFlora.IntegrationTest.Web.Controllers
{
    public class TestCartController : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TestCartController(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/users/authenticate")]
        public async Task TestAuthenticate(string url)
        {
            var client = _factory.CreateClient();
            string fileContent = File.ReadAllText(@"..\..\..\ExampleData\Auth.json");
            var content = new StringContent(fileContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestAddProduct()
        {
            string url = "/cart/addtocart";
            var client = _factory.CreateClient();
            string fileContent = File.ReadAllText(@"..\..\..\ExampleData\AddRemoveCart.json");
            var content = new StringContent(fileContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
