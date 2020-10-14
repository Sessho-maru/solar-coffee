using System.Collections.Generic;

namespace SolarCoffee.Services.Product
{
    public interface IProductService
    {
        List<data.models.Product> GetAllProducts();
        data.models.Product GetproductById(int id);
        ServiceResponse<bool> CreateProductAndReturnBool(data.models.Product product);
        ServiceResponse<bool> ArchiveProductAndReturnBool(int id);
        ServiceResponse<data.models.Product> CreateProductAndReturnSelf(data.models.Product product);
        ServiceResponse<data.models.Product> ArchiveProductAndReturnSelf(int id);
    }
}