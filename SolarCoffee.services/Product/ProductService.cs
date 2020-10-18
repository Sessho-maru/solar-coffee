using System;
using System.Collections.Generic;
using SolarCoffee.data;
using System.Linq;

namespace SolarCoffee.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly SolarDbContext _db;
        public ProductService(SolarDbContext dbContext)
        {
            _db = dbContext;
        }

        public List<data.models.Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }
        public data.models.Product GetproductById(int id)
        {
            return _db.Products.Find(id);
        }
        public ServiceResponse<bool> CreateProductAndReturnResponseAsBool(data.models.Product product)
        {
            try {
                _db.Products.Add(product);

                data.models.ProductInventory NewInventory = new data.models.ProductInventory {
                    Product = product,
                    quantityOnHand = 0,
                    idealQuantity = 10  
                };

                _db.ProductInventories.Add(NewInventory);
                _db.SaveChanges();

                return ServiceResponse<bool>.Successed(true, "Product created");
            } catch (Exception e){
                return ServiceResponse<bool>.Failed(false, e.StackTrace);
            }
        }
        public ServiceResponse<bool> ArchiveProductAndReturnResponseAsBool(int id)
        {
            try {
                data.models.Product product = _db.Products.Find(id);
                product.isArchived = true;
                _db.SaveChanges();

                return ServiceResponse<bool>.Successed(true, "Product Archived");
            } catch (Exception e){
                return ServiceResponse<bool>.Failed(false, e.StackTrace);
            }
        }

        public ServiceResponse<data.models.Product> CreateProductAndReturnResponseAsSelf(data.models.Product product)
        {
            try {
                _db.Products.Add(product);

                data.models.ProductInventory NewInventory = new data.models.ProductInventory {
                    Product = product,
                    quantityOnHand = 0,
                    idealQuantity = 10  
                };

                _db.ProductInventories.Add(NewInventory);
                _db.SaveChanges();

                return ServiceResponse<data.models.Product>.Successed(product, "Product created");
            } catch (Exception e){
                return ServiceResponse<data.models.Product>.Failed(product, e.StackTrace);
            }
        }
        public ServiceResponse<data.models.Product> ArchiveProductAndReturnResponseAsSelf(int id)
        {
            data.models.Product product = _db.Products.Find(id);
            try {
                product.isArchived = true;
                _db.SaveChanges();

                return ServiceResponse<data.models.Product>.Successed(product, "Product Archived");
            } catch (Exception e){
                return ServiceResponse<data.models.Product>.Failed(product, e.StackTrace);
            }
        }
    }
}