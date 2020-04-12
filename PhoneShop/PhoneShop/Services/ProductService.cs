using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public Product GetProduct(int ID)
        {
            using (var context = new PhoneShopContext())
            {
                return context.Products.Find(ID);
            }
        }

        public List<Product> GetProducts()
        {
            using (var context = new PhoneShopContext())
            {
                return context.Products.Include(x => x.Category).ToList();
            }
        }

        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new PhoneShopContext())
            {
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList();
            }
        }

        public int GetMaximumPrice()
        {
            using (var context = new PhoneShopContext())
            {
                return (int)(context.Products.Max(x => x.Price));
            }
        }

        public int SearchProductsCount(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            using (var context = new PhoneShopContext())
            {
                var products = context.Products.ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.Category.ID == categoryID.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }

                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderBy(x => x.Price).ToList();
                            break;
                        case 3:
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.ID).ToList();       
                            break;
                    }
                }

                return products.Count;
            }
        }

        public List<Product> SearchProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int pageNo, int pageSize)
        {
            using (var context = new PhoneShopContext())
            {
                var products = context.Products.ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.Category.ID == categoryID.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }

                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderBy(x => x.Price).ToList();
                            break;
                        case 3:
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                    }
                }

                return products.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public void SaveProduct(Product product)
        {
            using (var context = new PhoneShopContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;

                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new PhoneShopContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

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