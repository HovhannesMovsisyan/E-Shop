using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class ShoppingCard
    {
        private readonly AppDbContext _appDbContext;

        public string ShoppingCardId { get; set; }
        public List<ShoppingCardItem> ShoppingCardItems { get; set; }

        public ShoppingCard(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCard GetCard(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cardid = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cardid);
            return new ShoppingCard(context) { ShoppingCardId = cardid };
        }

        public void AddToCard(SportsGood sportsGood, int amount)
        {
            var shoppingcartitem = _appDbContext.ShoppingCardItems.
                    SingleOrDefault(s => s.SportsGood.GoodsId == sportsGood.GoodsId
                    && s.ShoppingCardId == ShoppingCardId);

            if (shoppingcartitem == null)
            {
                shoppingcartitem = new ShoppingCardItem
                {
                    ShoppingCardId = ShoppingCardId,
                    SportsGood=sportsGood,
                    Amount=amount
                };
                _appDbContext.ShoppingCardItems.Add(shoppingcartitem);
            }
            else
            {
                shoppingcartitem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCard(SportsGood sportsGood)
        {
            var shoppingcartitem = _appDbContext.ShoppingCardItems.
                    SingleOrDefault(s => s.SportsGood.GoodsId == sportsGood.GoodsId
                    && s.ShoppingCardId == ShoppingCardId);

            var cartamount=0;
            if (shoppingcartitem != null)
            {
                if (shoppingcartitem.Amount > 0)
                {
                    shoppingcartitem.Amount--;
                    cartamount = shoppingcartitem.Amount;

                    if(cartamount==0)
                        _appDbContext.ShoppingCardItems.Remove(shoppingcartitem);
                }
            }
            else
            {
                _appDbContext.ShoppingCardItems.Remove(shoppingcartitem);
            }
            _appDbContext.SaveChanges();
            return cartamount;
        }

        public List<ShoppingCardItem> GetShoppingCardItems()
        {
            return ShoppingCardItems ?? (ShoppingCardItems = _appDbContext.ShoppingCardItems
                        .Where(c => c.ShoppingCardId == ShoppingCardId)
                        .Include(c => c.SportsGood).ToList());
        }

        public void ClearCard()
        {
            var items = _appDbContext.ShoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCardId);
            _appDbContext.ShoppingCardItems.RemoveRange(items);
            _appDbContext.SaveChanges();
        }

        public decimal GetTotal()
        {
            var total = _appDbContext.ShoppingCardItems
                                .Where(c => c.ShoppingCardId == ShoppingCardId)
                                .Select(c => c.SportsGood.Price * c.Amount).Sum();
            return total;
        }

    }
}
