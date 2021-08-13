using CarShop.Data.interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent,ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.listShopItems;
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail() { CarId = el.car.id,
                    orderId = order.id,
                    price = el.car.price
                };
                appDBContent.Order.Add(order);
            }
            appDBContent.SaveChanges();
        }
    }
}
