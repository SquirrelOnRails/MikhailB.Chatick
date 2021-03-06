using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Dto
{
    public class RegistrationCredentialsDto : LoginCredentialsDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        public string Username { get; set; }
    }
}
