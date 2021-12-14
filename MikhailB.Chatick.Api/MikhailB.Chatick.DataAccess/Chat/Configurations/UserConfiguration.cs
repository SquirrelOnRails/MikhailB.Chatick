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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(e => e.UID);

            builder.Property(e => e.UID).IsRequired(true);
            builder.Property(e => e.Username).IsRequired(true);
            builder.Property(e => e.Password).IsRequired(true);
            builder.Property(e => e.FirstName).IsRequired(true);
            builder.Property(e => e.SecondName).IsRequired(true);
            builder.Property(e => e.IsEnabled).IsRequired(false).HasDefaultValue(true);
        }
    }
}
