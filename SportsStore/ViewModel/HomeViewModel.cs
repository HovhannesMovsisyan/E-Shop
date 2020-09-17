using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<SportsGood> SportsGoodOnSale { get; set; }
    }
}
