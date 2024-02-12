using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly IReservation reservationRepository;

        public IndexModel(IReservation reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public IEnumerable<Reservation> Reservation { get;set; } = default!;

        public void OnGet()
        {
            if (reservationRepository != null)
            {
                Reservation = reservationRepository
                    .GetAll()
                    .Include(r => r.Car)
                    .Include(r => r.Customer)
                    .ToList();
            }
        }
    }
}
