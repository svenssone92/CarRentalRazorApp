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
        private readonly ICustomer customerRepository;

        public IndexModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public int CarId { get; set; } = -1;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //saves the cars Id while customer signs in, if they wanted to make a reservation. 
            TempData["CarId"] = -1;
            if (id != null)
            {
                CarId = (int)id;
                TempData["CarId"] = CarId;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Customer customer)
        {
            var customers = customerRepository.GetAll();

            CarId = (int)TempData["CarId"];

            var matchingCustomer = customers.FirstOrDefault(a => a.Email == customer.Email);

            if (matchingCustomer != null && matchingCustomer.Password == customer.Password)
            {
                SessionControl.RemoveAdminData(HttpContext.Session);
                SessionControl.SetCustomerData(HttpContext.Session, matchingCustomer);

                if(CarId != -1)
                {
                    return RedirectToPage("./Reservations", new { id = CarId });
                }

                return RedirectToPage("./SignInSuccess");
            }


            return Page();
        }
    }
}
