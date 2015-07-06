using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Interfaces;
using Domain.Models;
using Domain.Presenters;
using Repositories;

namespace WebApp
{
    public partial class Default : Page, ICheckOutView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var presenter = new CheckOutPresenter(new CheckoutRepository(), this);

            presenter.GetItemsOrderedByPrice();

            CheckoutList.DataSource = CheckoutItems;
            CheckoutList.DataTextField = "Description";
            CheckoutList.DataBind();

        }

        public List<Item> CheckoutItems { get; set; }
    }
}