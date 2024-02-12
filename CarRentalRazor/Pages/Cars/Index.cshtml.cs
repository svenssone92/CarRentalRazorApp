using System;
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
    public class IndexModel : PageModel
    {
        private readonly ICar carRepository;

        public IndexModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        public IEnumerable<Car> Car { get;set; } = new List<Car>();

        public void OnGet()
        {
            if (carRepository != null)
            {
                Car = carRepository.GetAll();
            }
        }
    }
}
