using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(20);

            builder
                .Property(x => x.Desc)
                .IsRequired(true)
                .HasMaxLength(400);

            builder
                .Property(x => x.CratedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder
                .Property(x => x.ModifiedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
