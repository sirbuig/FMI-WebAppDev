using Lab4_24.Data;
using Lab4_24.Models.DTOs;
using Lab4_24.Models.One_to_Many;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4_24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        public readonly Lab4Context _lab4Context;
        public DatabaseController(Lab4Context lab4Context)
        {
            _lab4Context = lab4Context;
        }

        [HttpGet("model1")]
        public async Task<IActionResult> GetModel1()
        {
            return Ok(await _lab4Context.Models1.ToListAsync());
        }

        [HttpPost("model1")]
        public async Task<IActionResult> Create(Model1Dto model1Dto)
        {
            var newModel1 = new Model1
            {
                Id = Guid.NewGuid(),
                Name = model1Dto.Name
            };

            // adding new item
            await _lab4Context.AddAsync(newModel1);

            // saving the item is required otherwise the object is not commited to the database
            await _lab4Context.SaveChangesAsync();

            return Ok(newModel1);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Model1Dto model1Dto)
        {
            Model1 model1ById = await _lab4Context.Models1.FirstOrDefaultAsync(x => x.Id == model1Dto.Id);

            if (model1ById == null)
            {
                return BadRequest($"Object with id: {model1Dto.Id} does not exist in the database");
            }

            model1ById.Name = model1Dto.Name;

            // update
            _lab4Context.Update(model1ById);

            // commit
            await _lab4Context.SaveChangesAsync();

            return Ok(model1ById);
        }
    }
}
