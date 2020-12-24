using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Product;
using SolarCoffee.web.ViewModels;
using SolarCoffee.web.Serialization;

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

        [HttpPost("/api/product")]
        public ActionResult AddProduct([FromBody] ProductModel product)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Adding product");
            var newProduct = ProductMapper.ViewModelToDataModel(product);
            return Ok(_productService.CreateProductAndReturnResponseAsBool(newProduct));
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
            return Ok(_productService.ArchiveProductAndReturnResponseAsSelf(id));
        }
    }
}