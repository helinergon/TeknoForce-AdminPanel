using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeknoForce.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var adminId = HttpContext.Session.GetInt32("AdminUserId");

            if (adminId == null)
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }
    }
}
