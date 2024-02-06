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

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(x => x.Id);
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(x => x.Id == id);
        }
    }
}
