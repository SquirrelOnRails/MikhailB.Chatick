using MikhailB.Chatick.Contracts.Enums;
using MikhailB.Chatick.Contracts.Models.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Models
{
    /// <summary>
    /// Диалог между пользователями
    /// </summary>
    public class Dialog
    {
        public Dialog()
        {
            DialogID = Guid.NewGuid();
        }

        /// <summary>
        /// Идентификатор диалога
        /// </summary>
        public Guid DialogID { get; set; }

        /// <summary>
        /// Диалог заблокирован/закрыт
        /// </summary>
        public bool? IsBlocked { get; set; }

        /// <summary>
        /// Инициатор блокировки диалога
        /// </summary>
        public Guid? BlockedBy { get; set; }

        /// <summary>
        /// Дата блокировки диалога
        /// </summary>
        public DateTime? BlockedDate { get; set; }

        /// <summary>
        /// Причина блокировки диалога (enum)
        /// </summary>
        public DialogBlockedReason? BlockedReason { get; set; }

        /// <summary>
        /// Пояснение к блокировке диалога
        /// </summary>
        public string BlockedText { get; set; }


        /// <summary>
        /// (virtual) Инициатор блокировки диалога
        /// </summary>
        public virtual User BlockedByUser { get; set; }

        /// <summary>
        /// (virtual) Участники диалога
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// (virtual) Связь пользователей и диалога
        /// </summary>
        public virtual ICollection<UserDialog> UserDialogs { get; set; }

        /// <summary>
        /// (virtual) Сообщения в текущем диалоге
        /// </summary>
        public virtual ICollection<ChatMessage> Messages { get; set; }
    }
}
