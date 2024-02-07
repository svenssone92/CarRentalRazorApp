using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalRazor.Pages.UserManager
{
    public class SignInSuccessModel : PageModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public void OnGet()
        {
            FirstName = HttpContext.Session.GetString("CustomerFirstName");
            LastName = HttpContext.Session.GetString("CustomerLastName");
        }
    }
}
