using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.UserManager
{
    public class CreateModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public CreateModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            // Exclude specific properties from validation
            ModelState.Remove("Customer.Reservations");

            if (!ModelState.IsValid || customerRepository == null || Customer == null)
            {
                return Page();
            }

            customerRepository.Add(Customer);

            return RedirectToPage("./SignIn");
        }
    }
}
