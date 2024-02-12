using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Admins
{
    public class CreateModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public CreateModel(IAdmin adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || adminRepository == null || Admin == null)
            {
                return Page();
            }

            adminRepository.Add(Admin);

            return RedirectToPage("./Index");
        }
    }
}
