using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeknoForce.Data.Models
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [Required]
        public string ImagePath { get; set; } = null!;

        public bool IsCover { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
