using MikhailB.Chatick.Contracts.Interfaces;
using MikhailB.Chatick.Contracts.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.BusinesLogic.Services
{
    public class TokenService : ITokenService
    {
        private readonly ILogger _log = Log.ForContext<TokenService>();
        private readonly ITokenRepository _repository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _repository = tokenRepository;
        }

        /// <summary>
        /// Проверка токена на валидность
        /// </summary>
        /// <param name="tokenValue">значение токена</param>
        /// <returns>true - валидный, false - невалидный</returns>
        public bool CheckTokenIsValid(string tokenValue)
        {
            if (string.IsNullOrEmpty(tokenValue))
                return false;

            var token = _repository.Get(tokenValue);

            return (token != null) && (token.ValidTo > DateTime.UtcNow);
        }

        /// <summary>
        /// Обновление срока действия токена, или создание токена для нового пользователя
        /// </summary>
        /// <param name="uid">Идентификатор пользователя</param>
        /// <returns>Обновлённый токен</returns>
        public async Task<Token> RefreshUserToken(Guid uid)
        {
            Token token;
            try
            {
                token = _repository.Get(uid);
            }
            catch (Exception e)
            {
                _log.Error(e, "ошибка при поиске токена");
                return null;
            }

            if (token == null)
            {
                try
                {
                    token = await AddToken(uid);
                }
                catch (Exception e)
                {
                    _log.Error(e, "SetUserToken");
                    return null;
                }
            }

            // refresh token
            var currDate = DateTime.UtcNow;

            token.RequestedDate = currDate;
            token.ValidTo = currDate.AddHours(24);
            token.Value = GetRandomString();

            try
            {
                await _repository.Update(token);
            }
            catch (Exception e)
            {
                _log.Error(e, "Ошибка при обновлении срока действия токена");
                return null;
            }

            return token;
        }

        /// <summary>
        /// Добавление нового токена в БД
        /// </summary>
        /// <param name="uid">идентификатор пользователя</param>
        private async Task<Token> AddToken(Guid uid)
        {
            var randomString = GetRandomString();
            var currDate = DateTime.UtcNow;

            var newToken = new Token
            {
                UID = uid,
                RequestedDate = currDate,
                ValidTo = currDate.AddHours(24),
                Value = randomString
            };

            try
            {
                return await _repository.Add(newToken);
            }
            catch (Exception e)
            {
                _log.Error(e, "ошибка при создании токена пользователя");
                return null;
            }
        }

        /// <summary>
        /// генерирует строку значения токена
        /// </summary>
        /// <param name="length">необходимая длина строки</param>
        /// <returns>значение токена</returns>
        private string GetRandomString(int length = 24)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
                                                    .Select(s => s[(new Random()).Next(s.Length)]).ToArray());
        }
    }
}
