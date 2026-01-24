using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoForce.Data;
using TeknoForce.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TeknoForce.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public List<Brand> Brands { get; set; } = new();
        public void OnGet()
        { 
        Brands= _context.Brands
                        .OrderBy(x => x.BrandId)
                        .ToList();
        }
    }
}
