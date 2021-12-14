using Microsoft.AspNetCore.SignalR;
using MikhailB.Chatick.Contracts.Models.SignalR;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace MikhailB.Chatick.BusinesLogic.Hubs
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// Отправка сообщения получателям
        /// </summary>
        /// <param name="message">Содержимое сообщения</param>
        public async Task SendMessageAsync(ChatMessage message)
        {
            await Clients.Group(message.GetGroup()).SendAsync("RecieveMessage", message);
        }
    }
}
