using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dockertraining_compose_abel_vallejo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dockertraining_compose_abel_vallejo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodContext db;

        public FoodController(FoodContext context)
        {
            db = context;
        }


        // Get department with given id.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFood(int id)
        {
            var food = await db.Foods.FindAsync(id);
            if (food == default(Food))
            {
                return NotFound();
            }
            return Ok(food);
        }

        // Add a department to db.
        [HttpPost]
        public async Task<IActionResult> AddFood([FromBody] Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.AddAsync(food);
            await db.SaveChangesAsync();
            return Ok(food.Id);
        }

        // Delete department with given id.
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await db.Foods.FindAsync(id);


            if (food == default(Food))
            {
                return NotFound();
            }

            db.Remove(food);
            await db.SaveChangesAsync();

            return Ok(food);
        }
    }
}