using MikhailB.Chatick.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikhailB.Chatick.Contracts.Models.SignalR
{
    /// <summary>
    /// Сообщение в чате
    /// </summary>
    public class ChatMessage
    {
        public ChatMessage()
        {
            MessageType = MessageType.Text;
            MessageDate = DateTime.UtcNow;
            MessageID = Guid.NewGuid();
        }

        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        public Guid MessageID { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Идентификатор диалога
        /// </summary>
        public Guid DialogID { get; set; }

        /// <summary>
        /// Содержимое сообщения
        /// </summary>
        public byte[] Body { get; set; }

        /// <summary>
        /// Дата отправки сообщения (UTC)
        /// </summary>
        public DateTime? MessageDate { get; set; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public MessageType MessageType { get; set; }


        /// <summary>
        /// пользователь, отправивший сообщение
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Диалог, в который отправлено сообщение
        /// </summary>
        public virtual Dialog Dialog { get; set; }

        public string GetGroup()
        {
            return DialogID.ToString().ToLower();
        }
    }
}
