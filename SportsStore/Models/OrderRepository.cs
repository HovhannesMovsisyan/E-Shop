using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCard _shoppingCard;

        public OrderRepository(AppDbContext appDbContext, ShoppingCard shoppingCard)
        {
            _appDbContext = appDbContext;
            _shoppingCard = shoppingCard;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCard.GetTotal();
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shopingCards = _shoppingCard.GetShoppingCardItems();
            foreach (var shopingcard in shopingCards)
            {
                var orderDetail = new OrderDetail
                {
                    Amount=shopingcard.Amount,
                    Price=shopingcard.SportsGood.Price,
                    GoodsId=shopingcard.SportsGood.GoodsId,
                    OrderId=order.OrderId
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
