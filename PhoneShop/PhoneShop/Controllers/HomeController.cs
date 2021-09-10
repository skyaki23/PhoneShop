using PhoneShop.Models;
using PhoneShop.Services;
using PhoneShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PhoneShop.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home/Index
        /// </summary>
        /// <param name="searchTerm">搜尋關鍵字</param>
        /// <param name="minimumPrice">篩選最低價格</param>
        /// <param name="maximumPrice">篩選最高價格</param>
        /// <param name="categoryID">篩選產品品牌</param>
        /// <param name="sortBy">排序</param>
        /// <param name="pageNo">顯示的產品頁數</param>
        /// <returns></returns>
        public ActionResult Index(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            var pageSize = 6; // 一頁中所顯示的產品數量(設定有6個)

            //建立HomeViewModel物件，用於View上
            HomeViewModel model = new HomeViewModel();
            model.SearchTerm = searchTerm; // 設定搜尋關鍵字
            model.MaximumPrice = ProductService.Instance.GetMaximumPrice(); // 設定最高價格
            model.Categories = CategoryService.Instance.GetAllCategories(); // 設定所有產品品牌
            model.CategoryID = categoryID; // 設定產品品牌ID
            model.SortBy = sortBy; // 設定排序
            pageNo = pageNo.HasValue ? (pageNo.Value > 0 ? pageNo : 1) : 1; // 設定顯示的產品頁數，若無值則預設為1

            int totalCount = ProductService.Instance.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy); // 變數totalCount為篩選條件後的產品數量
            model.Products = ProductService.Instance.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize); // 設定篩選條件後的產品資訊

            model.Pager = new Pager(totalCount, pageNo, pageSize); // 設定產品分頁功能

            model.CarouselProducts = ProductService.Instance.GetCarouselProducts(); // 設定產品輪播圖

            return View(model);
        }

        /// <summary>
        /// Home/FilterProducts
        /// </summary>
        /// <param name="searchTerm">搜尋關鍵字</param>
        /// <param name="minimumPrice">篩選最低價格</param>
        /// <param name="maximumPrice">篩選最高價格</param>
        /// <param name="categoryID">篩選產品品牌</param>
        /// <param name="sortBy">排序</param>
        /// <param name="pageNo">顯示的產品頁數</param>
        /// <returns></returns>
        public ActionResult FilterProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            var pageSize = 6; // 一頁中所顯示的產品數量(設定有6個)

            //建立FilterProductsViewModel物件，用於View上
            FilterProductsViewModel model = new FilterProductsViewModel();
            model.SearchTerm = searchTerm; // 設定搜尋關鍵字
            model.CategoryID = categoryID; // 設定產品品牌ID
            model.SortBy = sortBy; // 設定排序
            pageNo = pageNo.HasValue ? (pageNo.Value > 0 ? pageNo : 1) : 1; // 設定顯示的產品頁數，若無值則預設為1

            int totalCount = ProductService.Instance.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy); // 變數totalCount為篩選條件後的產品數量
            model.Products = ProductService.Instance.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize); // 設定篩選條件後的產品資訊

            model.Pager = new Pager(totalCount, pageNo, pageSize); // 設定產品分頁功能

            return PartialView(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterMemberViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            var member = MemberService.Instance.GetMember(model.UserId);

            if (member == null)
            {
                var newMember = new Member();
                newMember.UserId = model.UserId;
                newMember.UserPassword = model.UserPassword;
                newMember.UserEmail = model.UserEmail;

                MemberService.Instance.SaveMember(newMember);
                return RedirectToAction("Index");
            }

            ViewBag.Message = "此帳號已被註冊，註冊失敗";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginMemberViewModel model)
        {
            var member = MemberService.Instance.LoginMember(model.UserId, model.UserPassword);

            if (!model.UserId.Equals("Admin"))
            {
                if (member == null)
                {
                    ViewBag.Message = "帳號密碼輸入錯誤，登入失敗";
                    return View();
                }

                Session["Welcome"] = "歡迎 " + member.UserId + " ~";
                Session["Member"] = member;
                return RedirectToAction("Index");
            }
            else
            {
                if (member == null)
                {
                    ViewBag.Message = "管理者帳號密碼輸入錯誤，登入失敗";
                    return View();
                }

                Session["Welcome"] = "管理者 " + member.UserId + " ~";
                Session["Admin"] = member;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult ShoppingCart()
        {
            ShoppingCartViewModel model = new ShoppingCartViewModel();

            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null && !string.IsNullOrEmpty(CartProductsCookie.Value))
            {
                model.CartProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();

                model.CartProducts = ProductService.Instance.GetProducts(model.CartProductIDs.Distinct().ToList());

                if (Session["Member"] != null)
                {
                    model.User = MemberService.Instance.GetMember((Session["Member"] as Member).UserId);
                }
                else
                {
                    model.User = null;
                }
            }

            return View(model);
        }

        public JsonResult PlaceOrder(string productIDs)
        {
            if (!string.IsNullOrEmpty(productIDs))
            {
                var productQuantities = productIDs.Split('-').Select(x => int.Parse(x)).ToList();

                var products = ProductService.Instance.GetProducts(productQuantities.Distinct().ToList());

                Order newOrder = new Order();
                newOrder.UserID = (Session["Member"] as Member).UserId;
                newOrder.OrderTime = DateTime.Now;
                newOrder.TotalAmount = products.Sum(x => x.Price * productQuantities.Where(productID => productID == x.ID).Count());
                newOrder.Status = "尚未成立";

                newOrder.OrderItems = new List<OrderItem>();
                newOrder.OrderItems.AddRange(products.Select(x => new OrderItem() { ProductID = x.ID, Quantity = productQuantities.Where(productID => productID == x.ID).Count() }));

                OrderService.Instance.SaveOrder(newOrder);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            } 
        }
    }
}