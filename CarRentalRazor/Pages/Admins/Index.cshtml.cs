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
    public class IndexModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public IndexModel(IAdmin adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public IEnumerable<Admin> Admin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (adminRepository != null)
            {
                Admin = adminRepository.GetAll();
            }
        }
    }
}
