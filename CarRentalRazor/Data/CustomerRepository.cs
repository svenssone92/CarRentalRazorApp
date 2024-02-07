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

        public void Add(Customer customer)
        {
            applicationDbContext.Add(customer);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            applicationDbContext.Remove(customer);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return applicationDbContext.Customers.OrderBy(x => x.Id);
        }

        public Customer GetById(int id)
        {
            return applicationDbContext.Customers.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Customer customer)
        {
            applicationDbContext.Update(customer);
            applicationDbContext.SaveChanges();
        }
    }
}
