using System;
using System.Collections.Generic;
using System.Web.UI;
using Domain.Interfaces;
using Domain.Models;
using Domain.Presenters;
using Repositories;

namespace WebApp
{
    public partial class Default : Page, ICheckOutView
    {
        // This view implements ICheckoutView so must also implement these properties..
        public List<Item> CheckoutItems { get; set; }
        public decimal RunningTotal { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Create the presenter and pass in the view (this) and our repository. (Fake DB layer)
            var presenter = new CheckOutPresenter(this, new CheckoutRepository());

            // Use Presenter to get the Ordered list.
            // This binds the results to the view property 'CheckoutItems'
            presenter.GetItemsOrderedByPrice();

            CheckoutList.DataSource = CheckoutItems;
            CheckoutList.DataTextField = "Description";
            CheckoutList.DataBind();

            // Use Presenter to get the running total.
            // This binds the results to the view property 'RunningTotal'
            presenter.GetRunningTotal();

            CheckoutTotal.Text = RunningTotal.ToString();
        }
    }
}