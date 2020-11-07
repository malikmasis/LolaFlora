using LolaFlora.Common.Interfaces;
using LolaFlora.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LolaFlora.Web.Controllers
{
    public class UsersController : BaseController<UsersController>
    {
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IStringLocalizer<SharedResource> localizer, IUserService userService) : base(logger, localizer)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            Log.Information("authenticate starting");

            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = Localizer["Username or password is incorrect"] });

            Logger.LogInformation("Authenticated");

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
