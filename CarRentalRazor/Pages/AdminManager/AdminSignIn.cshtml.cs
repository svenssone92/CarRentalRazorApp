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
using CarRentalRazor.Pages.UserManager;

namespace CarRentalRazor.Pages.AdminManager
{
    public class AdminSignInModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public AdminSignInModel(IAdmin adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Admin admin)
        {
            var admins = adminRepository.GetAll();

            var matchingAdmin = admins.FirstOrDefault(a => a.Email == admin.Email);

            if (matchingAdmin != null && matchingAdmin.Password == admin.Password)
            {
                SessionControl.RemoveCustomerData(HttpContext.Session);
                SessionControl.SetAdminData(HttpContext.Session, matchingAdmin);

                return RedirectToPage("../Index");
            }


            return Page();
        } 
    }
}
