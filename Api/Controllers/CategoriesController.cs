using System;
using System.Collections.Generic;
using Api.Filters;
using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Repositories;
using Infrastructure.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
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
        public ActionResult GetProducts()
        {
            try
            {
                var categories = UnitOfWork.CategoryRepository.GetProducts();

                if (categories.Count == 0)
                {
                    return NoContent();
                }

                var categoriesDto = Mapper.Map<List<CategoryDTO>>(categories);

                return Ok(categoriesDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            try
            {
                var categories = UnitOfWork.CategoryRepository.GetAll();

                if (categories == null)
                {
                    return NoContent();
                }

                var categoriesDto = Mapper.Map<List<CategoryDTO>>(categories);

                return Ok(categoriesDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetById([FromQuery] int categoryId)
        {
            try
            {
                var category = UnitOfWork.CategoryRepository.GetById(x => x.CategoryId == categoryId);

                if (category == null)
                {
                    return NoContent();
                }

                var categoryDTO = Mapper.Map<CategoryDTO>(category);

                return Ok(categoryDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Create([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                var category = Mapper.Map<Category>(categoryDTO);

                UnitOfWork.CategoryRepository.Add(category);
                UnitOfWork.Commit();

                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult Update([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                var category = Mapper.Map<Category>(categoryDTO);

                var categoryFound = UnitOfWork.CategoryRepository.GetById(x => x.CategoryId == category.CategoryId);

                if (categoryFound is null)
                {
                    return NoContent();
                }

                UnitOfWork.CategoryRepository.Update(category);
                UnitOfWork.Commit();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult Delete([FromQuery] int categoryId)
        {
            try
            {
                var categoryFound = UnitOfWork.CategoryRepository.GetById(x => x.CategoryId == categoryId);

                if (categoryFound == null)
                {
                    return NoContent();
                }

                UnitOfWork.CategoryRepository.Remove(categoryFound);
                UnitOfWork.Commit();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}