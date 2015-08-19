using System;
using System.Collections.Generic;
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
            //Arrange
            var view = new MockedCheckOutView();
            var presenter = new CheckOutPresenter(view, new MockedCheckOutRepository());

            //Act
            presenter.GetItemsOrderedByPrice();

             //Assert
            Assert.IsTrue(view.CheckoutItems.Count > 0);
            
        }

        [TestMethod]
        public void CheckListIsOrderedByPrice()
        {
            //Arrange
            var view = new MockedCheckOutView();
            var presenter = new CheckOutPresenter(view, new MockedCheckOutRepository());

            //Act
            presenter.GetItemsOrderedByPrice();

            //Assert
            Assert.IsTrue(view.CheckoutItems.Count > 0);
            Assert.AreEqual(0.50m, view.CheckoutItems[0].Price);
            Assert.AreEqual(1.50m, view.CheckoutItems[1].Price);
            Assert.AreEqual(2.75m, view.CheckoutItems[2].Price);
            Assert.AreEqual(4.20m, view.CheckoutItems[3].Price);
        }

        [TestMethod]
        public void RunningTotalIsZeroForEmptyBasket()
        {
            //Arrange
            var view = new MockedCheckOutView();

            //Assert
            Assert.AreEqual(0, view.RunningTotal);
        }


        [TestMethod]
        public void CheckRunningTotalForBasketWithItems()
        {
            //Arrange
            var view = new MockedCheckOutView();
            var presenter = new CheckOutPresenter(view, new MockedCheckOutRepository());

            //Act
            presenter.GetRunningTotal();

            //Assert
            Assert.AreEqual(8.95m, view.RunningTotal);
        }
    }

    public  class MockedCheckOutRepository:ICheckOutRepository
    {
        public List<Item> GetItems()
        {
            return new List<Item> { 
                new Item { Description = "Bread", Price = 1.50m }};
        }
    }

    public class MockedCheckOutView:ICheckOutView
    {
        public List<Item> CheckoutItems { get; set; }
        public Decimal RunningTotal { get; set; }
    }
}
