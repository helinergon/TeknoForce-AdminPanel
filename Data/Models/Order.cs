//order.cs

using System.ComponentModel.DataAnnotations.Schema;

namespace TeknoForce.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = null!;

        public int UserId { get; set; }

        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; } = null!;

        // KDV DAHİL TOPLAM
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
