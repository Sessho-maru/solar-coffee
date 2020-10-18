using System;

namespace SolarCoffee.data.models
{
    public class Customer
    {
        public int id { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public CustomerAddress primaryAddress { get; set; }
    }
}