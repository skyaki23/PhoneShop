using System;
using System.Collections.Generic;

namespace PhoneShop.Models
{
    public class Order
    {
        /// <summary>
        /// 訂單ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 會員ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 訂單下訂時間
        /// </summary>
        public DateTime OrderTime { get; set; }
        /// <summary>
        /// 訂單總價
        /// </summary>
        public int TotalAmount { get; set; }
        /// <summary>
        /// 訂單狀態
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 訂單產品項目List
        /// </summary>
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}