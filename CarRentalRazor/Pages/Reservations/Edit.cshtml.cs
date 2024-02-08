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

namespace CarRentalRazor.Pages.Reservations
{
    public class EditModel : PageModel
    {
        private readonly ICar carRepository;
        private readonly ICustomer customerRepository;
        private readonly IReservation reservationRepository;

        public EditModel(ICar carRepository, ICustomer customerRepository, IReservation reservationRepository)
        {
            this.carRepository = carRepository;
            this.customerRepository = customerRepository;
            this.reservationRepository = reservationRepository;
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (reservationRepository == null)
            {
                return NotFound();
            }

            var reservation = reservationRepository.GetById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            Reservation = reservation;
           ViewData["CarId"] = new SelectList(carRepository.GetAll(), "Id", "Id");
           ViewData["CustomerId"] = new SelectList(customerRepository.GetAll(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Removes navigation props from validation
            ModelState.Remove("Reservation.Car");
            ModelState.Remove("Reservation.Customer");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            reservationRepository.Update(Reservation);


            return RedirectToPage("./Index");
        }
    }
}
