using System;
using System.Collections.Generic;

namespace SolarCoffee.data.models
{
    public class SalesOrder
    {
        public int id { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }

        public Customer Customer { get; set; }
        public List<SalesOrderItem> SalesOrderItems { get; set; }
        public bool isPaid { get; set; }
    }
}