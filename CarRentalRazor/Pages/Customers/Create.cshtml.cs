using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Customers
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
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Exclude specific properties from validation
            ModelState.Remove("Customer.Reservations");

            if (!ModelState.IsValid || _context.Customers == null || Customer == null)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
