using CarRentalRazor.Pages.UserManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalRazor.Pages.AdminManager
{
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostSignOut()
        {
            SessionControl.RemoveAdminData(HttpContext.Session);
            return RedirectToPage("/Index");
        }
    }
}
