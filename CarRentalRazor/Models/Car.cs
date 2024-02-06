using CarRentalRazor.Data;
using System.ComponentModel.DataAnnotations;

namespace CarRentalRazor.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string PictureString { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
