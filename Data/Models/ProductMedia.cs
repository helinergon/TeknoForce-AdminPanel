using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeknoForce.Data.Models
{
    public class ProductMedia
    {
        [Key]
        public int ProductMediaId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [Required]
        public string FilePath { get; set; } = null!;

        [Required]
        public string MediaType { get; set; } = null!;
        // "Image" veya "Video"

        public bool IsCover { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
