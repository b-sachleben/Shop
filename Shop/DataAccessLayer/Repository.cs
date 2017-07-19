using Shop.DataAccessLayer;
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
        static Context GetContext()
        {
            var context = new Context();
            return context;
        }

        public Repository() : base("Repository")
        {
            
        }

        public void AddItem(Item item)
        {
            using (Context context = GetContext())
            { 
                context.Items.Add(item);
                this.SaveChanges();
            }
        }

        public void EditItem(Item item)
        {
            using (Context context = GetContext())
            { 
                this.Entry(item).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void DeleteItem(Item item)
        {
            using (Context context = GetContext())
            {
                this.Entry(item).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }

        public Item GetItem(int id)
        {
            using (Context context = GetContext())
            {
                return (from item in context.Items
                        where item.ID == id
                        select item).First();
            }
        }
    }
}