using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolarCoffee.data.models;


namespace SolarCoffee.data
{
    public class SolarDbContext : IdentityDbContext
    {
        public SolarDbContext()
        {
            
        }
        public SolarDbContext(DbContextOptions option) : base(option)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
    }
}
