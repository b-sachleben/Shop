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
        // initiate Item class DbSet
        public DbSet<Item> Items { get; set; }

        // repository constructor
        public Repository() : base("Repository")
        {

        }

        // Adds item to database
        public void AddItem(Item item)
        {
            Items.Add(item);
            this.SaveChanges();
        }

        // Edits item in database
        public void EditItem(Item item)
        {
            this.Entry(item).State = EntityState.Modified;
            this.SaveChanges();
        }

        // Deletes item from database
        public void DeleteItem(Item item)
        {
            this.Entry(item).State = EntityState.Deleted;
            this.SaveChanges();
        }

        // returns an individual item from database
        public Item GetItem(int id)
        {
            return (from item in Items
                   where item.ID == id
                   select item).First();
        }
    }
}