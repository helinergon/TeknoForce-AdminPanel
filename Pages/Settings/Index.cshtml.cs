using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoForce.Data;
using TeknoForce.Data.Models;

namespace TeknoForce.Pages.Admin.Settings
{
    public class IndexModel : AdminBasePageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Setting Setting { get; set; } = new();

        public void OnGet()
        {
            Setting = _context.Settings.FirstOrDefault() ?? new Setting();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var existing = _context.Settings.FirstOrDefault();

            if (existing == null)
            {
                _context.Settings.Add(Setting);
            }
            else
            {
                existing.SiteTitle = Setting.SiteTitle;
                existing.LogoPath = Setting.LogoPath;
                existing.Phone = Setting.Phone;
                existing.Email = Setting.Email;
                existing.Address = Setting.Address;
                existing.FooterText = Setting.FooterText;
                existing.InstagramUrl = Setting.InstagramUrl;
                existing.FacebookUrl = Setting.FacebookUrl;
                existing.WhatsappNumber = Setting.WhatsappNumber;
                existing.SeoTitle = Setting.SeoTitle;
                existing.SeoDescription = Setting.SeoDescription;
                existing.UpdatedDate = DateTime.Now;
            }

            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
