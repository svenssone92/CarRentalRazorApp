using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ICar carRepository;

        public CreateModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Exclude specific properties from validation
            ModelState.Remove("Car.Reservations");
            if (!ModelState.IsValid || carRepository == null || Car == null)
            {
                return Page();
            }

            carRepository.Add(Car);


            return RedirectToPage("./Index");
        }
    }
}
