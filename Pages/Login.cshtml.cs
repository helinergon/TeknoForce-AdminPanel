using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoForce.Data;
using TeknoForce.Data.Models;

namespace TeknoForce.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<AdminUser> _hasher;

        public LoginModel(AppDbContext context)
        {
            _context = context;
            _hasher = new PasswordHasher<AdminUser>();
        }

        [BindProperty]
        public string Username { get; set; } = null!;

        [BindProperty]
        public string Password { get; set; } = null!;

        public IActionResult OnPost()
        {
            var admin = _context.AdminUsers
                .FirstOrDefault(x => x.Username == Username);

            if (admin == null)
            {
                ViewData["Error"] = "Kullanýcý adý veya þifre hatalý";
                return Page();
            }

            if (admin.LockoutEnd != null && admin.LockoutEnd > DateTime.Now)
            {
                ViewData["Error"] = "Hesap 10 dakika kilitli.";
                return Page();
            }

            var result = _hasher.VerifyHashedPassword(admin, admin.Password, Password);

            if (result == PasswordVerificationResult.Failed)
            {
                admin.FailedLoginCount++;

                if (admin.FailedLoginCount >= 5)
                {
                    admin.LockoutEnd = DateTime.Now.AddMinutes(10);
                    admin.FailedLoginCount = 0;
                }

                _context.SaveChanges();

                ViewData["Error"] = "Kullanýcý adý veya þifre hatalý";
                return Page();
            }

            admin.FailedLoginCount = 0;
            admin.LockoutEnd = null;
            _context.SaveChanges();

            HttpContext.Session.SetInt32("AdminUserId", admin.Id);

            return RedirectToPage("/Dashboard/Index");
        }
    }
}
