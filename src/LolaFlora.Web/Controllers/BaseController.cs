using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace LolaFlora.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<T> : ControllerBase
    {
        protected readonly ILogger<T> Logger;
        protected readonly IStringLocalizer<SharedResource> Localizer;
        public BaseController(ILogger<T> logger, IStringLocalizer<SharedResource> localizer)
        {
            Logger = logger;
            Localizer = localizer;
        }
    }
}
