using PhoneShop.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        /// <summary>
        /// 回傳訂單資訊List
        /// </summary>
        /// <param name="UserId">會員帳號</param>
        /// <returns></returns>
        public List<Order> GetOrders(string UserId)
        {
            using (var context = new PhoneShopContext())
            {
                var orders = context.Orders.ToList(); // 先取得所有訂單

                if (!string.IsNullOrEmpty(UserId))
                {
                    orders = orders.Where(x => x.UserID == UserId).ToList(); // 找出符合傳入會員帳號相同的訂單
                }

                return orders;
            }
        }

        /// <summary>
        /// 回傳訂單資訊
        /// </summary>
        /// <param name="ID">訂單ID</param>
        /// <returns></returns>
        public Order GetOrderByID(int ID)
        {
            using (var context = new PhoneShopContext())
            {
                //用訂單ID找到欲查詢訂單資訊，再找到其訂單產品項目資訊及產品資訊
                return context.Orders.Where(x => x.ID == ID).Include(x => x.OrderItems).Include("OrderItems.Product").FirstOrDefault();
            }
        }

        /// <summary>
        /// 修改訂單狀態
        /// </summary>
        /// <param name="ID">訂單ID</param>
        /// <param name="status">訂單狀態</param>
        /// <returns></returns>
        public bool UpdateOrderStatus(int ID, string status)
        {
            using (var context = new PhoneShopContext())
            {
                var order = context.Orders.Find(ID); // 找到訂單

                order.Status = status; // 修改訂單狀態文字

                // 修改訂單
                context.Entry(order).State = EntityState.Modified;

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 儲存訂單
        /// </summary>
        /// <param name="order">訂單資訊</param>
        /// <returns></returns>
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