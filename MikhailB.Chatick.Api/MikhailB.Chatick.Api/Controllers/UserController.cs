using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MikhailB.Chatick.Contracts.Dto;
using MikhailB.Chatick.Contracts.Interfaces;
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
    public class UserController : ControllerBase
    {
        private readonly ILogger _log = Log.ForContext<UserController>();
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="credentials">Данные авторизации пользователя</param>
        /// <returns>Обновлённый токен пользователя</returns>
        public async Task<ActionResult> Login(LoginCredentialsDto credentials)
        {
            // get user
            User user = null;
            try
            {
                user = _userService.SearchByUsername(credentials.Username);
            }
            catch (Exception e)
            {
                var errorMsg = "Ошибка при авторизации";
                _log.Error(e, errorMsg);
                return StatusCode(StatusCodes.Status500InternalServerError, $"{errorMsg}: {e.Message}");
            }

            if (user == null)
                return NotFound();
            
            if (user.Password != credentials.Password)
                return Forbid();

            // get token
            try
            {
                var token = await _tokenService.RefreshUserToken(user.UID);
                if (token != null)
                    return Ok(token);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Не удалось авторизовать пользователя, повторите запрос позже");
            }
            catch (Exception e)
            {
                var errMsg = "Ошибка при авторизации";
                _log.Error(e, errMsg);
                return StatusCode(StatusCodes.Status500InternalServerError, $"{errMsg}: {e.Message}");
            }
        }
    }
}
