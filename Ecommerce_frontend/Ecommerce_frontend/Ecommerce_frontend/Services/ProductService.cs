using Ecommerce_frontend.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace Ecommerce_frontend.Services
{
    class ProductService
    {
        private readonly string BaseUrl = "http://192.168.0.8:8080/api/products"; // Replace with your API URL

        public async Task<List<Product>> GetProductsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(BaseUrl);
                return JsonConvert.DeserializeObject<List<Product>>(response);
            }
        }
    }
}
