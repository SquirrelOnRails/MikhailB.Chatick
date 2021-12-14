using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Models
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class User
    {
        public User()
        {
            UID = Guid.NewGuid();
            IsEnabled = true;
        }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Логин, nickname пользователя
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string SecondName { get; set; }
        
        /// <summary>
        /// Пользователю доступен функционал
        /// </summary>
        public bool? IsEnabled { get; set; }


        /// <summary>
        /// (virtual) Диалоги пользователя
        /// </summary>
        public virtual ICollection<Dialog>? Dialogs { get; set; }

        /// <summary>
        /// (virtaul) Связи пользователя с диалогами
        /// </summary>
        public virtual ICollection<UserDialog> UserDialogs { get; set; }
    }
}
