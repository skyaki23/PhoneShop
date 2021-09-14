using PhoneShop.Models;
using PhoneShop.Services;
using PhoneShop.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PhoneShop.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// Product/Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Product/ProductTable
        /// </summary>
        /// <param name="searchTerm">搜尋關鍵字</param>
        /// <param name="pageNo">顯示的產品頁數</param>
        /// <returns></returns>
        public ActionResult ProductTable(string searchTerm, int? pageNo)
        {
            var pageSize = 5; // 一頁中所顯示的產品數量(設定有5個)

            //建立ProductSearchViewModel物件，用於View上
            ProductSearchViewModel model = new ProductSearchViewModel();

            model.SearchTerm = searchTerm;// 設定搜尋關鍵字

            int totalCount = ProductService.Instance.SearchProductsCount(searchTerm, null, null, null, null); // 變數totalCount為篩選條件後的產品數量
            pageNo = pageNo.HasValue ? (pageNo.Value > 0 ? pageNo : 1) : 1; // 設定顯示的產品頁數，若無值則預設為1

            model.Products = ProductService.Instance.GetProducts(searchTerm, pageNo.Value, pageSize); // 設定篩選條件後的產品資訊
            model.Pager = new Pager(totalCount, pageNo, pageSize); // 設定產品分頁功能

            return PartialView("ProductTable", model);
        }

        #region Create
        /// <summary>
        /// Product/Create GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            //建立NewProductViewModel物件，用於View上
            NewProductViewModel model = new NewProductViewModel();

            model.Categories = CategoryService.Instance.GetAllCategories(); // 設定產品品牌List

            return PartialView(model);
        }

        /// <summary>
        /// Product/Create POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
            //建立Product物件
            var newProduct = new Product();
            newProduct.Name = model.Name; // 設定產品名稱
            newProduct.Price = model.Price; // 設定產品價格
            newProduct.Category = CategoryService.Instance.GetCategory(model.CategoryID); // 設定產品品牌資訊
            newProduct.ImageURL = model.ImageURL; // 設定產品圖片路徑

            //若產品不存在
            if (ProductService.Instance.GetExistingProduct(newProduct) == null)
            {
                ProductService.Instance.SaveProduct(newProduct); // 儲存產品

                TempData["ProductMessage"] = "產品新增成功: [" + newProduct.Name + "]"; // 加入TempData給予View顯示
            }
            else
            {
                TempData["ProductMessage"] = "產品已存在: [" + newProduct.Name + "]"; // 加入TempData給予View顯示
            }

            return RedirectToAction("ProductTable");
        }
        #endregion Create

        #region Update
        /// <summary>
        /// Product/Edit GET
        /// </summary>
        /// <param name="ID">產品ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            //建立EditProductViewModel，用於View上
            EditProductViewModel model = new EditProductViewModel();

            var product = ProductService.Instance.GetProduct(ID); // 得到產品資訊

            model.ID = product.ID; // 設定產品ID
            model.Name = product.Name; // 設定產品名稱
            model.Price = product.Price; // 設定產品價格
            model.ImageURL = product.ImageURL; // 設定產品圖片路徑
            model.CategoryID = product.CategoryID; // 設定產品品牌ID
            model.Categories = CategoryService.Instance.GetAllCategories(); // 設定品牌List

            return PartialView(model);
        }

        /// <summary>
        /// Product/Edit POST
        /// </summary>
        /// <param name="model">EditProductViewModel model</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = ProductService.Instance.GetProduct(model.ID); // 得到產品資訊
            existingProduct.Name = model.Name; // 設定產品名稱
            existingProduct.Price = model.Price; // 設定產品價格
            existingProduct.CategoryID = model.CategoryID; // 設定產品品牌ID

            if (!string.IsNullOrEmpty(model.ImageURL))
            {
                existingProduct.ImageURL = model.ImageURL; // 設定產品圖片路徑
            }

            ProductService.Instance.UpdateProduct(existingProduct); // 修改產品

            return RedirectToAction("ProductTable");
        }
        #endregion Update

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductService.Instance.DeleteProduct(ID); // 刪除產品

            return RedirectToAction("ProductTable");
        }
    }
}