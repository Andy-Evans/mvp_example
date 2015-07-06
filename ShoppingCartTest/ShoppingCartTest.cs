using System.Collections.Generic;
using Domain;
using Domain.Interfaces;
using Domain.Models;
using Domain.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCartTest
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void CheckListContainsItems()
        {
            var view = new MockedCheckOutView();
            var presenter = new CheckOutPresenter(new MockedCheckOutRepository(),view);
             presenter.GetItemsOrderedByPrice(); 
            Assert.IsTrue(view.CheckoutItems.Count > 0);
            
        }

        [TestMethod]
        public void CheckListIsOrderedByPrice()
        {
            var view = new MockedCheckOutView();
            var presenter = new CheckOutPresenter(new MockedCheckOutRepository(), view);
             presenter.GetItemsOrderedByPrice();
             Assert.IsTrue(view.CheckoutItems.Count > 0);
             Assert.AreEqual(view.CheckoutItems[0].Price, 10.50m);
             Assert.AreEqual(view.CheckoutItems[1].Price, 188.50m);
             Assert.AreEqual(view.CheckoutItems[2].Price, 200.50m);
        }
    }

    public  class MockedCheckOutRepository:ICheckOutRepository
    {
        public List<Item> GetItems()
        {
                return new List<Item> { new Item { Description = "Bread", Price = 10.50m }, new Item { Description = "Milk", Price = 200.50m }, new Item{Description = "Butter", Price = 188.50m} };
        }
    }

    public class MockedCheckOutView:ICheckOutView
    {
        public List<Item> CheckoutItems { get; set; }
    }
}
