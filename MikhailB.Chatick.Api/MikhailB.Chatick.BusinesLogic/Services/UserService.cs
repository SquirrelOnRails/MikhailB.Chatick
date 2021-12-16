using MikhailB.Chatick.Contracts.Interfaces;
using MikhailB.Chatick.Contracts.Models;
using MikhailB.Chatick.DataAccess.Chat;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.BusinesLogic.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger _log = Log.ForContext<UserService>();
        private readonly IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        /// <summary>
        /// Добавление нового пользователя в БД
        /// </summary>
        /// <param name="newUser">Данные нового пользователя</param>
        /// <returns>Созданный пользователь</returns>
        public async Task<User> RegisterUser(User newUser)
        {
            User result = null;
            try
            {
                result = await _repository.Add(newUser);
            }
            catch (Exception e)
            {
                _log.Error(e, "Ошибка при создании пользователя");
            }

            return result;
        }

        /// <summary>
        /// Поиск пользователя по Username
        /// </summary>
        /// <param name="username">Логин пользователя</param>
        /// <returns>Пользователь</returns>
        public User SearchByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            User result = null;

            try
            {
                result = _repository.Get(username);
            }
            catch (Exception e)
            {
                _log.Error(e, "Ошибка при поиске польззователя");
            }

            return result;
        }
    }
}
