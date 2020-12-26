using System;
using System.Collections.Generic;

namespace SolarCoffee.web.ViewModels
{
    public class OrderModel
    {
        public int id { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }

        public CustomerModel Customer { get; set; }
        public List<web.ViewModels.SalesOrderItemModel> SalesOrderItems { get; set; }
        public bool isPaid { get; set; }
    }
}