using Microsoft.EntityFrameworkCore.ChangeTracking;
using MikhailB.Chatick.Contracts.Interfaces;
using MikhailB.Chatick.Contracts.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.DataAccess.Chat.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ILogger _log = Log.ForContext<TokenRepository>();
        private readonly ChatContext DbContext;

        public TokenRepository(ChatContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Получить данные токена
        /// </summary>
        /// <param name="tokenValue">значение токена</param>
        /// <returns>Токен</returns>
        public Token Get(string tokenValue)
        {
            try
            {
                return DbContext.Tokens.FirstOrDefault(t => t.Value == tokenValue);
            }
            catch (Exception e)
            {
                _log.Error(e, "ошибка БД при поиске токена");
                return null;
            }
        }

        /// <summary>
        /// Получить токен пользователя
        /// </summary>
        /// <param name="uid">Идентификатор пользователя</param>
        /// <returns>Токен</returns>
        public Token Get(Guid uid)
        {
            try
            {
                return DbContext.Tokens.SingleOrDefault(t => t.UID == uid);
            }
            catch (Exception e)
            {
                _log.Error(e, "ошибка БД при поиске токена");
                return null;
            }
        }

        /// <summary>
        /// Обновление токена
        /// </summary>
        /// <param name="token">Данные токена</param>
        /// <returns>Обновлённый токен</returns>
        public async Task<Token> Update(Token token)
        {
            try
            {
                var updateResult = DbContext.Tokens.Update(token);
                await DbContext.SaveChangesAsync();
                return updateResult.Entity;
            }
            catch (Exception e)
            {
                _log.Error(e, "ошибка БД при обновлении токена");
                return null;
            }
        }

        /// <summary>
        /// Добавление нового токена в БД
        /// </summary>
        /// <param name="uid">идентификатор пользователя</param>
        public async Task<Token> Add(Token token)
        {
            try
            {
                var addResult = DbContext.Tokens.Add(token);
                await DbContext.SaveChangesAsync();
                return addResult.Entity;
            }
            catch (Exception e)
            {
                _log.Error(e, "Ошибка БД при добавлении токена");
                return null;
            }
        }
    }
}
