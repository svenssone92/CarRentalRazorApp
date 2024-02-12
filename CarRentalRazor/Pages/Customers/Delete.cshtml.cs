using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public DeleteModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [BindProperty]
      public Customer Customer { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (customerRepository == null)
            {
                return NotFound();
            }

            var customer = customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (customerRepository == null)
            {
                return NotFound();
            }
            var customer = customerRepository.GetById(id);

            if (customer != null)
            {
                Customer = customer;
                customerRepository.Delete(Customer);

            }

            return RedirectToPage("./Index");
        }
    }
}
