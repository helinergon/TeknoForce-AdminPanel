namespace TeknoForce.Data.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; } = null!;
        public string? LogoPath { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
