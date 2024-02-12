﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly ICar carRepository;

        public DeleteModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        [BindProperty]
      public Car Car { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (carRepository == null)
            {
                return NotFound();
            }

            var car = carRepository.GetById(id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (carRepository == null)
            {
                return NotFound();
            }
            var car = carRepository.GetById(id);

            if (car != null)
            {
                Car = car;
                carRepository.Delete(Car);
            }

            return RedirectToPage("./Index");
        }
    }
}
