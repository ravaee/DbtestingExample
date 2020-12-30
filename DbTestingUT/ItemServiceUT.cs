using DbTesting.Context;
using DbTesting.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace DbTestingUT
{
    public class ItemServiceUT
    {
        protected DbContextOptions<ApplicationDbContext> _contextOptions { get; }

        protected ItemServiceUT(DbContextOptions<ApplicationDbContext> contextOption)
        {
            _contextOptions = contextOption;

            Seed();
        }

        private void Seed()
        {
            using (var context = new ApplicationDbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var one = new Item("ItemOne");
                one.AddTag("Tag11");
                one.AddTag("Tag12");
                one.AddTag("Tag13");

                var two = new Item("ItemTwo");

                var three = new Item("ItemThree");
                three.AddTag("Tag31");
                three.AddTag("Tag31");
                three.AddTag("Tag31");
                three.AddTag("Tag32");
                three.AddTag("Tag32");

                context.AddRange(one, two, three);

                context.SaveChanges();
            }
        }


    }
}
