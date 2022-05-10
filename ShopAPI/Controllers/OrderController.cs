using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopAPI.Data;
using ShopAPI.Models;
//using ShopAPI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [Route("shopapi/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManagementRepository _omRepository;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IOrderManagementRepository omRepository)
        {
            _logger = logger;
            _omRepository = omRepository;
        }

        // Make new order.
        // POST: shopapi/order
        [HttpPost]
        public async Task<ActionResult<string>> MakeNewOrder(Order order)
        {
            if (order.ProductIDs == null || !order.ProductIDs.Any() || order.ValuePaid < 0) //allowing 0 for free items
            {
                return BadRequest("Invalid request.");
            }

            return Ok(await _omRepository.MakeNewOrder(order.ProductIDs, order.ExtraIDs, order.ValuePaid));
        }
    }
}
