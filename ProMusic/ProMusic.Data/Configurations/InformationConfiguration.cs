using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Configurations
{
    public class InformationConfiguration : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> builder)
        {
            builder
                .Property(x => x.Title)
                .HasMaxLength(20);

            builder
                .Property(x => x.Desc)
                .HasMaxLength(20);
        }
    }
}
