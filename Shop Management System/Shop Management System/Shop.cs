using Shop_Management_System.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System
{
    internal class Shop
    {
        // Class for the driver code of the Shop Management System

        public void Start()
        { 
           while(true)
            {
                Console.Clear();
                string option = MainMenu();
                if (option == "1")
                {
                    ProductUI productUI = new ProductUI();
                    productUI.ProductDriver();
                }
                else if (option == "2")
                {
                    // Customer Management
                }
                else if (option == "3")
                {
                    // Order Management
                }
                else if (option == "4")
                {
                    // View Order History
                }
                else if (option == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
            }
        }

        public string MainMenu()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("----------Welcome to the Shop Management System------------");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("1- Product Management");
            Console.WriteLine("2- Customer Management");
            Console.WriteLine("3- Order Management");
            Console.WriteLine("4- View Order History");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5- Exit");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------------");
            String option = Console.ReadLine();
            return option;

        }
    }
}
