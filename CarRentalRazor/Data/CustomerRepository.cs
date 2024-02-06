using CarRentalRazor.Models;

namespace CarRentalRazor.Data
{
    public class CustomerRepository : ICustomer
    {
        public ApplicationDbContext applicationDbContext;
        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Customer> GetAll()
        {
            return applicationDbContext.Customers.OrderBy(x => x.Id);
        }

        public Customer GetById(int id)
        {
            return applicationDbContext.Customers.FirstOrDefault(x => x.Id == id);
        }
    }
}
