using System;
using Microsoft.EntityFrameworkCore;

namespace ProMusic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CategoryConfig());

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
