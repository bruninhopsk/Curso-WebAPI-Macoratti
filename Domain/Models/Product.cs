using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string Description { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "This field is required!")]
        public decimal Price { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "This field is required!")]
        public double Stock { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public DateTime DateRegister { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}