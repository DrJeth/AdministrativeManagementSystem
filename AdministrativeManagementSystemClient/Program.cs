using AdministrativeManagementSystemData;
using AdministrativeManagementSystemModels;
using AdministrativeManagementSystemServices;
using System;
using System.Collections.Generic;

namespace AdministrativeManagementSystemClient
{
    internal class Program
    {
        static SqlDbData dbData = new SqlDbData();

        static void Main(string[] args)
        {
            bool isActive = true;

            while (isActive)
            {
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(">>>>>>>>Administrative Management System Service<<<<<<<<");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("1 - View Records");
                Console.WriteLine("2 - Add Record");
                Console.WriteLine("3 - Update Record");
                Console.WriteLine("4 - Delete Record");
                Console.Write("Enter An Option. Type 0 to exit: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        isActive = false;
                        break;

                    case "1":
                        GetUsers();
                        break;

                    case "2":
                        AddUser();
                        break;

                    case "3":
                        UpdateUser();
                        break;

                    case "4":
                        DeleteUser();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void GetUsers()
        {
            var users = dbData.GetUsers();

            foreach (var item in users)
            {
                Console.WriteLine("\n------------------------PAGE----------------------------");
                Console.WriteLine("Account Details:");
                Console.WriteLine("Email Address: " + item.email);
                Console.WriteLine("User Name: " + item.username);
                Console.WriteLine("Password: " + item.password);
                Console.WriteLine("User Identification: " + item.userID);
                Console.WriteLine("Contact Number: " + item.contactnumber);
                Console.WriteLine("\n----------------------PAGEBREAK-------------------------");
            }
        }

        static void AddUser()
        {
            Console.WriteLine("\n------------------------PAGE----------------------------");
            Console.WriteLine("+Adding New Record Process+");
            Console.WriteLine("");
            Console.WriteLine("Enter a email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter a username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter a password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter a User ID: ");
            string userID = Console.ReadLine();
            Console.WriteLine("Enter a contact number: ");
            string contactnumber = Console.ReadLine();
            
            int result = dbData.AddUser(email, username, password, userID, contactnumber);
            Console.WriteLine("");
            Console.WriteLine(result > 0 ? "User added successfully." : "Error adding Record.");
            Console.WriteLine("\n----------------------PAGEBREAK-------------------------");

        }

        static void UpdateUser()
        {
            Console.WriteLine("\n------------------------PAGE----------------------------");
            Console.WriteLine("+Updating Record Process+");
            Console.WriteLine("");
            Console.WriteLine("Enter a User ID to update: ");
            string userID = Console.ReadLine();
            Console.WriteLine("Enter a new email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter a new username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter a new password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter a new contact number: ");
            string contactnumber = Console.ReadLine();

            int result = dbData.UpdateUser(email, username, password, userID, contactnumber);
            Console.WriteLine("");
            Console.WriteLine(result > 0 ? "User updated successfully." : "Error Updating Record.");
            Console.WriteLine("\n----------------------PAGEBREAK-------------------------");
        }

        static void DeleteUser()
        {
            Console.WriteLine("\n------------------------PAGE----------------------------");
            Console.WriteLine("+Deleting Record+");
            Console.WriteLine("");
            Console.WriteLine("Enter User ID to Delete Record: ");
            string userID = Console.ReadLine();
            
            int result = dbData.DeleteUser(userID);
            Console.WriteLine("");
            Console.WriteLine(result > 0 ? "User deleted successfully." : "Error Deleting Record.");
            Console.WriteLine("\n----------------------PAGEBREAK-------------------------");
        }
    }
}