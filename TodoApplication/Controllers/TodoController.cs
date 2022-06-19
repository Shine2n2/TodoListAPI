using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplication.Data;
using TodoApplication.Models;

namespace TodoApplication.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TodoController : ControllerBase
    {
        private readonly ApiDbContext _apiDbContext;
        public TodoController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _apiDbContext.Items.ToListAsync();
            List<ItemData> itemsList = new ();
            foreach (var item in items)
            {
                if (item.IsActive == true) itemsList.Add(item);
            }

            return Ok(itemsList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemData itemData)
        {
            if (ModelState.IsValid)
            {
                await _apiDbContext.AddAsync(itemData);
                await _apiDbContext.SaveChangesAsync();

                return CreatedAtAction("GetItem", new { itemData.Id }, itemData);
            }
            return BadRequest("Something Went Wrong");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var Item = await _apiDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(Item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, ItemData itemData)
        {
            if (id != itemData.Id) return BadRequest();

            var existItem = await _apiDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);

            if(existItem == null) return NotFound();

            existItem.Tittle = itemData.Tittle;
            existItem.Description = itemData.Description;
            existItem.Done = itemData.Done;

            await _apiDbContext.SaveChangesAsync(); ;
            return NoContent();
        }

        [HttpPut(nameof(DesactivateTodoById))]
        public async Task<IActionResult> DesactivateTodoById(int id)
        {
            var existItem = await _apiDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            existItem.IsActive = false;
            await _apiDbContext.SaveChangesAsync(); 
            return NoContent();
        }

        [HttpPut(nameof(ReActivateTodobyId))]
        public async Task<IActionResult> ReActivateTodobyId(int id)
        {
            var existItem = await _apiDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            existItem.IsActive = true;
            await _apiDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var existItem = await _apiDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(existItem == null) return NotFound();

            _apiDbContext.Items.Remove(existItem);
            await _apiDbContext.SaveChangesAsync(); 

            return Ok(existItem);
        }
    }
}
