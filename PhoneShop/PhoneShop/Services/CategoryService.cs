﻿using PhoneShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace PhoneShop.Services
{
    public class CategoryService
    {
        #region Singleton
        public static CategoryService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryService();
                }
                return instance;
            }
        }
        private static CategoryService instance { get; set; }
        private CategoryService()
        {

        }
        #endregion

        /// <summary>
        /// 回傳品牌資訊
        /// </summary>
        /// <param name="ID">品牌ID</param>
        /// <returns></returns>
        public Category GetCategory(int ID)
        {
            using (var context = new PhoneShopContext())
            {
                //用品牌ID找到欲查詢品牌資訊
                return context.Categories.Find(ID);
            }
        }

        /// <summary>
        /// 回傳品牌資訊List
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            using (var context = new PhoneShopContext())
            {
                //找到品牌資訊並帶上產品資訊
                return context.Categories.Include(x => x.Products).ToList();
            }
        }

        /// <summary>
        /// 回傳品牌List
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories()
        {
            using (var context = new PhoneShopContext())
            {
                return context.Categories.ToList();
            }
        }

        /// <summary>
        /// 回傳品牌資訊
        /// </summary>
        /// <param name="category">品牌資訊</param>
        /// <returns></returns>
        public Category GetExistingCategory(Category category)
        {
            using (var context = new PhoneShopContext())
            {
                //回傳品牌資訊，預設回傳null
                return context.Categories.Where(x => x.Name == category.Name).FirstOrDefault();
            }
        }

        /// <summary>
        /// 儲存品牌
        /// </summary>
        /// <param name="category">品牌資訊</param>
        public void SaveCategory(Category category)
        {
            using (var context = new PhoneShopContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 修改品牌
        /// </summary>
        /// <param name="category">品牌資訊</param>
        public void UpdateCategory(Category category)
        {
            using (var context = new PhoneShopContext())
            {
                //修改品牌
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 刪除品牌
        /// </summary>
        /// <param name="ID">品牌ID</param>
        public void DeleteCategory(int ID)
        {
            using (var context = new PhoneShopContext())
            {
                var category = context.Categories.Find(ID);
                
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}