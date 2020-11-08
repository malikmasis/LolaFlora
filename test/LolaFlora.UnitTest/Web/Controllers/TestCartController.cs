using LolaFlora.Common.Interfaces;
using LolaFlora.Data.Base;
using LolaFlora.Data.Entities;
using LolaFlora.Web;
using LolaFlora.Web.Controllers;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace LolaFlora.UnitTest.Web.Controllers
{
    public class TestCartController
    {
        private readonly ICartService _mCartService;
        private readonly ILogger<CartController> _mLog;
        private readonly IStringLocalizer<SharedResource> _mLocalizer;

        public TestCartController()
        {
            _mCartService = Mock.Of<ICartService>();
            _mLog = Mock.Of<ILogger<CartController>>();
            _mLocalizer = Mock.Of<IStringLocalizer<SharedResource>>();
        }
        [Fact]
        public void TestGotoCart()
        {
            var controller = new CartController(_mLog, _mLocalizer, _mCartService);
            var reponse = controller.GotoCart(LolaFloraDbContext.Test.Id).Result.Result;
            Assert.NotNull(reponse);
        }

        [Fact]
        public async Task TestAddToCart()
        {
            var cartService = new Mock<ICartService>();
            cartService.Setup(us => us.AddProduction(LolaFloraDbContext.Test.Id, LolaFloraDbContext.AsusLaptop.Id)).Returns(Task.FromResult(true));

            var controller = new CartController(_mLog, _mLocalizer, cartService.Object);
            var reponse = await controller.AddToCart(new Cart() { UserId = LolaFloraDbContext.Test.Id, ProductId = LolaFloraDbContext.AsusLaptop.Id });
            var okRequest = (Microsoft.AspNetCore.Mvc.OkObjectResult)reponse.Result;
            Assert.Equal((int)HttpStatusCode.OK, okRequest.StatusCode);
        }

        [Fact]
        public async Task TestAddToCartWithNull()
        {
            var controller = new CartController(_mLog, _mLocalizer, _mCartService);
            var result = await controller.AddToCart(null);
            var badRequest = (Microsoft.AspNetCore.Mvc.BadRequestObjectResult)result.Result;
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequest.StatusCode);
        }
    }
}
