using System;
using Microsoft.EntityFrameworkCore;
using ProMusic.Core.Entities;

namespace ProMusic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Setting> Settings { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CategoryConfig());

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
