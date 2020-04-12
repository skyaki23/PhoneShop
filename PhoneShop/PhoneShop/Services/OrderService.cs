using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneShop.Services
{
    public class OrderService
    {
        #region Singleton
        public static OrderService Instance
        {
            get
            {
                if (instance == null) instance = new OrderService();

                return instance;
            }
        }
        private static OrderService instance { get; set; }
        private OrderService()
        {
        }
        #endregion

        public List<Order> GetOrders(string UserId)
        {
            using (var context = new PhoneShopContext())
            {
                var orders = context.Orders.ToList();

                if (!string.IsNullOrEmpty(UserId))
                {
                    orders = orders.Where(x => x.UserID == UserId).ToList();
                }

                return orders;
            }
        }

        public Order GetOrderByID(int ID)
        {
            using (var context = new PhoneShopContext())
            {
                return context.Orders.Where(x => x.ID == ID).Include(x => x.OrderItems).Include("OrderItems.Product").FirstOrDefault(); // OrderItems List
            }
        }

        public bool UpdateOrderStatus(int ID, string status)
        {
            using (var context = new PhoneShopContext())
            {
                var order = context.Orders.Find(ID);

                order.Status = status;

                context.Entry(order).State = EntityState.Modified;

                return context.SaveChanges() > 0;
            }
        }

        public int SaveOrder(Order order)
        {
            using (var context = new PhoneShopContext())
            {
                context.Orders.Add(order);
                return context.SaveChanges();
            }
        }
    }
}