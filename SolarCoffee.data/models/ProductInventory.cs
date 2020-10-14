using System;

namespace SolarCoffee.data.models
{
    public class ProductInventory
    {
        public int id { get; set; }
        public DateTime creataedOn { get; set; }
        public DateTime updatedOn { get; set; }

        public int quantityOnHand { get; set; }
        public int idealQuantity { get; set; }

        public Product Product { get; set; }
    }
}