using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .Property(x => x.SalePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

            builder
                .Property(x => x.CostPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

            builder
                .Property(x => x.DiscountedPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);
        }
    }
}
