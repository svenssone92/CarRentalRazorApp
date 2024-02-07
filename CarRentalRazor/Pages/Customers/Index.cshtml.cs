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
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public IndexModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (customerRepository != null)
            {
                Customer = customerRepository.GetAll();
            }
        }
    }
}
