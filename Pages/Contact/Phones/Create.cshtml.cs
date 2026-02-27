using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoForce.Data;
using TeknoForce.Data.Models;

namespace TeknoForce.Pages.Admin.Contact.Phones
{
    public class CreateModel : AdminBasePageModel
    {
        private readonly AppDbContext _context;
        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactPhone Phone { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int BranchId { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("BranchId = " + BranchId);

            Phone.ContactBranchId = BranchId;

            if (!ModelState.IsValid)
                return Page();

            _context.ContactPhones.Add(Phone);
            _context.SaveChanges();

            return RedirectToPage("Index", new { branchId = BranchId });
        }






    }
}
