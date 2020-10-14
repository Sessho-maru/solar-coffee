namespace SolarCoffee.data.models
{
    public class SalesOrderItem
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public Product Product { get; set; }
    }
}