using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Common;
using WebAPI.Core.Context;
using WebAPI.Core.Entity;
using WebAPI.Core.Manager;
using WebAPI.Core.Manager.User;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController<User>
    {
        private readonly IUserManager _userManager;
        private readonly IConfiguration _configuration;
        public UserController(IBaseManager<User> manager, IUserManager userManager, IConfiguration configuration) : base(manager)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] User model)
        {
            if (!string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Email))
            {
                var user = await _userManager.ValidateUser(model);

                string token = string.Empty;

                var apiKey = _configuration.GetSection("AppSettings").GetValue<string>("ApiKey");

                if (user != null)
                    token = JwtTokenHelper.Token(apiKey, user);

                return Ok(new { token });
            }
            return Ok();
        }

    }
}
