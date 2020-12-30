using DbTesting.Context;
using DbTesting.Entities;
using DbTesting.Provider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace DbTestingUT
{
    public class SqliteItemServiceUT : ItemServiceUT
    {
        public SqliteItemServiceUT() 
            : base(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {

        }

        [Fact]
        public void Can_get_items()
        {
            using (var context = new ApplicationDbContext(_contextOptions))
            {
                var service = new ItemService(context);

                var items = service.GetAll();

                Assert.Equal(3, items.Count);
                Assert.Equal("ItemOne", items[0].Name);
                Assert.Equal("ItemTwo", items[1].Name);
                Assert.Equal("ItemThree", items[2].Name);
            }
        }

        [Fact]
        public void Can_add_item()
        {
            using (var context = new ApplicationDbContext(_contextOptions))
            {
                var service = new ItemService(context);

                Assert.True(service.Add("ItemFour"));
            }

            using (var context = new ApplicationDbContext(_contextOptions))
            {
                var item = context.Items.Single(e => e.Name == "ItemFour");

                Assert.Equal("ItemFour", item.Name);
                Assert.Equal(0, item.Tags.Count);
            }
        }

        [Fact]
        public void Can_add_tag()
        {
            using (var context = new ApplicationDbContext(_contextOptions))
            {
                var service = new ItemService(context);

                Assert.True(service.SetTag("ItemTwo", "Tag21"));
               
            }

            using (var context = new ApplicationDbContext(_contextOptions))
            {
                var item = context.Items.Include(e => e.Tags).Single(e => e.Name == "ItemTwo");

                Assert.Equal(1, item.Tags.Count);
                Assert.Equal("Tag21", item.Tags[0].Label);
                Assert.Equal(1, item.Tags[0].Count);
            }
        }
    }
}
