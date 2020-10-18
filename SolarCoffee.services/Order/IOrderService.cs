using System.Collections.Generic;

namespace SolarCoffee.Services.Order
{
    public interface IOrderService
    {
        List<data.models.SalesOrder> GetOrders();
        ServiceResponse<bool> GenerateOpenOrderAndReturnResponse(data.models.SalesOrder order);
        ServiceResponse<bool> MarkFulfilledAndReturnResponse(int id);
    }
}