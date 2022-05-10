using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Data
{
    public interface IOrderManagementRepository : IDisposable
    {
        Task<string> MakeNewOrder(IEnumerable<int> productIDs, IEnumerable<int> extraIDs, decimal valuePaid);

    }
}
