using CarRentalRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalRazor.Pages.UserManager
{
    public class ReservationConfirmModel : PageModel
    {
        public Reservation Reservation { get; set; }
        public void OnGet(Reservation reservation)
        {
            Reservation = reservation;
        }
    }
}
