using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalRazor.Data;
using CarRentalRazor.Models;

namespace CarRentalRazor.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly CarRentalRazor.Data.ApplicationDbContext _context;

        public IndexModel(CarRentalRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Admin> Admin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Admins != null)
            {
                Admin = await _context.Admins.ToListAsync();
            }
        }
    }
}
