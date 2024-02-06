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
        private readonly CarRentalRazor.Data.ApplicationDbContext _context;

        public ReservationListModel(CarRentalRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reservations != null)
            {
                Reservation = await _context.Reservations
                .Where(r => r.CustomerId == ActiveUser.customer.Id)
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .OrderBy(r => r.StartDate)
                .ToListAsync();
            }
        }
    }
}
