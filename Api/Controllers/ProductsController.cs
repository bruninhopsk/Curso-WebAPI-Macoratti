using Api.Filters;
using Domain;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork UnitOfWork { get; }

        public ProductsController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
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
        public ActionResult GetAll()
        {
            try
            {
                var products = UnitOfWork.ProductRepository.GetAll();

                if (products.Count == 0)
                {
                    return NoContent();
                }

                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error unexpected occurred.");
            }
        }

        [HttpGet(Name = "getById")]
        [Route("[action]")]
        public ActionResult GetById([FromQuery] int productId)
        {
            try
            {
                var product = UnitOfWork.ProductRepository.GetById(x => x.ProductId == productId);

                if (product == null)
                {
                    return NoContent();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error unexpected occurred.");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Create([FromBody] Product product)
        {
            try
            {
                UnitOfWork.ProductRepository.Add(product);
                UnitOfWork.Commit();

                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error unexpected occurred.");
            }
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult Update([FromBody] Product product)
        {
            try
            {
                var productFound = UnitOfWork.ProductRepository.GetById(x => x.ProductId == product.ProductId);

                if (productFound == null)
                {
                    return NoContent();
                }

                UnitOfWork.ProductRepository.Update(product);
                UnitOfWork.Commit();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error unexpected occurred.");
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult Delete([FromQuery] int productId)
        {
            try
            {
                var productFound = UnitOfWork.ProductRepository.GetById(x => x.ProductId == productId);

                if (productFound == null)
                {
                    return NoContent();
                }

                UnitOfWork.ProductRepository.Remove(productFound);
                UnitOfWork.Commit();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error unexpected occurred.");
            }
        }
    }
}