using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.AdminManager
{
    public class ActiveAdmin
    {
        public static Admin? admin = null;

        public static void SignOutAdmin()
        {
            admin = null;
        }
    }
}
