using System;
using System.Collections.Generic;
using System.Text;

namespace MikhailB.Chatick.Contracts.Enums
{
    /// <summary>
    /// Тип сообщения в чате
    /// </summary>
    public enum MessageType
    {
        Unknown = 0,
        Text = 1,
        File = 2,
        Audio = 3,
        Video = 4
    }
}
