using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.UserManager
{
    public class ReservationListModel : PageModel
    {
        private readonly IReservation reservationRepository;

        public ReservationListModel(IReservation reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public IList<Reservation> Reservation { get;set; } = default!;

        public void OnGet()
        {
            if (reservationRepository != null)
            {
                Reservation = reservationRepository.GetAll()
                .Where(r => r.CustomerId == HttpContext.Session.GetInt32("CustomerId"))
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .OrderBy(r => r.StartDate)
                .ToList();
            }
        }
    }
}
