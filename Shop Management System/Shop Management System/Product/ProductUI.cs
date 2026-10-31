using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Product
{
    internal class ProductUI
    {
        ProductService service = new ProductService();
        public void ProductDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = ProductMenu();
                if (option == "1")
                {
                    ProductModel product = TakeInput();
                    service.SaveProduct(product);
                }
                else if (option == "2")
                {
                    UpdateProduct();
                }
                else if (option == "3")
                {
                    DeleteProduct();
                }
                else if (option == "4")
                {
                    DisplayAll();
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
        public void UpdateProduct()
        {
            Console.WriteLine("Enter Product Name to Update: ");
            string name = Console.ReadLine();
            ProductModel product = service.SearchByName(name);
            if (product != null)
            {
                Console.WriteLine("Enter New Sale Price: ");
                float salePrice = float.Parse(Console.ReadLine());
                service.UpdteProductPrice(name, salePrice);
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }
        }
        public void DeleteProduct()
        {
            Console.WriteLine("Enter Product Name to Delete: ");
            string name = Console.ReadLine();
            bool isDeleted = service.DeleteProduct(name);
            if (isDeleted)
            {
                Console.WriteLine("Product Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }
        }
        public void DisplayAll()
        { 
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("-------------------- Product List -------------------------");
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var product in service.GetAllProducts())
            {
                Console.WriteLine(product.ToString());
            }
        }
        public ProductModel TakeInput()
        {
            Console.WriteLine("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Product Purchase Price: ");
            float purchasePrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Sale Price: ");
            float salePrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Discount: ");
            float discount = float.Parse(Console.ReadLine());
            ProductModel product = new ProductModel(name, description, purchasePrice, salePrice, discount);
            return product;
        }
        public string ProductMenu()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("-------------------- Product Management -------------------");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("1- Add");
            Console.WriteLine("2- Update");
            Console.WriteLine("3- Delete");
            Console.WriteLine("4- View ALL");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5- Exit");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------------");
            String option = Console.ReadLine();
            return option;

        }
    }
}
