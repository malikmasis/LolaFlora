using LolaFlora.Common.Interfaces;
using LolaFlora.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LolaFlora.Web.Controllers
{
    public class CartController : BaseController<CartController>
    {
        private readonly ICartService _cartService;
        public CartController(ILogger<CartController> logger, IStringLocalizer<SharedResource> localizer, ICartService cartService) : base(logger, localizer)
        {
            _cartService = cartService;
        }

        [HttpGet("gotocart")]
        public async Task<ActionResult<Cart>> GotoCart([FromQuery] long customerId)
        {
            try
            {
                var cart = await _cartService.GetAll(customerId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                Logger.LogError("Unhandled", new object[1] { ex });
                return BadRequest(ex);
            }
        }

        [HttpPost("addtocart")]
        public async Task<ActionResult<bool>> AddToCart([FromBody]Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not well defined");
            }
            try
            {
                //If the user is not the logged in the system - UI will send a unique Id
                return  Ok(await _cartService.AddProduction(cart.UserId, cart.ProductId));
            }
            catch (Exception ex)
            {
                Logger.LogError("Unhandled", new object[1] { ex });
                return BadRequest(ex);
            }
        }

        [HttpPost("removefromcart")]
        public async Task<ActionResult<bool>> RemoveFromCart([FromBody] Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not well defined");
            }
            try
            {
                //If the user is not the logged in the system - UI will send a unique Id
                return Ok(await _cartService.RemoveProduction(cart.UserId, cart.ProductId));
            }
            catch (Exception ex)
            {
                Logger.LogError("Unhandled", new object[1] { ex });
                return BadRequest(ex);
            }
        }

        [HttpPost("emptycart")]
        public async Task<ActionResult<bool>> EmptyCart([FromQuery] long customerId)
        {
            try
            {
                return Ok(await _cartService.RemoveAll(customerId));
            }
            catch (Exception ex)
            {
                Logger.LogError("Unhandled", new object[1] { ex });
                return BadRequest(ex);
            }
        }
    }
}
