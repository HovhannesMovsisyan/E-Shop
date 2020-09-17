using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface ISportsGoodsRepository
    {
        IEnumerable<SportsGood> GetAllGoods { get; }
        IEnumerable<SportsGood> GetGoodsOnSale { get; }
        SportsGood GetGoodById(int goodId);
    }
}
