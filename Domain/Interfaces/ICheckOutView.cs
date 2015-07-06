using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICheckOutView
    {
        List<Item> CheckoutItems { get; set; }
    }
}