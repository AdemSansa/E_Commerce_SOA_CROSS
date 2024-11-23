using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_frontend.Model
{
   public  class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Product> Cart { get; set; } = new List<Product>();

        public String image { get; set; }
    }
}
