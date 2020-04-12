using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneShop.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public DateTime OrderTime { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}