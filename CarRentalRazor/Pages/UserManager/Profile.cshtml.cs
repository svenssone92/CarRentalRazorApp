using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalRazor.Pages.UserManager
{
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostSignOut()
        {
            SessionControl.RemoveCustomerData(HttpContext.Session);
            return RedirectToPage("/Index");
        }
    }
}
