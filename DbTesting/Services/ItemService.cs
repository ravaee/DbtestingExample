using DbTesting.Context;
using DbTesting.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbTesting.Provider
{
    public class ItemService
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(string itemName)
        {
            try
            {
                var item = _context.Add(new Item(itemName)).Entity;

                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<Item> GetAll()
        {
            try
            {
                var items = _context.Items.Include(e => e.Tags).ToList();
                return items;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Item Get(string itemName)
        {
            try
            {
                var item = _context.Set<Item>().Include(e => e.Tags).FirstOrDefault(e => e.Name == itemName);
                return item;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool SetTag(string itemName, string tagLabel)
        {
            try
            {
                var tag = _context
                .Set<Item>()
                .Include(e => e.Tags)
                .Single(e => e.Name == itemName)
                .AddTag(tagLabel);

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(string itemName)
        {
            try
            {
                var item = _context
                .Set<Item>()
                .SingleOrDefault(e => e.Name == itemName);

                if (item == null)
                {
                    return false;
                }

                _context.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
