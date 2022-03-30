using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Configurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder
                .Property(x => x.Title)
                .HasMaxLength(30);

            builder
                .Property(x => x.BtnText)
                .HasMaxLength(30);

            builder
                .Property(x => x.BtnUrl)
                .HasMaxLength(100);           
        }
    }
}
