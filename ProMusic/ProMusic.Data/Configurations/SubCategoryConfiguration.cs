using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Configurations
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder
                 .Property(x => x.CratedAt)
                 .HasDefaultValueSql("GETUTCDATE()");

            builder
                .Property(x => x.ModifiedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder
                .Property(x => x.Image)
                .IsRequired(false);
        }
    }
}
