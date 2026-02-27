using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeknoForce.Pages
{
    public class AdminBasePageModel : PageModel
    {
        public override void OnPageHandlerExecuting(
            Microsoft.AspNetCore.Mvc.Filters.PageHandlerExecutingContext context)
        {
            var adminId = context.HttpContext.Session.GetInt32("AdminUserId");

            if (adminId == null)
            {
                context.Result = new RedirectToPageResult("/Login");
            }

            base.OnPageHandlerExecuting(context);
        }
    }
}
