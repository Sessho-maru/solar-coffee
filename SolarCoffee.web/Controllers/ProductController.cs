using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services;
using SolarCoffee.Services.Product;

namespace SolarCoffee.web.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
           _logger = logger;
           _productService = productService;
        }

        [HttpGet("/api/product")]
        public ActionResult GetProduct()
        {
            _logger.LogInformation("Getting all products");
            return Ok(_productService.GetAllProducts());
        }

        [HttpPatch("/api/product/{id}")]
        public ActionResult ArchiveProduct(int id)
        {
            _logger.LogInformation("Archiving a product");
            ServiceResponse<data.models.Product> result = _productService.ArchiveProductAndReturnResponseAsSelf(id);
            return Ok(result);
        }
    }
}