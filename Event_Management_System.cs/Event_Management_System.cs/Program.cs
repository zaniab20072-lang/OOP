using Event_Management_System.cs.Booking_Customer;
using Event_Management_System.cs.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("********************************************************************************");
                Console.WriteLine("                 Welcome to the Event Management System!");
                Console.WriteLine("********************************************************************************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1. Admin or Event Organizer ");
                Console.WriteLine(" 2. Customer");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" 3. Exit");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Please select an option:");
                string choice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (choice == "1")
                {
                    Console.WriteLine();

                    Console.Write(" Enter UserName : ");
                    string userName = Console.ReadLine();

                    Console.Write(" Enter Password : ");
                    string password = Console.ReadLine();

                    if(userName == "Zainab" && password == "2429")
                    { 
                        EventUI eventUI = new EventUI();
                        eventUI.ShowEventMenu();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n Invalid Option. Please try again.");
                        Console.WriteLine(" Press any key to continue...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                    }
                }
                else if (choice == "2")
                {
                    CustomerUI customerUI = new CustomerUI();
                    customerUI.ShowCustomerMenu();
                }
                else if (choice == "3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(" Exiting the program. Goodbye!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" Invalid choice. Please try again.");
                    Console.WriteLine(" Press Any Key to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
               

            }
        }
    }
}
