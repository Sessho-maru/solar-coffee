using System;

namespace SolarCoffee.data.models
{
    public class ProductInventorySnapshot
    {
        public int id { get; set; }
        public DateTime SnapshotTime { get; set; }
        public int quantityOnHand { get; set; }
        public Product Product { get; set; }
    }
}