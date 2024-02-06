using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly CarRentalRazor.Data.ApplicationDbContext _context;

        public CreateModel(CarRentalRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id");
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Reservation.Car");
            ModelState.Remove("Reservation.Customer");
            if (!ModelState.IsValid || _context.Reservations == null || Reservation == null)
            {
                return Page();
            }

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
