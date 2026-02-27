using System.ComponentModel.DataAnnotations;
using TeknoForce.Pages;

namespace TeknoForce.Data.Models
{
    public class AdminUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public int FailedLoginCount { get; set; }

        public DateTime? LockoutEnd { get; set; }
    }
}
