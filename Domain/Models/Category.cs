using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}