using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Configurations
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.
                Property(x => x.Key)
                .HasMaxLength(25)
                .IsRequired(true);

            builder
                .Property(x => x.Value)
                .HasMaxLength(200)
                .IsRequired(true);
        }
    }
}
