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
        private readonly IAdmin adminRepository;

        public DetailsModel(IAdmin adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public Admin Admin { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (adminRepository == null)
            {
                return NotFound();
            }

            var admin = adminRepository.GetById(id);
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
