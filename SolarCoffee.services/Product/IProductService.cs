using System.Collections.Generic;

namespace SolarCoffee.Services.Product
{
    public interface IProductService
    {
        List<data.models.Product> GetAllProducts();
        data.models.Product GetproductById(int id);
        ServiceResponse<bool> CreateProductAndReturnResponseAsBool(data.models.Product product);
        ServiceResponse<bool> ArchiveProductAndReturnResponseAsBool(int id);
        ServiceResponse<data.models.Product> CreateProductAndReturnResponseAsSelf(data.models.Product product);
        ServiceResponse<data.models.Product> ArchiveProductAndReturnResponseAsSelf(int id);
    }
}