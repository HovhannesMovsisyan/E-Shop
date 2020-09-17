using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class SportsGoodsRepository : ISportsGoodsRepository
    {
        private readonly AppDbContext _appDbContext;
        public SportsGoodsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public IEnumerable<SportsGood> GetAllGoods
        {
            get
            {
                return _appDbContext.Goods.Include(c=>c.Category);
            }
        }

        public IEnumerable<SportsGood> GetGoodsOnSale
        {
            get
            {
                return _appDbContext.Goods.Include(c => c.Category).Where(p=>p.IsOnSale);
            }
        }
        public SportsGood GetGoodById(int goodId)
        {
            return GetAllGoods.FirstOrDefault(c => c.GoodsId == goodId);
        }
    }
}
