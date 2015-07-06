using System.Collections.Generic;
using Domain;
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
                new Item { Description = "Bread", Price = 10.50m },
                new Item { Description = "Milk", Price = 200.50m }, 
                new Item { Description = "Butter", Price = 88.50m },
                new Item { Description = "Sugar", Price = 1.20m } 
            };
        }
    }
}
