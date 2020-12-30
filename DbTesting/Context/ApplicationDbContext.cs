using DbTesting.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbTesting.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            :base(option)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>(b =>
            {
                b.Property("_id");
                b.HasKey("_id");
                b.Property(e => e.Label);
            });
        }
    }
}
