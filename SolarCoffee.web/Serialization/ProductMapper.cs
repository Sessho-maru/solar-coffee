using SolarCoffee.web.ViewModels;

namespace SolarCoffee.web.Serialization
{
    public static class ProductMapper
    {
        public static data.models.Product ViewModelToDataModel(web.ViewModels.ProductModel product)
        {
            return new data.models.Product{
                id = product.id,
                createdOn = product.createdOn,
                updatedOn = product.updatedOn,
                name = product.name,
                description = product.description,
                price = product.price,
                isTaxable = product.isTaxable,
                isArchived = product.isArchived,
            };
        }

        public static web.ViewModels.ProductModel DataModelToViewModel(data.models.Product product)
        {
            return new web.ViewModels.ProductModel{
                id = product.id,
                createdOn = product.createdOn,
                updatedOn = product.updatedOn,
                name = product.name,
                description = product.description,
                price = product.price,
                isTaxable = product.isTaxable,
                isArchived = product.isArchived,
            };
        }
    }
}
