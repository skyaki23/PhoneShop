using PhoneShop.Models;
using PhoneShop.Services;
using PhoneShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search)
        {
            ProductSearchViewModel model = new ProductSearchViewModel();

            model.Products = ProductService.Instance.GetProducts();

            if (!string.IsNullOrEmpty(search))
            {
                model.SearchTerm = search;
                model.Products = model.Products.Where(x => x.Name != null && x.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView("ProductTable", model);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();

            model.Categories = CategoryService.Instance.GetAllCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Price = model.Price;
            newProduct.Category = CategoryService.Instance.GetCategory(model.CategoryID);
            newProduct.ImageURL = model.ImageURL;

            ProductService.Instance.SaveProduct(newProduct);

            return RedirectToAction("ProductTable");
        }
        #endregion Create

        #region Update
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();

            var product = ProductService.Instance.GetProduct(ID);

            model.ID = product.ID;
            model.Name = product.Name;
            model.Price = product.Price;
            model.ImageURL = product.ImageURL;
            model.CategoryID = product.CategoryID;

            model.Categories = CategoryService.Instance.GetAllCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = ProductService.Instance.GetProduct(model.ID);
            existingProduct.Name = model.Name;
            existingProduct.Price = model.Price;
            existingProduct.CategoryID = model.CategoryID;

            if (!string.IsNullOrEmpty(model.ImageURL))
            {
                existingProduct.ImageURL = model.ImageURL;
            }

            ProductService.Instance.UpdateProduct(existingProduct);

            return RedirectToAction("ProductTable");
        }
        #endregion Update

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductService.Instance.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }
    }
}