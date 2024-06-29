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

        public bool CheckIfUserNameExists(string email)
        {
            bool result = getservices.GetUser(email) != null;
            return result;
        }

        public bool CheckIfUserExists(string userID)
        {
            bool result = getservices.GetUser(userID) != null;
            return result;
        }

    }
}

