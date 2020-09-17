using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCard _shoppingCard;

        public OrderController(IOrderRepository orderRepository, ShoppingCard shoppingCard)
        {
            _orderRepository = orderRepository;
            _shoppingCard = shoppingCard;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shoppingCard.ShoppingCardItems = _shoppingCard.GetShoppingCardItems();

            if (_shoppingCard.ShoppingCardItems.Count == 0)
                ModelState.AddModelError("", "Card is empty");

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCard.ClearCard();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thak you for Order";
            return View();
        }





    }
}
