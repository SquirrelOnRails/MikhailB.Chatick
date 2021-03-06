using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Dto
{
    /// <summary>
    /// Данные авторизации пользователя
    /// </summary>
    public class LoginCredentialsDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
