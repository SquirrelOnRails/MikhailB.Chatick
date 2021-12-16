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
    public class UserRepository : IUserRepository
    {
        private readonly ILogger _log = Log.ForContext<UserRepository>();
        private readonly ChatContext _dbContext;

        public UserRepository(ChatContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user">Данные пользователя</param>
        /// <returns>Добавленный пользователь</returns>
        public async Task<User> Add(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception e)
            {
                _log.Error(e, "Ошибка БД при добавлении пользователя");
                return null;
            }
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user">Данные пользователя</param>
        public async Task Delete(User user)
        {
            try
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _log.Error(e, "Ошибка БД при удалении пользователя");
            }
        }

        /// <summary>
        /// Поиск пользователя
        /// </summary>
        /// <param name="username">Данные пользователя</param>
        /// <returns>Результат поиска</returns>
        public User Get(string username)
        {
            try
            {
                return _dbContext.Users.SingleOrDefault(u => u.Username.ToLower() == username.ToLower());
            }
            catch (Exception e)
            {
                _log.Error(e, "Ошибка БД при поиске пользователя");
                return null;
            }
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="user">Данные пользователя</param>
        /// <returns>Обновлённый пользователь</returns>
        public async Task<User> Update(User user)
        {
            try
            {
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception e)
            {
                _log.Error(e, "Ошибка БД при обновлении пользователя");
                return null;
            }
        }
    }
}
