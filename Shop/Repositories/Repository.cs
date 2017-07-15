using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop.Repositories
{
    public class Repository : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public Repository() : base("Repository")
        {

        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            this.SaveChanges();
        }

        public void EditItem(Item item)
        {
            this.Entry(item).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void DeleteItem(Item item)
        {
            this.Entry(item).State = EntityState.Deleted;
            this.SaveChanges();
        }

        public Item GetItem(int id)
        {
            return (from item in Items
                   where item.ID == id
                   select item).First();
        }
    }
}