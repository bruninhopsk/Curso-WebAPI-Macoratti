using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string Description { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "This field is required!")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}