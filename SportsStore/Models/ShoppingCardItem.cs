using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class ShoppingCardItem
    {
        public int ShoppingCardItemId { get; set; }
        public string ShoppingCardId { get; set; }
        public SportsGood SportsGood { get; set; }
        public int Amount { get; set; }
    }
}
