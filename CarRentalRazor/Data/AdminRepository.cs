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

        public void Add(Admin admin)
        {
            applicationDbContext.Add(admin);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Admin admin)
        {
            applicationDbContext.Remove(admin);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Admin> GetAll()
        {
            return applicationDbContext.Admins.OrderBy(x => x.Id);
        }

        public Admin GetById(int id)
        {
            return applicationDbContext.Admins.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Admin admin)
        {
            applicationDbContext.Update(admin);
            applicationDbContext.SaveChanges();
        }
    }
}
