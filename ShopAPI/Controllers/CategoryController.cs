using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [Route("shopapi/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        

        // Get all categories
        // GET: shopapi/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                if(categories.Count == 0)
                {
                    return NotFound("No categories found.");
                }
                return Ok(categories);
            } catch(Exception ex)
            {
                return NotFound("There was an error fetching the data.");
            }
        }

        // Get single category by Id
        // GET: shopapi/category/{id}
        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            if(id < 1) { return BadRequest("Invalid Id"); }

            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound("Category not found.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound("There was an error fetching the data.");
            }
        }

        // Add new category. Returns newly created category.
        // POST: shopapi/category
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            if(category == null)
            {
                return BadRequest("Category can not be null.");
            }

            _context.Categories.Add(category);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error adding the data.");
            }

            return Ok(category);
        }

        // Update a category. Returns updated category.
        // PUT: shopapi/category
        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest("Category can not be null.");
            }

            var dbCategory = await _context.Categories.FindAsync(category.Id);

            if(dbCategory == null)
            {
                return BadRequest("Category does not exist and therefore can not be updated.");
            }

            dbCategory.Update(category);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error updating the data.");
            }

            return Ok(dbCategory);
        }


        // Deletes single category by Id. Returns deleted category.
        // DELETE: shopapi/category/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);


            if (category == null)
            {
                return NotFound("Category not found.");
            }

            _context.Categories.Remove(category);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error deleting the data.");
            }

            return Ok(category);
        }

    }
}
