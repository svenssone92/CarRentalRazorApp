using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.UserManager
{
    public class ActiveUser
    {
        public static Customer? customer = null;

        public static void SignOutUser()
        {
            customer = null;
        }
    }
}
