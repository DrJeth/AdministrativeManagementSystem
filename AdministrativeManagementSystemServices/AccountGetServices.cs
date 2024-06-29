using AdministrativeManagementSystem;
using AdministrativeManagementSystemData;
using AdministrativeManagementSystemModels;
using System.Security.Principal;

namespace AdministrativeManagementSystemServices
{
    public class AccountGetServices
    {
        public List<Account> GetAllUsers()
        {
            AccountData accountdata = new AccountData();
            return accountdata.GetUsers();
        }

        public Account Getusersemail(string email)
        {
            Account acc = new Account();

            foreach (var user in GetAllUsers())
            {
                if (user.email == email)
                {
                    acc = user;
                }
            }
            return acc;
        }

        public Account GetUsernameandPassword(string username, string password)
        {
            Account acc = new Account();

            foreach (var user in GetAllUsers())
            {
                if (user.username == username && user.password == password)
                {
                    acc = user;
                }
            }
            return acc;
        }

        public Account GetUser(string userID)
        {
            Account acc = new Account();

            foreach (var user in GetAllUsers())
            {
                if (user.userID == userID)
                {
                    acc = user;
                }
            }

            return acc;
        }
    }
}