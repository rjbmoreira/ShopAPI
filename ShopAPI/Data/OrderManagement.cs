using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAPI.Data
{
    public class OrderManagement : IOrderManagementRepository
    {

        private readonly DataContext _context;

        

        public OrderManagement(DataContext context)
        {
            _context = context;
        }

        

        public async Task<string> MakeNewOrder(IEnumerable<int> productIDs, IEnumerable<int> extraIDs, decimal valuePaid)
        {
            decimal totalPrice = 0;
            
            foreach(var pID in productIDs)
            {
                var product = _context.Products.Find(pID);
                if (product == null)
                {
                    return "Invalid request. Product not found.";
                }

                int stock = product.StockQty;
                if (stock < 1)
                {
                    return "Stock is not enough to fullfill the order.";
                }

                totalPrice += product.Price;

                if(totalPrice > valuePaid)
                {
                    return "Insuficient funds.";
                }

                product.StockQty = stock - 1;

                _context.Entry(product).Property(x => x.StockQty).IsModified = true;
            }

            foreach (var eID in extraIDs)
            {
                var extra = _context.Extras.Find(eID);
                if (extra == null)
                {
                    return "Invalid request. Extra not found.";
                }

                int stock = extra.StockQty;
                if (stock < 1)
                {
                    return "Stock is not enough to fullfill the order.";
                }

                totalPrice += extra.Price;

                if (totalPrice > valuePaid)
                {
                    return "Insuficient funds provided.";
                }

                extra.StockQty = stock - 1;

                _context.Entry(extra).Property(x => x.StockQty).IsModified = true;
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return "There was an error processing the order.";
            }

            decimal change = valuePaid - totalPrice;
            return $"Successful order. Customer's change is {change}";
        }


        private bool _disposed = false;
        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                
            }
            _disposed = true;
        }
    }
}
