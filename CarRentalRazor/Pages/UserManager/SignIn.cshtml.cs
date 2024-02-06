using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.UserManager
{
    public class IndexModel : PageModel
    {
        private readonly CarRentalRazor.Data.ApplicationDbContext _context;

        public IndexModel(CarRentalRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Customer customer)
        {
            var customers = _context.Customers;

            var matchingCustomer = customers.FirstOrDefault(a => a.Email == customer.Email);

            if (matchingCustomer != null && matchingCustomer.Password == customer.Password)
            {
                ActiveUser.customer = matchingCustomer;

                return RedirectToPage("../Index");
            }


            return Page();
        }
    }
}
