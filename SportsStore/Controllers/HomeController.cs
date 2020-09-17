using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.ViewModel;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISportsGoodsRepository _sportsGoodsRepository;

        public HomeController(ISportsGoodsRepository sportsGoodsRepository)
        {
            _sportsGoodsRepository = sportsGoodsRepository;
        }

       

        public IActionResult Index()
        {
            var homeVM = new HomeViewModel
            {
                SportsGoodOnSale = _sportsGoodsRepository.GetGoodsOnSale
            };
            return View(homeVM);
        }
    }
}
