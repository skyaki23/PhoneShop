using PhoneShop.Models;
using System.Collections.Generic;

namespace PhoneShop.ViewModels
{
    public class OrderViewModel
    {
        /// <summary>
        /// 訂單List
        /// </summary>
        public List<Order> Orders { get; set; }
    }

    public class OrderDetailViewModel
    {
        /// <summary>
        /// 訂單資訊
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// 訂單會員資訊
        /// </summary>
        public Member OrderMember { get; set; }
        /// <summary>
        /// 訂單狀態List
        /// </summary>
        public List<string> OrderStatuses { get; set; }
    }
}