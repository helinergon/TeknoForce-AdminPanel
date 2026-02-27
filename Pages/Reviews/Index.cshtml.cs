using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeknoForce.Data;
using TeknoForce.Data.Models;

namespace TeknoForce.Pages.Reviews
{
    public class IndexModel : AdminBasePageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Comment> Comments { get; set; }

        public void OnGet()
        {
            Comments = _context.Comments
                .Include(c => c.Product)
                .OrderByDescending(c => c.CreatedDate)
                .ToList();
        }
        public IActionResult OnPostApprove(int id)
        {
            var comment = _context.Comments
                .FirstOrDefault(c => c.CommentId == id);

            if (comment != null)
            {
                comment.IsApproved = true;
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var comment = _context.Comments
                .FirstOrDefault(c => c.CommentId == id);

            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

    }
}
