using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models;

namespace Repositories
{
    public class CheckoutRepository : ICheckOutRepository
    {
        public List<Item> GetItems()
        {
            // SQL Query would go here..
            return new List<Item> { 
                new Item { Description = "Bread", Price = 1.50m },
                new Item { Description = "Milk", Price = 0.79m }, 
                new Item { Description = "Butter", Price = 2.25m },
                new Item { Description = "Sugar", Price = 1.95m } 
            };
        }
    }
}
