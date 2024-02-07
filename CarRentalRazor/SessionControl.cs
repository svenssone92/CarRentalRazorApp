using CarRentalRazor.Models;

namespace CarRentalRazor
{
    public class SessionControl
    {
        public static void SetCustomerData(ISession session, Customer customer)
        {
            session.SetInt32("CustomerId", customer.Id);
            session.SetString("CustomerFirstName", customer.FirstName);
            session.SetString("CustomerLastName", customer.LastName);
            session.SetString("CustomerEmail", customer.Email);
        }

        public static void RemoveCustomerData(ISession session)
        {
            session.Remove("CustomerId");
            session.Remove("CustomerFirstName");
            session.Remove("CustomerLastName");
            session.Remove("CustomerEmail");
        }

        public static bool IsCustomer(ISession session)
        {
            return session.GetInt32("CustomerId") != null;
        }


        public static void SetAdminData(ISession session, Admin admin)
        {
            session.SetInt32("AdminId", admin.Id);
            session.SetString("AdminFirstName", admin.FirstName);
            session.SetString("AdminLastName", admin.LastName);
            session.SetString("AdminEmail", admin.Email);
        }

        public static void RemoveAdminData(ISession session)
        {
            session.Remove("AdminId");
            session.Remove("AdminFirstName");
            session.Remove("AdminLastName");
            session.Remove("AdminEmail");
        }

        public static bool IsAdmin(ISession session)
        {
            return session.GetInt32("AdminId") != null;
        }
    }
}
