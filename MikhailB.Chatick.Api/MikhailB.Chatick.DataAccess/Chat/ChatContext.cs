using Microsoft.EntityFrameworkCore;
using MikhailB.Chatick.Contracts.Models;
using MikhailB.Chatick.Contracts.Models.SignalR;
using MikhailB.Chatick.DataAccess.Chat.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.DataAccess.Chat
{
    public class ChatContext : DbContext
    {
        //public string ConnString { get; private set; }

        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        { }

        public DbSet<ChatMessage> ChatMessages;
        public DbSet<User> Users;
        public DbSet<Dialog> Dialogs;
        public DbSet<UserDialog> UserDialogs; // Dialogs

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.HasDefaultSchema("chat");

            mb.ApplyConfiguration(new ChatMessageConfiguration());
            mb.ApplyConfiguration(new UserConfiguration());
            mb.ApplyConfiguration(new DialogConfiguration());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder ob){}
    }
}
