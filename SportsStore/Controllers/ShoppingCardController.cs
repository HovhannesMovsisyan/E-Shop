using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly ISportsGoodsRepository _sportsGoodsRepository;
        private readonly ShoppingCard _shoppingCard;

        public ShoppingCardController(ISportsGoodsRepository sportsGoodsRepository, ShoppingCard shoppingCard)
        {
            _sportsGoodsRepository = sportsGoodsRepository;
            _shoppingCard = shoppingCard;
        }

        public ViewResult Index()
        {
            _shoppingCard.ShoppingCardItems = _shoppingCard.GetShoppingCardItems();

            var shoppingcardVM = new ShoppingCardViewModel
            {
                ShoppingCard = _shoppingCard,
                ShoppingCardTotal = _shoppingCard.GetTotal()
            };
            return View(shoppingcardVM);
        }

        public RedirectToActionResult AddToShoppingCard(int goodId)
        {
            var selecteditem = _sportsGoodsRepository.GetAllGoods.FirstOrDefault(c=>c.GoodsId==goodId);

            if (selecteditem != null)
            {
                _shoppingCard.AddToCard(selecteditem, 1);
            }
            return RedirectToAction("List", "SportsGood");
        }

        public RedirectToActionResult RemoveFromShoppingCard(int goodId)
        {
            var selecteditem = _sportsGoodsRepository.GetAllGoods.FirstOrDefault(c => c.GoodsId == goodId);

            if (selecteditem != null)
            {
                _shoppingCard.RemoveFromCard(selecteditem);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart()
        {
            _shoppingCard.ClearCard();
            return RedirectToAction("Index");
        }
    }
}
