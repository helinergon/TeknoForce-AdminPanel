using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeknoForce.Data.Models;
using TeknoForce.Data;
using System.Linq;

namespace TeknoForce.Pages.Dashboard
{
    public class IndexModel : AdminBasePageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public int ProductCount { get; set; }
        public int OrderCount { get; set; }
        public int PendingCommentCount { get; set; }

        public decimal TotalRevenue { get; set; }

        public List<Order> LastOrders { get; set; } = new();

        public List<string> OrderStatusLabels { get; set; } = new();
        public List<int> OrderStatusCounts { get; set; } = new();
        public List<string> OrderStatusColors { get; set; } = new();

        public void OnGet()
        {
            ProductCount = _context.Products.Count();
            OrderCount = _context.Orders.Count();
            PendingCommentCount = _context.Comments.Count(c => !c.IsApproved);
            TotalRevenue = _context.Orders.Sum(o => (decimal?)o.TotalAmount) ?? 0;

            LastOrders = _context.Orders
                .Include(o => o.OrderStatus)
                .OrderByDescending(o => o.CreatedDate)
                .Take(5)
                .ToList();

            var distribution = _context.Orders
                .Include(o => o.OrderStatus)
                .GroupBy(o => o.OrderStatus)
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Count = g.Count(),
                    Color = g.Key.ColorCode
                })
                .ToList();

            OrderStatusLabels = distribution.Select(x => x.Name).ToList();
            OrderStatusCounts = distribution.Select(x => x.Count).ToList();
            OrderStatusColors = distribution.Select(x => x.Color).ToList();
        }


    }
}
