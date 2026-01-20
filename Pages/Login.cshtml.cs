
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeknoForce.Data;

namespace TeknoForce.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var admin = _context.AdminUsers
                .FirstOrDefault(x => x.Username == Username && x.Password == Password);

            if (admin == null)
            {
                ViewData["Error"] = "Kullanýcý adý veya þifre hatalý";
                return Page();
            }

            HttpContext.Session.SetString("AdminLogin", "true");
            return RedirectToPage("/Index");
        }
    }

}
