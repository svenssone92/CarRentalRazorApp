using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalRazor.Data;
using CarRentalRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalRazor.Pages.UserManager
{
    public class ReservationsModel : PageModel
    {
        private readonly ICar carRepository;
        private readonly IReservation reservationRepository;

        public ReservationsModel(ICar carRepository, ICustomer customerRepository, IReservation reservationRepository)
        {
            this.carRepository = carRepository;
            this.reservationRepository = reservationRepository;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (carRepository.GetAll() == null)
            {
                return NotFound();
            }

            var car = carRepository.GetById(id);
            if (car == null)
            {
                return NotFound();
            }

            Car = car;
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            //Removes navigation properties for Vaildation
            ModelState.Remove("Reservation.Car");
            ModelState.Remove("Reservation.Customer");

            // Set CarId and CustomerId for Reservation
            Reservation.CarId = Car.Id;
            Reservation.CustomerId = (int)HttpContext.Session.GetInt32("CustomerId");

            if (!ModelState.IsValid || reservationRepository.GetAll() == null || Reservation == null || HttpContext.Session.GetInt32("CustomerId") == null)
            {
                return Page();
            }

            reservationRepository.Add(Reservation);
            return RedirectToPage("./ReservationConfirm", Reservation);
        }
    }
}
