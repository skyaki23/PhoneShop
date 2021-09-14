﻿using PhoneShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace PhoneShop.Services
{
    public class ProductService
    {
        #region Singleton
        public static ProductService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductService();
                }

                return instance;
            }
        }
        private static ProductService instance { get; set; }
        private ProductService()
        {

        }
        #endregion

        /// <summary>
        /// 回傳產品資訊
        /// </summary>
        /// <param name="ID">品牌ID</param>
        /// <returns></returns>
        public Product GetProduct(int ID)
        {
            using (var context = new PhoneShopContext())
            {
                return context.Products.Find(ID);
            }
        }

        /// <summary>
        /// 回傳產品資訊List
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            using (var context = new PhoneShopContext())
            {
                //找到產品資訊並帶上品牌資訊
                return context.Products.Include(x => x.Category).ToList();
            }
        }

        /// <summary>
        /// 回傳篩選條件後的產品資訊(for ProductTable)
        /// </summary>
        /// <param name="searchTerm">搜尋關鍵字</param>
        /// <param name="pageNo">顯示產品頁數</param>
        /// <param name="pageSize">一頁中所顯示的產品數量</param>
        /// <returns></returns>
        public List<Product> GetProducts(string searchTerm, int pageNo, int pageSize)
        {
            using (var context = new PhoneShopContext())
            {
                var products = context.Products.Include(x => x.Category).ToList(); // 先得到所有產品資訊帶上品牌資訊

                //若有搜尋關鍵字
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    //則篩選出產品名稱包含搜尋關鍵字的產品資訊
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                //e.g. pageNo = 1、pageSize = 6
                //products.Skip((1 - 1) * 6) => 資料全取，
                //products.Skip((1 - 1) * 6).Take(6) => 取前6筆資料。
                //*若pageNo = 2，表示按產品列表第2頁，products.Skip((2 - 1) * 6).Take(6) =>
                //Skip(6)使不取前6筆資料，只取之後的資料；接著Take(6)再取其前6筆資料
                return products.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        /// <summary>
        /// 回傳產品資訊List
        /// </summary>
        /// <param name="IDs">需回傳的產品ID List</param>
        /// <returns></returns>
        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new PhoneShopContext())
            {
                //找出Products含有每筆IDs item的產品資訊後成List回傳
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList();
            }
        }

        /// <summary>
        /// 回傳產品最高價格
        /// </summary>
        /// <returns></returns>
        public int GetMaximumPrice()
        {
            using (var context = new PhoneShopContext())
            {
                return (int)(context.Products.Max(x => x.Price));
            }
        }

        /// <summary>
        /// 回傳篩選條件後的產品數量
        /// </summary>
        /// <param name="searchTerm">搜尋關鍵字</param>
        /// <param name="minimumPrice">篩選最低價格</param>
        /// <param name="maximumPrice">篩選最高價格</param>
        /// <param name="categoryID">篩選產品品牌</param>
        /// <param name="sortBy">排序</param>
        /// <returns></returns>
        public int SearchProductsCount(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            using (var context = new PhoneShopContext())
            {
                var products = context.Products.ToList(); // 先得到所有產品資訊

                //若有篩選產品品牌
                if (categoryID.HasValue)
                {
                    //則篩選出選擇的產品品牌的產品資訊
                    products = products.Where(x => x.Category.ID == categoryID.Value).ToList();
                }

                //若有搜尋關鍵字
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    //則篩選出產品名稱包含搜尋關鍵字的產品資訊
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                //若有篩選最低價格
                if (minimumPrice.HasValue)
                {
                    //則篩選出產品價格高、等於篩選最低價格的產品資訊
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }

                //若有篩選最高價格
                if (maximumPrice.HasValue)
                {
                    //則篩選出產品價格低、等於篩選最高價格的產品資訊
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }

                //若有排序
                if (sortBy.HasValue)
                {
                    //則判斷排序是需依照哪一種排序
                    switch (sortBy.Value)
                    {
                        case 2: // 2: 將產品資訊依照價格低至高做排序
                            products = products.OrderBy(x => x.Price).ToList();
                            break;
                        case 3: // 3: 將產品資訊依照價格高至低做排序
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                        default: // default: 將產品資訊依照ID做排序
                            products = products.OrderByDescending(x => x.ID).ToList();       
                            break;
                    }
                }

                return products.Count;
            }
        }

        /// <summary>
        /// 回傳篩選條件後的產品資訊
        /// </summary>
        /// <param name="searchTerm">搜尋關鍵字</param>
        /// <param name="minimumPrice">篩選最低價格</param>
        /// <param name="maximumPrice">篩選最高價格</param>
        /// <param name="categoryID">篩選產品品牌</param>
        /// <param name="sortBy">排序</param>
        /// <param name="pageNo">顯示產品頁數</param>
        /// <param name="pageSize">一頁中所顯示的產品數量</param>
        /// <returns></returns>
        public List<Product> SearchProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int pageNo, int pageSize)
        {
            using (var context = new PhoneShopContext())
            {
                var products = context.Products.ToList(); // 先得到所有產品資訊

                //若有篩選產品品牌
                if (categoryID.HasValue)
                {
                    //則篩選出選擇的產品品牌的產品資訊
                    products = products.Where(x => x.Category.ID == categoryID.Value).ToList();
                }

                //若有搜尋關鍵字
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    //則篩選出產品名稱包含搜尋關鍵字的產品資訊
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                //若有篩選最低價格
                if (minimumPrice.HasValue)
                {
                    //則篩選出產品價格高、等於篩選最低價格的產品資訊
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }

                //若有篩選最高價格
                if (maximumPrice.HasValue)
                {
                    //則篩選出產品價格低、等於篩選最高價格的產品資訊
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }

                //若有排序
                if (sortBy.HasValue)
                {
                    //則判斷排序是需依照哪一種排序
                    switch (sortBy.Value)
                    {
                        case 2: // 2: 將產品資訊依照價格低至高做排序
                            products = products.OrderBy(x => x.Price).ToList();
                            break;
                        case 3: // 3: 將產品資訊依照價格高至低做排序
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                        default: // default: 將產品資訊依照ID做排序
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                    }
                }

                //e.g. pageNo = 1、pageSize = 6
                //products.Skip((1 - 1) * 6) => 資料全取，
                //products.Skip((1 - 1) * 6).Take(6) => 取前6筆資料。
                //*若pageNo = 2，表示按產品列表第2頁，products.Skip((2 - 1) * 6).Take(6) =>
                //Skip(6)使不取前6筆資料，只取之後的資料；接著Take(6)再取其前6筆資料
                return products.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        /// <summary>
        /// 回傳產品輪播圖資訊
        /// </summary>
        /// <returns></returns>
        public List<Product> GetCarouselProducts()
        {
            using(var context = new PhoneShopContext())
            {
                //為lazy load而使用Include，之後再取最新ID的前5筆資訊
                return context.Products.Include(x => x.Category).ToList().OrderByDescending(x => x.ID).Take(5).ToList();
            }
        }

        /// <summary>
        /// 回傳產品資訊
        /// </summary>
        /// <param name="product">產品資訊</param>
        /// <returns></returns>
        public Product GetExistingProduct(Product product)
        {
            using (var context = new PhoneShopContext())
            {
                //回傳產品資訊，預設回傳null
                return context.Products.Where(x => x.Category.ID == product.Category.ID && x.Name == product.Name).FirstOrDefault();
            }
        }

        /// <summary>
        /// 儲存產品
        /// </summary>
        /// <param name="product">產品資訊</param>
        public void SaveProduct(Product product)
        {
            using (var context = new PhoneShopContext())
            {
                context.Entry(product.Category).State = EntityState.Unchanged; // 不向資料庫增加品牌
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 修改產品
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            using (var context = new PhoneShopContext())
            {
                //修改產品
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 刪除產品
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteProduct(int ID)
        {
            using (var context = new PhoneShopContext())
            {
                var product = context.Products.Find(ID);

                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}