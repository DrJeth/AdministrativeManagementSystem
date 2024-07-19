using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativeManagementSystemServices
{
    public class AccountTrackingServices
    {
        AccountGetServices getservices = new AccountGetServices();

        public bool CheckIfUserNameExists(string username)
        {
            bool result = getservices.GetUser(username) != null;
            return result;
        }

        public bool CheckIfUserExists(string userID)
        {
            bool result = getservices.GetUser(userID) != null;
            return result;
        }

    }
}

