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
    public class DeleteModel : PageModel
    {
        private readonly IReservation reservationRepository;

        public DeleteModel(IReservation reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        [BindProperty]
      public Reservation Reservation { get; set; } = default!;

        public IActionResult OnGet(int id)
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

        public IActionResult OnPost(int id)
        {
            if (reservationRepository == null)
            {
                return NotFound();
            }
            var reservation = reservationRepository.GetById(id);

            if (reservation != null)
            {
                Reservation = reservation;
                reservationRepository.Delete(Reservation);
            }

            return RedirectToPage("./Index");
        }
    }
}
