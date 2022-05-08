using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Extra
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }


        public int StockQty { get; set; } = 0;


        public Extra Clone()
        {
            return new Extra()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Price = this.Price,
                StockQty = this.StockQty
            };
        }

        public void Update(Extra extra)
        {

            this.Name = extra.Name;
            this.Description = extra.Description;
            this.Price = extra.Price;
            this.StockQty = extra.StockQty;

        }
    }
}
