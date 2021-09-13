using PhoneShop.Models;
using PhoneShop.Services;
using PhoneShop.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PhoneShop.Controllers
{
    public class CategoryController : Controller
    {
        /// <summary>
        /// Category/Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Category/CategoryTable
        /// </summary>
        /// <param name="searchTerm">搜尋關鍵字</param>
        /// <returns></returns>
        public ActionResult CategoryTable(string searchTerm)
        {
            //建立CategorySearchViewModel物件，用於View上
            CategorySearchViewModel model = new CategorySearchViewModel();

            model.Categories = CategoryService.Instance.GetCategories(); // 設定品牌資訊List

            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm; // 設定搜尋關鍵字

                //設定品牌資訊List為包含搜尋關鍵字
                model.Categories = model.Categories.Where(x => x.Name != null && x.Name.ToLower().Contains(model.SearchTerm.ToLower())).ToList();
            }

            return PartialView("CategoryTable", model);
        }

        #region Create
        /// <summary>
        /// Category/Create GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        /// <summary>
        /// Category/Create POST
        /// </summary>
        /// <param name="model">NewCategoryViewModel model</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            //建立Category物件
            var newCategory = new Category();
            newCategory.Name = model.Name; // 設定品牌名稱
            newCategory.ImageURL = model.ImageURL; // 設定品牌圖片路徑

            //若品牌不存在
            if (CategoryService.Instance.GetExistingCategory(newCategory) == null)
            {
                CategoryService.Instance.SaveCategory(newCategory); // 儲存品牌

                TempData["CategoryMessage"] = "種類新增成功: [" + newCategory.Name + "]"; // 加入TempData給予View顯示
            }
            else
            {
                TempData["CategoryMessage"] = "種類已存在: [" + newCategory.Name + "]"; // 加入TempData給予View顯示
            }

            return RedirectToAction("CategoryTable");
        }
        #endregion Create

        #region Update
        /// <summary>
        /// Category/Edit GET
        /// </summary>
        /// <param name="ID">品牌ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            //建立EditCategoryViewModel，用於View上
            EditCategoryViewModel model = new EditCategoryViewModel();

            var category = CategoryService.Instance.GetCategory(ID); // 得到品牌資訊

            model.ID = category.ID; // 設定品牌ID
            model.Name = category.Name; // 設定品牌名稱
            model.ImageURL = category.ImageURL; // 設定品牌圖片路徑

            return PartialView(model);
        }

        /// <summary>
        /// Category/Edit POST
        /// </summary>
        /// <param name="model">EditCategoryViewModel model</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var existingCategory = CategoryService.Instance.GetCategory(model.ID); // 得到品牌資訊
            existingCategory.Name = model.Name; // 設定品牌ID
            existingCategory.ImageURL = model.ImageURL; // 設定品牌圖片路徑

            CategoryService.Instance.UpdateCategory(existingCategory); // 修改品牌

            return RedirectToAction("CategoryTable");
        }
        #endregion Update

        /// <summary>
        /// Category/Delete POST
        /// </summary>
        /// <param name="ID">品牌ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            CategoryService.Instance.DeleteCategory(ID); // 刪除品牌

            return RedirectToAction("CategoryTable");
        }
    }
}