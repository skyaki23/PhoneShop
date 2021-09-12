using PhoneShop.Models;
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

        public Category GetCategory(int ID)
        {
            using (var context = new PhoneShopContext())
            {
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
        /// 回傳所有產品品牌
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories()
        {
            using (var context = new PhoneShopContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetExistingCategory(Category category)
        {
            using (var context = new PhoneShopContext())
            {
                return context.Categories.Where(x => x.Name == category.Name).FirstOrDefault();
            }
        }

        public void SaveCategory(Category category)
        {
            using (var context = new PhoneShopContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new PhoneShopContext())
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

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