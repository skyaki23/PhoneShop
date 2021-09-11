
namespace PhoneShop.Models
{
    public class OrderItem
    {
        /// <summary>
        /// 訂單項目ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 訂單ID
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// 訂單資訊
        /// </summary>
        public virtual Order Order { get; set; }
        /// <summary>
        /// 訂單項目產品ID
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 訂單項目產品資訊
        /// </summary>
        public virtual Product Product { get; set; }
        /// <summary>
        /// 訂單項目產品數量
        /// </summary>
        public int Quantity { get; set; }
    }
}