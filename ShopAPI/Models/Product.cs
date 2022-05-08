using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int StockQty { get; set; } = 0;

        [Required]
        public int CategoryId { get; set; }

        


        public Product Clone()
        {
            return new Product()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Price = this.Price,
                StockQty = this.StockQty,
                CategoryId = this.CategoryId

            };
        }

        public void Update(Product product)
        {

            this.Name = product.Name;
            this.Description = product.Description;
            this.Price = product.Price;
            this.StockQty = product.StockQty;
            this.CategoryId = product.CategoryId;

        }
    }
}
