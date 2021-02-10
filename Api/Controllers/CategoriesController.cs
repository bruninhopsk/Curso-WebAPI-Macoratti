using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Filters;
using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;
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
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                var categories = await UnitOfWork.CategoryRepository.GetCategoriesWithProducts();

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
        public async Task<ActionResult> GetAll([FromQuery] CategoriesParameters parameters)
        {
            try
            {
                var categories = await UnitOfWork.CategoryRepository.GetCategories(parameters);

                if (categories == null)
                {
                    return NoContent();
                }

                var metaData = new
                {
                    categories.CurrentPage,
                    categories.PageSize,
                    categories.TotalCount,
                    categories.TotalPages,
                    categories.HasNext,
                    categories.HasPrevious,
                };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

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
        public async Task<ActionResult> GetById([FromQuery] int categoryId)
        {
            try
            {
                var category = await UnitOfWork.CategoryRepository.GetById(x => x.CategoryId == categoryId);

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
        public async Task<ActionResult> Create([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                var category = Mapper.Map<Category>(categoryDTO);

                UnitOfWork.CategoryRepository.Add(category);
                await UnitOfWork.Commit();

                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Update([FromBody] CategoryDTO categoryDTO)
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
                await UnitOfWork.Commit();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<ActionResult> Delete([FromQuery] int categoryId)
        {
            try
            {
                var categoryFound = await UnitOfWork.CategoryRepository.GetById(x => x.CategoryId == categoryId);

                if (categoryFound == null)
                {
                    return NoContent();
                }

                UnitOfWork.CategoryRepository.Remove(categoryFound);
                await UnitOfWork.Commit();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}