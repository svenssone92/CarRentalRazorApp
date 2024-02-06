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
    public class CancelReservationModel : PageModel
    {
        private readonly CarRentalRazor.Data.ApplicationDbContext _context;

        public CancelReservationModel(CarRentalRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FirstOrDefaultAsync(m => m.Id == id);
            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == reservation.CarId);

            if (reservation == null || car == null)
            {
                return NotFound();
            }
            else 
            {
                Reservation = reservation;
                Car = car;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation != null)
            {
                Reservation = reservation;
                _context.Reservations.Remove(Reservation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ReservationList");
        }
    }
}
