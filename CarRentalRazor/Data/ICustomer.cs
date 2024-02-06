using CarRentalRazor.Models;

namespace CarRentalRazor.Data
{
    public interface ICustomer
    {

        Customer GetById(int id);

        IEnumerable<Customer> GetAll();
    }
}
