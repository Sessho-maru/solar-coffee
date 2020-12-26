using System;
using Microsoft.EntityFrameworkCore;
using SolarCoffee.data;
using System.Collections.Generic;
using System.Linq;

namespace SolarCoffee.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly SolarDbContext _db;
        private readonly Services.Product.IProductService _productService;
        private readonly Services.Inventory.IInventoryService _inventoryService;

        public OrderService(SolarDbContext db, Services.Product.IProductService productService, Services.Inventory.IInventoryService inventoryService)
        {
            _db = db;
            _productService = productService;
            _inventoryService = inventoryService;
        }
        public List<data.models.SalesOrder> GetOrders()
        {
            return _db.SalesOrders
                .Include(order => order.Customer).ThenInclude(customer => customer.primaryAddress)
                // .Include(order => order.SalesOrderItems).ThenInclude(item => item.Product)
                .ToList();
        }
        public ServiceResponse<bool> GenerateOpenOrderAndReturnResponse(data.models.SalesOrder orders)
        {
            foreach(data.models.SalesOrderItem order in orders.SalesOrderItems)
            {
                data.models.Product product = _productService.GetproductById(order.productId);

                if(product == null)
                {
                    return ServiceResponse<bool>.Failed(false, $"Product represented as index {order.productId} was not found");
                }

                data.models.ProductInventory inventory = _inventoryService.GetByProductId(product.id);
                int inventoryId = inventory.id;

                if(_inventoryService.UpdateUnitsAvailableAndReturnResponse(inventoryId, -(order.quantity)).IsSuccess == false)
                {
                    return ServiceResponse<bool>.Failed(false, "Updating inventory was fail");
                }
            }

            try {
                _db.SalesOrders.Add(orders);
                _db.SaveChanges();

                return ServiceResponse<bool>.Successed(true, "Open order created");
            } catch (Exception e) {
                return ServiceResponse<bool>.Failed(false, e.StackTrace);
            }
        }
        public ServiceResponse<bool> MarkFulfilledAndReturnResponse(int id)
        {
            data.models.SalesOrder targetOrder = _db.SalesOrders.Find(id);

            if(targetOrder == null)
            {
                return ServiceResponse<bool>.Failed(false, "Order to mark as paid not found");
            }

            targetOrder.updatedOn = DateTime.UtcNow;
            targetOrder.isPaid = true;

            try {
                _db.SalesOrders.Update(targetOrder);
                _db.SaveChanges();

                return ServiceResponse<bool>.Successed(true, $"Order {id} closed!: Invoice paid in full");
            } catch (Exception e) {
                return ServiceResponse<bool>.Failed(true, e.StackTrace);
            }
        }
    }
}
