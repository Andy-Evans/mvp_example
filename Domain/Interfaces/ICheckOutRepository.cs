using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICheckOutRepository
    {
        List<Item>GetItems();
    }
}