using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class ShoppingCardSummary : ViewComponent
    {
        private readonly ShoppingCard _shoppingCard;

        public ShoppingCardSummary(ShoppingCard shoppingCard)
        {
            _shoppingCard = shoppingCard;
        }

        public IViewComponentResult Invoke()
        {
            _shoppingCard.ShoppingCardItems = _shoppingCard.GetShoppingCardItems();
            var shoppingcardVM = new ShoppingCardViewModel
            {
                ShoppingCard = _shoppingCard,
                ShoppingCardTotal = _shoppingCard.GetTotal()
            };
            return View(shoppingcardVM);
        }
    }
}
