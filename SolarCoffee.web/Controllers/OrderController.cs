using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Order;
using SolarCoffee.Services.Customer;
using SolarCoffee.web.Serialization;
using SolarCoffee.web.ViewModels;
using System.Collections.Generic;

namespace SolarCoffee.web.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;


        public OrderController(ILogger<OrderController> logger, IOrderService orderService, ICustomerService customerSercvice)
        {
            _logger = logger;
            _orderService = orderService;
            _customerService = customerSercvice;
        }

        [HttpPost("/api/invoice")]
        public ActionResult GenerateNewOrder([FromBody] InvoiceModel invoice)
        {
            _logger.LogInformation("Generating invoice");
            data.models.SalesOrder order = OrderMapper.InvoiceViewToOrderData(invoice);
            order.Customer = _customerService.GetById(invoice.CustomerId);
            return Ok(_orderService.GenerateOpenOrderAndReturnResponse(order));
        }
        
        [HttpGet("/api/order")]
        public ActionResult GetAllOrders()
        {
            List<data.models.SalesOrder> orders = _orderService.GetOrders();
            List<web.ViewModels.OrderModel> orderModels = OrderMapper.OrderDataToOrderView(orders);
            return Ok(orderModels);
        }

        [HttpPatch("/api/order/complete/{id}")]
        public ActionResult MarkOrdersCompleted(int id)
        {
            _logger.LogInformation($"Marking order {id} completed");
            return Ok(_orderService.MarkFulfilledAndReturnResponse(id));
        }
    }
}