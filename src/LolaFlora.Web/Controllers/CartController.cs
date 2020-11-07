using System.Collections.Generic;
using System.Linq;
using LolaFlora.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace LolaFlora.Web.Controllers
{
    public class CartController : BaseController<CartController>
    {

        public CartController(ILogger<CartController> logger, IStringLocalizer<SharedResource> localizer):base(logger,localizer)
        {
        }

        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Cart
            {
                MinCount  = 2
            })
            .ToArray();
        }

        public IActionResult Post(Cart cart)
        {
            Logger.Log(LogLevel.Information, Localizer["Hello"]);

            int f = cart?.MinCount ?? 0;
            if (ModelState.IsValid && f > 0)
            {
                return Ok(Get());
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
