using CarRentalRazor.Models;

namespace CarRentalRazor.Data
{
    public class ReservationRepository : IReservation
    {
        public ApplicationDbContext applicationDbContext;
        public ReservationRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return applicationDbContext.Reservations.OrderBy(x => x.Id);
        }

        public Reservation GetById(int id)
        {
            return applicationDbContext.Reservations.FirstOrDefault(x => x.Id == id);
        }
    }
}
