using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Order
    {
        public IEnumerable<int> ProductIDs { get; set; }

        public IEnumerable<int> ExtraIDs { get; set; }

        public decimal ValuePaid { get; set; } = -1;
    }
}
