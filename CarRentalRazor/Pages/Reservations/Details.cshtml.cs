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
    public class DetailsModel : PageModel
    {
        private readonly IReservation reservationRepository;

        public DetailsModel(IReservation reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public Reservation Reservation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (reservationRepository == null)
            {
                return NotFound();
            }
            var reservation = reservationRepository.GetById(id);

            if (reservation == null)
            {
                return NotFound();
            }
            else 
            {
                Reservation = reservation;
            }
            return Page();
        }
    }
}
