using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EpamDashkevichLab13.Domain
{
    public class ItemsRepository
    {
        private readonly AppDbContext context;
        public ItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Item> GetItems()
        {
            return context.Items.OrderBy(x => x.Name);
        }
        public Item GetItemById(int id)
        {
            return context.Items.Single(x => x.Id == id);
        }
        public int SaveItem(Item item)
        {
            if (item.Id == default)
            {
                context.Entry(item).State = EntityState.Added;
            }
            else
            {
                context.Entry(item).State = EntityState.Modified;
            }
            context.SaveChanges();
            return item.Id;
        }
        public void RemoveItem(Item item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }
    }
}
