//Orders klasöründeki index.cshtml.cs

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeknoForce.Data;
using TeknoForce.Data.Models;

namespace TeknoForce.Pages.Admin.Orders
{
    public class IndexModel : AdminBasePageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> Orders { get; set; } = new();

        public void OnGet()
        {
            Orders = _context.Orders
                .Include(o => o.OrderStatus)
                .OrderByDescending(o => o.CreatedDate)
                .ToList();
        }
    }
}
