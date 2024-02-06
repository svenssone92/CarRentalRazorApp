using CarRentalRazor.Models;

namespace CarRentalRazor.Data
{
    public interface IReservation
    {
        Reservation GetById(int id);

        IEnumerable<Reservation> GetAll();
    }
}
