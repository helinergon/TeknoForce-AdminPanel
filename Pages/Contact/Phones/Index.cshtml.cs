using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeknoForce.Data;
using TeknoForce.Data.Models;

namespace TeknoForce.Pages.Admin.Contact.Phones
{
    public class IndexModel : AdminBasePageModel
    {
       private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public int BranchId { get; set; }

        public ContactBranch Branch { get; set; } = new();
        public List<ContactPhone> Phones { get; set; } = new();
        public void OnGet(int branchId)
        {
            BranchId = branchId;

            Phones = _context.ContactPhones
                .Where(p => p.ContactBranchId == branchId)
                .ToList();
        }

        public IActionResult OnPostDelete(int id, int branchId)
        {
            var phone = _context.ContactPhones
                .FirstOrDefault(p => p.ContactPhoneId == id);
            if (phone != null)
            {
                _context.ContactPhones.Remove(phone);
                _context.SaveChanges();
            }
            return RedirectToPage("Index", new  { branchId });
        }
    }
}
