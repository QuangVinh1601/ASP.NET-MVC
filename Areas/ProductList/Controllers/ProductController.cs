using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using WebAppMVC_1.Services;

namespace WebAppMVC_1.Controllers
{
    [Area("ProductList")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public readonly ILogger<ProductController> _logger;
        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("/list-of-product.html/{id:int}")]
        public IActionResult Index()
        {
            //Areas/Tên Area/Views/Controller/Action.cshtml
            var product =   _productService.Products.OrderBy(p => p.Name).ToList();
            return View(product); //Areas/ProductList/Views/Controller/Action.cshtml
        }
    }
}
