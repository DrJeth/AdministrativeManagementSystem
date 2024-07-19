using AdministrativeManagementSystemModels;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdministrativeManagementSystemData
{
    public class SqlDbData
    {
        string connectionString
        //"Data Source =LAPTOP-Q6PHMPP5\\SQLEXPRESS; Initial Catalog = AdministrativeManagement; Integrated Security = True;";
        = "Server=tcp:20.189.122.172;Database=AdministrativeManagement;User Id=sa; Password=Jethro2003@pup";

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            this.sqlConnection = new SqlConnection(connectionString);
        }

        public List<Account> GetUsers()
        {
            string SELECT = "SELECT * FROM Accounts";

            SqlCommand selectCommand = new SqlCommand(SELECT, sqlConnection);

            sqlConnection.Open();
            List<Account> users = new List<Account>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string email = reader["email"].ToString();
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();
                string userID = reader["userID"].ToString();
                string contactnumber = reader["contactnumber"].ToString();

                Account readUser = new Account();
                readUser.email = email;
                readUser.username = username;
                readUser.password = password;
                readUser.userID = userID;
                readUser.contactnumber = contactnumber;

                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public int AddUser(string email, string username, string password, string userID, string contactnumber)
        {
            int success;

            string insertStatement = "INSERT INTO Accounts VALUES (@email, @username, @password, @userID, @contactnumber)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@email", email);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.Parameters.AddWithValue("@userID", userID);
            insertCommand.Parameters.AddWithValue("@contactnumber", contactnumber);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateUser(string email, string username, string password, string userID, string contactnumber)
        {
            int success;

            string updateStatement = $"UPDATE Accounts SET email = @email, username = @username, password = @password, contactnumber = @contactnumber WHERE userID = @userID";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@email", email);
            updateCommand.Parameters.AddWithValue("@username", username);
            updateCommand.Parameters.AddWithValue("@password", password);
            updateCommand.Parameters.AddWithValue("@userID", userID);
            updateCommand.Parameters.AddWithValue("@contactnumber", contactnumber);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteUser(string userID)
        {
            int success;

            string deleteStatement = $"DELETE FROM Accounts WHERE userID = @userID";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@userID", userID);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}
