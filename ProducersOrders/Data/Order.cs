using System.ComponentModel.DataAnnotations;

namespace ProducersOrders.Data
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
