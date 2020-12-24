using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Customer;
using SolarCoffee.web.ViewModels;
using SolarCoffee.web.Serialization;
using System.Linq;

namespace SolarCoffee.web.Controllers 
{
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customer)
        {
            _logger = logger;
            _customerService = customer;
        }

        [HttpPost("/api/customer")]
        public ActionResult CreateCustomer([FromBody] CustomerModel customer)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            
            _logger.LogInformation("Creating a new customer");
            customer.createdOn = DateTime.UtcNow;
            customer.updatedOn = DateTime.UtcNow;
            data.models.Customer customerData = CustomerMapper.CustomerViewToCustomerData(customer);
            return Ok(_customerService.CreateCustomerAndReturnResponse(customerData));
        }

        [HttpGet("/api/customer")]
        public ActionResult GetAllCustomers()
        {
            _logger.LogInformation("Getting customemrs");
            List<data.models.Customer> customers = _customerService.GetAllCustomers();
            List<CustomerModel> customerModels = customers.Select(customer => new CustomerModel {
                id = customer.id,
                firstName = customer.firstName,
                lastName = customer.lastName,
                primaryAddress = CustomerMapper.AddressDataToAddressView(customer.primaryAddress),
                createdOn = customer.createdOn,
                updatedOn = customer.updatedOn
            }).OrderByDescending(customer => customer.createdOn).ToList();

            return Ok(customerModels);
        }

        [HttpDelete("/api/customer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation("Deleting a custoemr");
            return Ok(_customerService.DeleteCustomerAndReturnResponse(id));
        }
    }
}