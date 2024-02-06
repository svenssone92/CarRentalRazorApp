using CarRentalRazor.Models;

namespace CarRentalRazor.Data
{
    public class AdminRepository : IAdmin
    {
        public ApplicationDbContext applicationDbContext;
        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Admin> GetAll()
        {
            return applicationDbContext.Admins.OrderBy(x => x.Id);
        }

        public Admin GetById(int id)
        {
            return applicationDbContext.Admins.FirstOrDefault(x => x.Id == id);
        }
    }
}
