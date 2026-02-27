using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoForce.Data;
using TeknoForce.Data.Models;

namespace TeknoForce.Pages.Contact.Phones
{
    public class EditModel : AdminBasePageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactPhone Phone { get; set; } = new();
        public IActionResult OnGet(int id)
        {
            Phone = _context.ContactPhones
                .FirstOrDefault(p => p.ContactPhoneId == id);

            if (Phone == null)
                return NotFound();

            return Page();
        }
                
         public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.ContactPhones.Update(Phone);
            _context.SaveChanges();

            return RedirectToPage("Index", new { branchId = Phone.ContactBranchId });
        }
    }
}
