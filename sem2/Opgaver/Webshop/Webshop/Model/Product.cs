using System;

namespace Webshop
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Filepath { get; set; }
        public int Quantity { get; set; }
    }
}