using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Models
{
    /// <summary>
    /// Токен пользователя для доступа к системе
    /// </summary>
    public class Token
    {
        public Token()
        {
            UID = Guid.NewGuid();
        }

        /// <summary>
        /// Значение токена
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Дата выдачи токена
        /// </summary>
        public DateTime RequestedDate { get; set; }

        /// <summary>
        /// Дата окончания действия токена
        /// </summary>
        public DateTime ValidTo { get; set; }


        /// <summary>
        /// Пользователь, которому принадлежит токен
        /// </summary>
        public virtual User User { get; set; }
    }
}
