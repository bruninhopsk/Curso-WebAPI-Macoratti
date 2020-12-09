using System.Linq;
using System.Threading.Tasks;
using Domain;
using Infrastructure.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private AppDataContext Context { get; }
        public CategoriesController(AppDataContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetAll()
        {
            var response = Context.Category.ToList();

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetById([FromServices] AppDataContext Context, [FromQuery] int categoryId)
        {
            var response = Context.Category.FirstOrDefault(x => x.CategoryId == categoryId);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create([FromBody] Category category)
        {
            Context.Add(category);
            Context.SaveChanges();

            return CreatedAtRoute(nameof(GetById), new { Id = category.CategoryId }, category);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Update([FromBody] Category category)
        {
            var productFound = Context.Category.AsNoTracking().FirstOrDefault(x => x.CategoryId == category.CategoryId);

            if (productFound == null)
            {
                return NoContent();
            }

            Context.Update(category);
            Context.SaveChanges();

            return Ok("Category has been updated");
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<ActionResult> Delete([FromQuery] int categoryId)
        {
            var productFound = Context.Category.AsNoTracking().FirstOrDefault(x => x.CategoryId == categoryId);

            if (productFound == null)
            {
                return NoContent();
            }

            Context.Category.Remove(productFound);
            Context.SaveChanges();

            return Ok("Category has been deleted");
        }
    }
}