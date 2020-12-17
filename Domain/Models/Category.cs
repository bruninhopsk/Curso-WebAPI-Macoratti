using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}