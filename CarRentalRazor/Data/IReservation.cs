using CarRentalRazor.Models;

namespace CarRentalRazor.Data
{
    public interface IReservation
    {
        Reservation GetById(int id);

        IQueryable<Reservation> GetAll();

        void Add(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
    }
}
