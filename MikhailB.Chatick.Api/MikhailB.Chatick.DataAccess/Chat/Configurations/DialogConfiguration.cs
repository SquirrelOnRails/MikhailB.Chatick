using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MikhailB.Chatick.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.DataAccess.Chat.Configurations
{
    public class DialogConfiguration : IEntityTypeConfiguration<Dialog>
    {
        public void Configure(EntityTypeBuilder<Dialog> builder)
        {
            builder.ToTable("dialogs");
            builder.HasKey(e => e.DialogID);

            builder.Property(e => e.DialogID).IsRequired(true);
            builder.Property(e => e.IsBlocked).IsRequired(true).HasDefaultValue(false);
            builder.Property(e => e.BlockedReason).IsRequired(false).HasColumnType("number");
            builder.Property(e => e.BlockedDate).IsRequired(false);
            builder.Property(e => e.BlockedBy).IsRequired(false);
            builder.Property(e => e.BlockedText).IsRequired(false);

            builder.HasOne<User>(e => e.BlockedByUser).WithMany().HasForeignKey(e => e.BlockedBy);
            builder.HasMany<User>(e => e.Users).WithMany(e => e.Dialogs)
                .UsingEntity<UserDialog>(
                    j => j
                        .HasOne(pt => pt.User)
                        .WithMany(p => p.UserDialogs)
                        .HasForeignKey(pt => pt.UID),
                    j => j
                        .HasOne(ud => ud.Dialog)
                        .WithMany(d => d.UserDialogs)
                        .HasForeignKey(ud => ud.DialogID),
                    j => {
                            j.Property(pt => pt.UID).IsRequired(true);
                            j.Property(pt => pt.DialogID).IsRequired(true);
                            j.HasKey(t => new { t.UID, t.DialogID });
                            j.ToTable("userdialogs");
                        });
        }
    }
}
