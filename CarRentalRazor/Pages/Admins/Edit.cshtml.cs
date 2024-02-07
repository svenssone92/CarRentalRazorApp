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

namespace CarRentalRazor.Pages.Admins
{
    public class EditModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public EditModel(IAdmin adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
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
            Admin = admin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            adminRepository.Update(Admin);

            return RedirectToPage("./Index");
        }
    }
}
