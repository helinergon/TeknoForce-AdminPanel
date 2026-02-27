using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoForce.Data;
using TeknoForce.Data.Models;

namespace TeknoForce.Pages.Contact.Branches
{
    public class EditModel : AdminBasePageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactBranch Branch { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Branch = _context.ContactBranches
                .FirstOrDefault(b => b.ContactBranchId == id);

            if (Branch == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.ContactBranches.Update(Branch);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}