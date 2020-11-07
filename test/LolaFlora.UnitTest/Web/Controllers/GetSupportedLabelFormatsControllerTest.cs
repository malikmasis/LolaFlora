using LolaFlora.Web;
using LolaFlora.Web.Controllers;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LolaFlora.UnitTest.Web.Controllers
{
    public class GetSupportedLabelFormatsControllerTest
    {
        [Fact]
        public void TestGetSupportedLabelFormatsWithNull()
        {
            var mLog = Mock.Of<ILogger<CartController>>();
            var mLocalizer = Mock.Of<IStringLocalizer<SharedResource>>();

            var controller = new CartController(mLog, mLocalizer);
            var reponse = controller.Get();
            Assert.Null(reponse);
        }
    }
}
