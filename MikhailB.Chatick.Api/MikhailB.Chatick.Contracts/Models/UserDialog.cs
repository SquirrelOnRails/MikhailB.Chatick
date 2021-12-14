using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Models
{
    /// <summary>
    /// Промежуточная таблица диалоги-пользователи
    /// </summary>
    public class UserDialog
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Идентификатор диалога
        /// </summary>
        public Guid DialogID { get; set; }


        /// <summary>
        /// (virtual) Пользователь
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// (virtual) Диалог
        /// </summary>
        public virtual Dialog Dialog { get; set; }
    }
}
