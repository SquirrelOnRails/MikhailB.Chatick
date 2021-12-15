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
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("tokens");
            builder.HasKey(entity => entity.UID);

            builder.Property(e => e.UID).IsRequired(true);
            builder.Property(e => e.RequestedDate).IsRequired(true);
            builder.Property(e => e.ValidTo).IsRequired(true);
            builder.Property(e => e.Value).IsRequired(true);

            builder.HasOne(e => e.User).WithOne();
        }
    }
}
