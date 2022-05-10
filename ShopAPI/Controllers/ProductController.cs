using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopAPI.Data;
using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [Route("shopapi/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }



        // Get all products
        // GET: shopapi/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                if (products.Count == 0)
                {
                    return NotFound("No products found.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return NotFound("There was an error fetching the data.");
            }
        }

        // Get single product by Id
        // GET: shopapi/product/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            if (id < 1) { return BadRequest("Invalid Id"); }

            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound("Product not found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound("There was an error fetching the data.");
            }
        }

        // Add new product. Returns newly created product.
        // POST: shopapi/product
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product can not be null.");
            }

            _context.Products.Add(product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error adding the data.");
            }

            return Ok(product);
        }

        // Update a product. Returns updated product.
        // PUT: shopapi/product
        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product can not be null.");
            }

            var dbProduct = await _context.Products.FindAsync(product.Id);

            if (dbProduct == null)
            {
                return BadRequest("Product does not exist and therefore can not be updated.");
            }

            dbProduct.Update(product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error updating the data.");
            }

            return Ok(dbProduct);
        }


        // Deletes single product by Id. Returns deleted product.
        // DELETE: shopapi/product/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);


            if (product == null)
            {
                return NotFound("Product not found.");
            }

            _context.Products.Remove(product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error deleting the data.");
            }

            return Ok(product);
        }
    }
}
