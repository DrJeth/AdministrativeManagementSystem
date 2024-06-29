using AdministrativeManagementSystem;
using AdministrativeManagementSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativeManagementSystemServices
{
    public class AccountRecordServices
    {
        AccountTrackingServices recordstracking = new AccountTrackingServices();
        AccountData userData = new AccountData();

        public bool CreateUser(Account user)
        {
            bool result = false;

            if (recordstracking.CheckIfUserNameExists(user.username))
            {
                result = userData.AddUser(user) > 0;
            }

            return result;
        }

        public bool CreateUser(string email, string username, string password, string userID, string contactnumber)
        {
            Account user = new Account { email = email, username = username, password = password, userID = userID, contactnumber = contactnumber };

            return CreateUser(user);
        }

        public bool UpdateUser(Account user)
        {
            bool result = false;

            if (recordstracking.CheckIfUserNameExists(user.username))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(string email, string username, string password, string userID, string contactnumber)
        {
            Account user = new Account { email = email, username = username, password = password, userID = userID, contactnumber = contactnumber };

            return UpdateUser(user);
        }

        public bool DeleteUser(Account user)
        {
            bool result = false;

            if (recordstracking.CheckIfUserNameExists(user.username))
            {
                result = userData.DeleteUser(user) > 0;
            }

            return result;
        }
    }
}