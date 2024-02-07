using CarRentalRazor.Models;

namespace CarRentalRazor.Data
{
    public class CarRepository : ICar
    {
        public ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(Car car)
        {
            applicationDbContext.Cars.Add(car);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            applicationDbContext.Cars.Remove(car);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(x => x.Id);
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Car car)
        {
            applicationDbContext.Update(car);
            applicationDbContext.SaveChanges();
        }
    }
}
