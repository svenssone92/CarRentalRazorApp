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

        public void Add(Reservation reservation)
        {
            applicationDbContext.Add(reservation);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Reservation reservation)
        {
            applicationDbContext.Remove(reservation);
            applicationDbContext.SaveChanges();
        }

        public IQueryable<Reservation> GetAll()
        {
            return applicationDbContext.Reservations.AsQueryable().OrderBy(x => x.Id);
        }

        public Reservation GetById(int id)
        {
            return applicationDbContext.Reservations.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Reservation reservation)
        {
            applicationDbContext.Update(reservation);
            applicationDbContext.SaveChanges();
        }
    }
}
