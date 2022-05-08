using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    

        public Category Clone()
        {
            return new Category()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
        }

        public void Update(Category category)
        {

            this.Name = category.Name;
            this.Description = category.Description;

        }
    }
}
