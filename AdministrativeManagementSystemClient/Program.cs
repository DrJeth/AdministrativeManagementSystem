using AdministrativeManagementSystemData;
using AdministrativeManagementSystemModels;
using AdministrativeManagementSystemServices;
using System;


namespace AdministrativeManagementSystemClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">>>>>>>>Administrative Management System Service<<<<<<<<");
            Console.WriteLine("---------------List of Users Account Data---------------");

            AccountGetServices getServices = new AccountGetServices();
            var users = getServices.GetAllUsers();

            foreach (var item in users)
            {
                Console.WriteLine("\n------------------------PAGE----------------------------");
                Console.WriteLine("Account Details:");
                Console.WriteLine("Email Address:" + item.email);
                Console.WriteLine("User Name:" + item.username);
                Console.WriteLine("Password:" + item.password);
                Console.WriteLine("User Identification:" + item.userID);
                Console.WriteLine("Contact Number:" + item.contactnumber);
                Console.WriteLine("\n----------------------PAGEBREAK-------------------------");
            }

        }
    }
}