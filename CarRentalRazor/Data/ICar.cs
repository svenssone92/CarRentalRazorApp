using CarRentalRazor.Models;

namespace CarRentalRazor.Data
{
    public interface ICar
    {
        Car GetById(int id);

        IEnumerable<Car> GetAll();
    }
}
