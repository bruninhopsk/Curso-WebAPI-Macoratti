using System.Linq;
using System.Threading.Tasks;
using Api.Filters;
using Domain;
using Infrastructure.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        [ServiceFilter(typeof(ApiLoggingFilter))]
        [Route("[action]")]
        public string GetAuthor([FromServices] IConfiguration configuration)
        {
            var author = configuration["author"];

            return $"Author: {author}";
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetProducts()
        {
            var categoriesWithProducts = Context.Category.AsNoTracking().Include(x => x.Products);

            return Ok(categoriesWithProducts);
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