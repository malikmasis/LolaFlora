using LolaFlora.Common.Interfaces;
using LolaFlora.Common.Models;
using LolaFlora.Common.Result;
using LolaFlora.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not well defined");
            }
            Log.Information("authenticate starting");

            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = Localizer["Username or password is incorrect"] });

            Logger.LogInformation("Authenticated");

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetAll")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            try
            {
                var users = await _userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Logger.LogError("Unhandled", new object[1] { ex });
                return BadRequest(ex);
            }
        }
    }
}
