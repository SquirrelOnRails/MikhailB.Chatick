using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MikhailB.Chatick.Api.Classes;
using MikhailB.Chatick.Contracts.Dto;
using MikhailB.Chatick.Contracts.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly ILogger _log = Log.ForContext<UserController>();
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        /// <param name="userId">Unique user id</param>
        /// <returns>Common user info to display on a website</returns>
        [HttpGet("GetDisplayInfo")]
        public async Task<ActionResult> GetDisplayInfo([FromQuery] string userId)
        {
            try
            {
                var currentUser = await _userManager.FindByIdAsync(userId);

                if (currentUser == null)
                {
                    return NotFound(new ApiResponse 
                    {
                        Errors = new List<string> { $"User with id {userId} not found" },
                        Success = false
                    });
                }

                return Ok(new UserDisplayInfo
                {
                    Id = currentUser.Id,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName
                });
            }
            catch (Exception e)
            {
                _log.Error(e, "unknown error trying to get user info");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
