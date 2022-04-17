using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(x => x.Email)
                .HasMaxLength(30)
                .IsRequired(true);

            builder
                .Property(x => x.Adress)
                .HasMaxLength(100)
                .IsRequired(true);

            builder
                .Property(x => x.Phone)
                .HasMaxLength(30)
                .IsRequired(true);

            builder
                .Property(x => x.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);
        }
    }
}
