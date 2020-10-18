using System;

namespace SolarCoffee.web.ViewModels
{
    public class ProductInventoryModel
    {
        public int id { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }

        public int quantityOnHand { get; set; }
        public int idealQuantity { get; set; }

        public ProductModel Product { get; set; }       
    }
}