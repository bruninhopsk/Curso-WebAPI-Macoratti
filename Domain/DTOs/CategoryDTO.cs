using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string ImageUrl { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}