//OrderItem.cs

using System.ComponentModel.DataAnnotations.Schema;

namespace TeknoForce.Data.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        // KDV DAHİL FİYAT
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        // HESAPLANAN (DB'de tutulmaz)
        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;

    }
}
