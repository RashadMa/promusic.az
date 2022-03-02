using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Configurations
{

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(20);

            builder
                .Property(x => x.SalePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

            builder
                .Property(x => x.CostPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

            builder
                .Property(x => x.DiscountPercent)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(x => x.CratedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder
                .Property(x => x.ModifiedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}