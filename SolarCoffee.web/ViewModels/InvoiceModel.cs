using System;
using System.Collections.Generic;

namespace SolarCoffee.web.ViewModels
{
    public class InvoiceModel
    {
        public int id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CustomerId { get; set; }
        public List<SalesOrderItemModel> Items { get; set; }
        public int GrandTotal { get; set; }
    }
    public class SalesOrderItemModel
    {
        public int id { get; set; }
        public int Quantity { get; set; }
        public ProductModel Product { get; set; }
        public int SubTotal { get; set; }
    }
}