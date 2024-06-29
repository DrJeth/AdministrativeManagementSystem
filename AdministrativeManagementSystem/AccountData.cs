using AdministrativeManagementSystemModels;
using AdministrativeManagementSystemData;
using System.Data.SqlClient;


namespace AdministrativeManagementSystem
{
    public class AccountData
    {
        List<Account> users;
        SqlDbData sqlData;
        public AccountData()
        {
            users = new List<Account>();
            sqlData = new SqlDbData();
        }

        public List<Account> GetUsers()
        {
            users = sqlData.GetUsers();
            return users;
        }

        public int AddUser(Account user)
        {
            return sqlData.AddUser(user.email, user.username, user.password, user.userID, user.contactnumber);
        }

        public int UpdateUser(Account user)
        {
            return sqlData.UpdateUser(user.email, user.username, user.password, user.userID, user.contactnumber);
        }

        public int DeleteUser(Account user)
        {
            return sqlData.DeleteUser(user.email);
        }
    }
}