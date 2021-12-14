using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MikhailB.Chatick.Contracts.Models.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.DataAccess.Chat.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.ToTable("messages");
            builder.HasKey(entity => entity.MessageID);

            builder.Property(e => e.MessageID).IsRequired(true);
            builder.Property(e => e.UID).IsRequired(true);
            builder.Property(e => e.MessageDate).IsRequired(true);
            builder.Property(e => e.MessageType).HasColumnType("number").IsRequired(true);
            builder.Property(e => e.DialogID).IsRequired(true);
            builder.Property(e => e.Body).IsRequired(true);

            builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UID);
            builder.HasOne(e => e.Dialog).WithMany(e => e.Messages).HasForeignKey(e => e.DialogID);
        }
    }
}
