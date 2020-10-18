using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SolarCoffee.data;
using System.Linq;

namespace SolarCoffee.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly SolarDbContext _db;

        public CustomerService(SolarDbContext dbContext)
        {
            _db = dbContext;
        }
        public List<data.models.Customer> GetAllCustomers()
        {
            return _db.Customers
                .Include(customer => customer.primaryAddress)
                .OrderBy(customer => customer.lastName)
                .ToList();
        }
        public ServiceResponse<data.models.Customer> CreateCustomerAndReturnResponse(data.models.Customer customer)
        {
            try {
                _db.Customers.Add(customer);
                _db.SaveChanges();

                return ServiceResponse<data.models.Customer>.Successed(customer, "Customer created");
            } catch (Exception e) {
                return ServiceResponse<data.models.Customer>.Failed(customer, e.Message);
            }
            
        }
        public ServiceResponse<bool> DeleteCustomerAndReturnResponse(int id)
        {
            data.models.Customer targetCustomer = _db.Customers.Find(id);

            if (targetCustomer == null)
            {
                return ServiceResponse<bool>.Failed(false, "Customer to delete not found");
            }

            try {
                _db.Customers.Remove(targetCustomer);
                _db.SaveChanges();

                return ServiceResponse<bool>.Successed(true, "Customer deleted");
            } catch (Exception e) {
                return ServiceResponse<bool>.Failed(false, e.StackTrace);
            }
        }
        public data.models.Customer GetById(int id)
        {
            return _db.Customers.Find(id);
        }
    }
}