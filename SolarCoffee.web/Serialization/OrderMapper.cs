using System;
using System.Linq;
using System.Collections.Generic;

namespace SolarCoffee.web.Serialization
{
    public static class OrderMapper
    {
        public static data.models.SalesOrder InvoiceViewToOrderData(web.ViewModels.InvoiceModel invoice)
        {
            List<data.models.SalesOrderItem> salesOrderItems = invoice.LineItems.Select(item => new data.models.SalesOrderItem {
                Id = item.Id,
                quantity = item.Quantity,
                Product = ProductMapper.ViewModelToDataModel(item.Product)
            }).ToList();

            return new data.models.SalesOrder{
                SalesOrderItems = salesOrderItems,
                createdOn = DateTime.UtcNow,
                updatedOn = DateTime.UtcNow
            };
        }

        public static  List<web.ViewModels.OrderModel> OrderDataToOrderView(IEnumerable<data.models.SalesOrder> ordesr)
        {
            return ordesr.Select(order => new web.ViewModels.OrderModel {
                Id = order.Id,
                createdOn = order.createdOn,
                updatedOn = order.updatedOn,
                SalesOrderItems = OrderItemDataToOrderItemView(order.SalesOrderItems),
                Customer = CustomerMapper.CustomerDataToCustomerView(order.Customer),
                isPaid = order.isPaid
            }).ToList();
        }

        private static List<web.ViewModels.SalesOrderItemModel> OrderItemDataToOrderItemView(IEnumerable<data.models.SalesOrderItem> orderItems)
        {
            return orderItems.Select(item => new web.ViewModels.SalesOrderItemModel {
                Id = item.Id,
                Quantity = item.quantity,
                Product = ProductMapper.DataModelToViewModel(item.Product)
            }).ToList();
        }
    }
}