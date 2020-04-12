using PhoneShop.Services;
using PhoneShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneShop.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderTable()
        {
            OrderViewModel model = new OrderViewModel();

            model.Orders = OrderService.Instance.GetOrders();

            return PartialView("OrderTable", model);
        }

        public ActionResult Detail(int ID, string UserID)
        {
            OrderDetailViewModel model = new OrderDetailViewModel();

            model.Order = OrderService.Instance.GetOrderByID(ID);

            if (model.Order != null)
            {
                model.OrderMember = MemberService.Instance.GetMember(UserID);
            }

            model.OrderStatuses = new List<string>() { "尚未成立", "成立", "未成立" };

            return PartialView(model);
        }

        public JsonResult ChangeStatus(int ID, string status)
        {
            return Json(new { success = OrderService.Instance.UpdateOrderStatus(ID, status)}, JsonRequestBehavior.AllowGet);
        }
    }
}