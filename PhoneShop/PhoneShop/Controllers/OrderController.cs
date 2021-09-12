using PhoneShop.Models;
using PhoneShop.Services;
using PhoneShop.ViewModels;
using System.Collections.Generic;
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

        /// <summary>
        /// Order/OrderTable
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderTable()
        {
            //建立OrderViewModel物件，用於View上
            OrderViewModel model = new OrderViewModel();

            string UserId = null;

            if (Session["Member"] != null)
            {
                UserId = (Session["Member"] as Member).UserId;
            }

            //設定訂單List，透過會員帳號取得
            model.Orders = OrderService.Instance.GetOrders(UserId);

            return PartialView("OrderTable", model);
        }

        /// <summary>
        /// Order/Detail
        /// </summary>
        /// <param name="ID">訂單ID</param>
        /// <param name="UserID">會員帳號</param>
        /// <returns></returns>
        public ActionResult Detail(int ID, string UserID)
        {
            //建立OrderDetailViewModel物件，用於View上
            OrderDetailViewModel model = new OrderDetailViewModel();

            //設定訂單資訊
            model.Order = OrderService.Instance.GetOrderByID(ID);

            if (model.Order != null)
            {
                //設定訂單會員資訊
                model.OrderMember = MemberService.Instance.GetMember(UserID);
            }

            //設定訂單狀態List
            model.OrderStatuses = new List<string>() { "尚未成立", "成立", "未成立" };

            return PartialView(model);
        }

        /// <summary>
        /// 回傳Json資料(success: Boolean)使判斷訂單修改狀態成功與否
        /// </summary>
        /// <param name="ID">訂單ID</param>
        /// <param name="status">訂單狀態</param>
        /// <returns></returns>
        public JsonResult ChangeStatus(int ID, string status)
        {
            return Json(new { success = OrderService.Instance.UpdateOrderStatus(ID, status)}, JsonRequestBehavior.AllowGet);
        }
    }
}