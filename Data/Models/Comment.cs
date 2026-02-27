using System;
using System.ComponentModel.DataAnnotations;

namespace TeknoForce.Data.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        public bool IsApproved { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
