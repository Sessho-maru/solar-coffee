namespace SolarCoffee.data.models
{
    public class SalesOrderItem
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int productId { get; set; }
        public int subTotal { get; set; }
    }
}