using System.Collections.Generic;
using WebAppMVC_1.Models;

namespace WebAppMVC_1.Services
{
    public class ProductService 
    {
        public List<ProductModel> Products { get; set; }
        public ProductService() {
            Products = new List<ProductModel>()
            {
                new ProductModel() { Id = 1, Name="Samsung" , Description="Điện thoại Samsung"},
                new ProductModel() { Id = 2, Name="Nokia", Description="Điện thoại Nokia"},
                new ProductModel() { Id = 3, Name="Iphone", Description="Điện thoại Iphone"}
            };
        }
    }
}
