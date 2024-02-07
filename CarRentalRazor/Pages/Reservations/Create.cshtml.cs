using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly ICar carRepository;
        private readonly ICustomer customerRepository;
        private readonly IReservation reservationRepository;

        public CreateModel(ICar carRepository, ICustomer customerRepository, IReservation reservationRepository)
        {
            this.carRepository = carRepository;
            this.customerRepository = customerRepository;
            this.reservationRepository = reservationRepository;
        }

        public IActionResult OnGet()
        {
            ViewData["CarId"] = new SelectList(carRepository.GetAll(), "Id", "Id");
            ViewData["CustomerId"] = new SelectList(customerRepository.GetAll(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Reservation.Car");
            ModelState.Remove("Reservation.Customer");
            if (!ModelState.IsValid || reservationRepository == null || Reservation == null)
            {
                return Page();
            }

            reservationRepository.Add(Reservation);


            return RedirectToPage("./Index");
        }
    }
}
