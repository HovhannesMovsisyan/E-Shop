using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.ViewModel
{
    public class SportsGoodsListViewModel
    {
        public IEnumerable<SportsGood> SportsGoods { get; set; }
        public string CurrentCategory { get; set; }

    }
}
