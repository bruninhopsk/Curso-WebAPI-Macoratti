using Api.Filters;
using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
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
        public ActionResult GetAll([FromQuery] ProductParameters parameters)
        {
            try
            {
                var products = UnitOfWork.ProductRepository.GetProducts(parameters);

                if (products.Count == 0)
                {
                    return NoContent();
                }

                var productsDto = Mapper.Map<List<ProductDTO>>(products);

                return Ok(productsDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error unexpected occurred.");
            }
        }

        [HttpGet]
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

                var productDto = Mapper.Map<ProductDTO>(product);

                return Ok(productDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error unexpected occurred.");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Create([FromBody] ProductDTO productDto)
        {
            try
            {
                var product = Mapper.Map<Product>(productDto);

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
        public ActionResult Update([FromBody] ProductDTO productDto)
        {
            try
            {
                var productFound = UnitOfWork.ProductRepository.GetById(x => x.ProductId == productDto.ProductId);

                if (productFound == null)
                {
                    return NoContent();
                }

                var product = Mapper.Map<Product>(productDto);

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