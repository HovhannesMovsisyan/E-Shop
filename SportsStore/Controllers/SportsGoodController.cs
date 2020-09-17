using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class SportsGoodController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISportsGoodsRepository _sportsGoodsRepository;

        public SportsGoodController(ICategoryRepository categoryRepository, ISportsGoodsRepository sportsGoodsRepository)
        {
            _categoryRepository = categoryRepository;
            _sportsGoodsRepository = sportsGoodsRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<SportsGood> sportsGoods;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                sportsGoods = _sportsGoodsRepository.GetAllGoods.OrderBy(c=>c.GoodsId);
                currentCategory = "All Goods";
            }
            else
            {
                sportsGoods = _sportsGoodsRepository.GetAllGoods.Where(c => c.Category.CategoryName == category);
                currentCategory = _categoryRepository.GetAllCategories
                    .FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            var viewModel= new SportsGoodsListViewModel
            {
                SportsGoods = sportsGoods,
                CurrentCategory = currentCategory
            };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var good = _sportsGoodsRepository.GetGoodById(id);
            if (good == null)
                return NotFound();
            return View(good);
        }
    }
}
