using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.UserManager
{
    public class CancelReservationModel : PageModel
    {
        private readonly ICar carRepository;
        private readonly IReservation reservationRepository;

        public CancelReservationModel(ICar carRepository, IReservation reservationRepository)
        {
            this.carRepository = carRepository;
            this.reservationRepository = reservationRepository;
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        [BindProperty]
        public Car Car { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (reservationRepository == null)
            {
                return NotFound();
            }

            var reservation = reservationRepository.GetById(id);
            var car = carRepository.GetById(reservation.CarId);

            if (reservation == null || car == null)
            {
                return NotFound();
            }
            else
            {
                Reservation = reservation;
                Car = car;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (reservationRepository == null)
            {
                return NotFound();
            }
            var reservation = reservationRepository.GetById(id);

            if (reservation != null)
            {
                Reservation = reservation;
                reservationRepository.Delete(Reservation);

            }

            return RedirectToPage("./ReservationList");
        }
    }
}
