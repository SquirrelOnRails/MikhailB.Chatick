using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Enums
{
    /// <summary>
    /// Причина блокировки диалога
    /// </summary>
    public enum DialogBlockedReason
    {
        Unknown = 0,
        UserInitiated = 1,
        AdministrationInitiated = 2
    }
}
