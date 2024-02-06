using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalRazor.Data;
using CarRentalRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalRazor.Pages.UserManager
{
    public class ReservationsModel : PageModel
    {
        private readonly CarRentalRazor.Data.ApplicationDbContext _context;

        public ReservationsModel(CarRentalRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            Car = car;
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //Removes unwanted properties for Vaildation
            ModelState.Remove("Reservation.Car");
            ModelState.Remove("Reservation.Customer");

            ModelState.Remove("Car.Model");
            ModelState.Remove("Car.Reservations");
            ModelState.Remove("Car.PictureString");

            if (!ModelState.IsValid || _context.Reservations == null || Reservation == null || ActiveUser.customer == null)
            {
                return Page();
            }

            // Set CarId and CustomerId for Reservation
            Reservation.CarId = Car.Id;
            Reservation.CustomerId = ActiveUser.customer.Id;

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Profile");
        }
    }
}
