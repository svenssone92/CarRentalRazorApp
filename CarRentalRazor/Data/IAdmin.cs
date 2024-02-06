using CarRentalRazor.Models;

namespace CarRentalRazor.Data
{
    public interface IAdmin
    {
        Admin GetById(int id);

        IEnumerable<Admin> GetAll();
    }
}
