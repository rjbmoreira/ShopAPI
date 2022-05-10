using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Data
{
    public static class DbDataInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();


            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                new Category{Name="Espresso Drinks",Description="Hot drinks"},
                new Category{Name="Brewed Coffee",Description="Brewed products to sell"},
                new Category{Name="Tea",Description="All kinds of tea"},
                
                };

                foreach (Category cat in categories)
                {
                    context.Categories.Add(cat);              
                }
                context.SaveChanges();

                //products
                var products = new Product[]
                {
                new Product{Name="Latte",Description="", Price=3, StockQty = 10, CategoryId = context.Categories.Where(c => c.Name == "Espresso Drinks").FirstOrDefault().Id},
                new Product{Name="Mocha",Description="", Price=4.4m, StockQty = 15, CategoryId = context.Categories.Where(c => c.Name == "Espresso Drinks").FirstOrDefault().Id},
                new Product{Name="Machhiato",Description="", Price=5.1m, StockQty = 11, CategoryId = context.Categories.Where(c => c.Name == "Espresso Drinks").FirstOrDefault().Id},
                new Product{Name="Cappuccino",Description="", Price=8, StockQty = 22, CategoryId = context.Categories.Where(c => c.Name == "Espresso Drinks").FirstOrDefault().Id},
                new Product{Name="Americano",Description="", Price=2.1m, StockQty = 33, CategoryId = context.Categories.Where(c => c.Name == "Espresso Drinks").FirstOrDefault().Id},
                new Product{Name="Espresso",Description="", Price=1.5m, StockQty = 44, CategoryId = context.Categories.Where(c => c.Name == "Espresso Drinks").FirstOrDefault().Id},
                new Product{Name="Filter coffee",Description="", Price=35, StockQty = 55, CategoryId = context.Categories.Where(c => c.Name == "Brewed Coffee").FirstOrDefault().Id},
                new Product{Name="Caffe Misto",Description="", Price=17, StockQty = 6, CategoryId = context.Categories.Where(c => c.Name == "Brewed Coffee").FirstOrDefault().Id},
                new Product{Name="Mint",Description="", Price=3, StockQty = 3, CategoryId = context.Categories.Where(c => c.Name == "Tea").FirstOrDefault().Id},
                new Product{Name="Chamomile Herbal",Description="", Price=5, StockQty = 5, CategoryId = context.Categories.Where(c => c.Name == "Tea").FirstOrDefault().Id},
                new Product{Name="Earl Grey",Description="", Price=4, StockQty = 11, CategoryId = context.Categories.Where(c => c.Name == "Tea").FirstOrDefault().Id}
                };

                foreach (Product p in products)
                {
                    context.Products.Add(p);
                }

                context.SaveChanges();

                //extras
                var extras = new Extra[]
                {
                new Extra{Name="Cinnamon",Description="", Price=1, StockQty = 10},
                new Extra{Name="Yellow sugar",Description="", Price=1.4m, StockQty = 15},
                new Extra{Name="Syrup",Description="", Price=1.1m, StockQty = 11},
                new Extra{Name="Whipped Cream",Description="", Price=2, StockQty = 22}
                };

                foreach (Extra e in extras)
                {
                    context.Extras.Add(e);
                }

                context.SaveChanges();
            }

        }
    }
}
