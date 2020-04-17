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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryTable(string search)
        {
            CategorySearchViewModel model = new CategorySearchViewModel();

            model.Categories = CategoryService.Instance.GetCategories();

            if (!string.IsNullOrEmpty(search))
            {
                model.SearchTerm = search;
                model.Categories = model.Categories.Where(x => x.Name != null && x.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView("CategoryTable", model);
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            var newCategory = new Category();
            newCategory.Name = model.Name;
            newCategory.ImageURL = model.ImageURL;

            if (CategoryService.Instance.GetExistingCategory(newCategory) == null)
            {
                CategoryService.Instance.SaveCategory(newCategory);

                TempData["CategoryMessage"] = "種類新增成功: [" + newCategory.Name + "]";
            }
            else
            {
                TempData["CategoryMessage"] = "種類已存在: [" + newCategory.Name + "]";
            }

            return RedirectToAction("CategoryTable");
        }
        #endregion Create

        #region Update
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();

            var category = CategoryService.Instance.GetCategory(ID);

            model.ID = category.ID;
            model.Name = category.Name;      
            model.ImageURL = category.ImageURL;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var existingCategory = CategoryService.Instance.GetCategory(model.ID);
            existingCategory.Name = model.Name;
            existingCategory.ImageURL = model.ImageURL;

            CategoryService.Instance.UpdateCategory(existingCategory);

            return RedirectToAction("CategoryTable");
        }
        #endregion Update

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            CategoryService.Instance.DeleteCategory(ID);

            return RedirectToAction("CategoryTable");
        }
    }
}