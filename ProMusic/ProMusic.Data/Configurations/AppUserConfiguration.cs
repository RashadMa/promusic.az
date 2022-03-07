using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(20);

            builder
                .Property(x => x.IsAdmin)
                .HasDefaultValue(false);
        }
    }
}
