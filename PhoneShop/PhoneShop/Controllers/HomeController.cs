using PhoneShop.Services;
using PhoneShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            var pageSize = 6;

            HomeViewModel model = new HomeViewModel();
            model.SearchTerm = searchTerm;
            model.MaximumPrice = ProductService.Instance.GetMaximumPrice();
            model.Categories = CategoryService.Instance.GetAllCategories();
            model.CategoryID = categoryID;
            model.SortBy = sortBy; 
            pageNo = pageNo.HasValue ? (pageNo.Value > 0 ? pageNo : 1) : 1;

            int totalCount = ProductService.Instance.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            model.Products = ProductService.Instance.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount, pageNo, pageSize);

            return View(model);
        }

        public ActionResult FilterProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            var pageSize = 6;

            FilterProductsViewModel model = new FilterProductsViewModel();
            model.SearchTerm = searchTerm;
            model.CategoryID = categoryID;
            model.SortBy = sortBy;
            pageNo = pageNo.HasValue ? (pageNo.Value > 0 ? pageNo : 1) : 1;

            int totalCount = ProductService.Instance.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            model.Products = ProductService.Instance.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount, pageNo, pageSize);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}