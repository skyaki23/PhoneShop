using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneShop.ViewModels
{
    public class OrderViewModel
    {
        public List<Order> Orders { get; set; }
    }

    public class OrderDetailViewModel
    {
        public Order Order { get; set; }
        public Member OrderMember { get; set; }
        public List<string> OrderStatuses { get; set; }
    }
}