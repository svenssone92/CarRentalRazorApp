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
    public class RentalCarsModel : PageModel
    {
        private readonly ICar carRepository;

        public RentalCarsModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        public IEnumerable<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (carRepository != null)
            {
                Car = carRepository.GetAll();
            }
        }
    }
}
