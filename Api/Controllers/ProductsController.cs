using System.Linq;
using System.Threading.Tasks;
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
    public class ProductsController : ControllerBase
    {
        private AppDataContext Context { get; }
        public ProductsController(AppDataContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public string GetAuthor([FromServices] IConfiguration configuration)
        {
            var author = configuration["author"];

            return $"Author: {author}";
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetAll()
        {
            var response = Context.Product.ToList();

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet(Name = "getById")]
        [Route("[action]")]
        public async Task<ActionResult> GetById([FromServices] AppDataContext Context, [FromQuery] int productId)
        {
            var response = Context.Product.FirstOrDefault(x => x.ProductId == productId);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create([FromBody] Product product)
        {
            Context.Add(product);
            Context.SaveChanges();

            return CreatedAtRoute(nameof(GetById), new { Id = product.ProductId }, product);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Update([FromBody] Product product)
        {
            var productFound = Context.Product.AsNoTracking().FirstOrDefault(x => x.ProductId == product.ProductId);

            if (productFound == null)
            {
                return NoContent();
            }

            Context.Update(product);
            Context.SaveChanges();

            return Ok("Product has been updated");
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<ActionResult> Delete([FromQuery] int productId)
        {
            var productFound = Context.Product.AsNoTracking().FirstOrDefault(x => x.ProductId == productId);

            if (productFound == null)
            {
                return NoContent();
            }

            Context.Product.Remove(productFound);
            Context.SaveChanges();

            return Ok("Product has been deleted");
        }
    }
}