using System;

namespace Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Stock { get; set; }
        public DateTime DateRegister { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}