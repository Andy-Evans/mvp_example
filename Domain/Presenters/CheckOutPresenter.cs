using System.Linq;
using Domain.Interfaces;

namespace Domain.Presenters
{
    public class CheckOutPresenter
    {
        private readonly ICheckOutRepository _checkOutRepository;
        private readonly ICheckOutView _checkOutView;

        public CheckOutPresenter(ICheckOutRepository checkOutRepository, ICheckOutView checkOutView)
        {
            _checkOutRepository = checkOutRepository;
            _checkOutView = checkOutView;
        }

        public void GetItemsOrderedByPrice()
        {
            _checkOutView.CheckoutItems= _checkOutRepository.GetItems().OrderBy(o => o.Price ).ToList();
        }
    }
}