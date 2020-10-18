using System;

namespace SolarCoffee.web.ViewModels
{
    public class ProductModel
    {
        public int id { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
        public string name { get; set;}
        public string description { get; set; }
        public decimal price { get; set; }
        public bool isTaxable { get; set; }
        public bool isArchived { get; set; }
    }
}