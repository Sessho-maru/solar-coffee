using System.Collections.Generic;

namespace SolarCoffee.Services.Customer
{
    public interface ICustomerService
    {
        List<data.models.Customer> GetAllCustomers();
        ServiceResponse<data.models.Customer> CreateCustomerAndReturnResponse(data.models.Customer customer);
        ServiceResponse<bool> DeleteCustomerAndReturnResponse(int id);
        data.models.Customer GetById(int id);
    }
}