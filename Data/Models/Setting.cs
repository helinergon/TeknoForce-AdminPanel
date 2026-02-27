using System.ComponentModel.DataAnnotations;

namespace TeknoForce.Data.Models
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        [Required]
        public string SiteTitle { get; set; } = null!;

        public string? LogoPath { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public string? FooterText { get; set; }

        public string? InstagramUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? WhatsappNumber { get; set; }

        public string? SeoTitle { get; set; }
        public string? SeoDescription { get; set; }

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
