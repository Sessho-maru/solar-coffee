using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SolarCoffee.data;
using SolarCoffee.data.models;
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
        public ServiceResponse<bool> CreateProductAndReturnBool(data.models.Product product)
        {
            try {
                _db.Products.Add(product);

                ProductInventory NewInventory = new ProductInventory {
                Product = product,
                quantityOnHand = 0,
                idealQuantity = 10  
                };

                _db.ProductInventories.Add(NewInventory);
                _db.SaveChanges();

                return new ServiceResponse<bool> {
                    Data = true,
                    Time = DateTime.UtcNow,
                    Message = "Saved new product",
                    IsSuccess = true
                };
            } catch (Exception e){
                return new ServiceResponse<bool> {
                    Data = false,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
        public ServiceResponse<bool> ArchiveProductAndReturnBool(int id)
        {
            try {
                data.models.Product product = _db.Products.Find(id);
                product.isArchived = true;
                _db.SaveChanges();

                return new ServiceResponse<bool> {
                    Data = true,
                    Time = DateTime.UtcNow,
                    Message = "Product arichived",
                    IsSuccess = true
                };
            } catch (Exception e){
                return new ServiceResponse<bool> {
                    Data = false,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        public ServiceResponse<data.models.Product> CreateProductAndReturnSelf(data.models.Product product)
        {
            try {
                _db.Products.Add(product);

                ProductInventory NewInventory = new ProductInventory {
                Product = product,
                quantityOnHand = 0,
                idealQuantity = 10  
                };

                _db.ProductInventories.Add(NewInventory);
                _db.SaveChanges();

                return new ServiceResponse<data.models.Product> {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Saved new product",
                    IsSuccess = true
                };
            } catch (Exception e){
                return new ServiceResponse<data.models.Product> {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
        public ServiceResponse<data.models.Product> ArchiveProductAndReturnSelf(int id)
        {
            data.models.Product product = _db.Products.Find(id);
            try {
                product.isArchived = true;
                _db.SaveChanges();

                return new ServiceResponse<data.models.Product> {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Product arichived",
                    IsSuccess = true
                };
            } catch (Exception e){
                return new ServiceResponse<data.models.Product> {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
    }
}