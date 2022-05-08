

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
    public class ExtraController : ControllerBase
    {
        private readonly DataContext _context;

        public ExtraController(DataContext context)
        {
            _context = context;
        }



        // Get all extras
        // GET: shopapi/extra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extra>>> Get()
        {
            try
            {
                var extras = await _context.Extras.ToListAsync();
                if (extras.Count == 0)
                {
                    return NotFound("No extras found.");
                }
                return Ok(extras);
            }
            catch (Exception ex)
            {
                return NotFound("There was an error fetching the data.");
            }
        }

        // Get single extra by Id
        // GET: shopapi/extra/{id}
        [HttpGet("{id}", Name = "GetExtraById")]
        public async Task<ActionResult<Extra>> Get(int id)
        {
            if (id < 1) { return BadRequest("Invalid Id"); }

            try
            {
                var extra = await _context.Extras.FindAsync(id);
                if (extra == null)
                {
                    return NotFound("Extra not found.");
                }
                return Ok(extra);
            }
            catch (Exception ex)
            {
                return NotFound("There was an error fetching the data.");
            }
        }

        // Add new extra. Returns newly created extra.
        // POST: shopapi/extra
        [HttpPost]
        public async Task<ActionResult<Extra>> AddExtra(Extra extra)
        {
            if (extra == null)
            {
                return BadRequest("Extra can not be null.");
            }

            _context.Extras.Add(extra);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error adding the data.");
            }

            return Ok(extra);
        }

        // Update a extra. Returns updated extra.
        // PUT: shopapi/extra
        [HttpPut]
        public async Task<ActionResult<Extra>> UpdateExtra(Extra extra)
        {
            if (extra == null)
            {
                return BadRequest("Extra can not be null.");
            }

            var dbExtra = await _context.Extras.FindAsync(extra.Id);

            if (dbExtra == null)
            {
                return BadRequest("Extra does not exist and therefore can not be updated.");
            }

            dbExtra.Update(extra);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error updating the data.");
            }

            return Ok(dbExtra);
        }


        // Deletes single extra by Id. Returns deleted extra.
        // DELETE: shopapi/extra/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Extra>> Delete(int id)
        {
            var extra = await _context.Extras.FindAsync(id);


            if (extra == null)
            {
                return NotFound("Extra not found.");
            }

            _context.Extras.Remove(extra);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("There was an error deleting the data.");
            }

            return Ok(extra);
        }
    }
}
