using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Admins
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentalRazor.Data.ApplicationDbContext _context;

        public DetailsModel(CarRentalRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Admin Admin { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }
            else 
            {
                Admin = admin;
            }
            return Page();
        }
    }
}
