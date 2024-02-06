using System.ComponentModel.DataAnnotations;
using CarRentalRazor.Data;

namespace CarRentalRazor.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
