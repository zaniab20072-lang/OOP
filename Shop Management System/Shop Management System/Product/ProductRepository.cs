using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;   

namespace Shop_Management_System.Product
{
    internal class ProductRepository
    {
        private readonly string file = "products.txt";
        public ProductRepository() { }
        public void SaveInFile(ProductModel product)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(product.ToString());
            }
        }
        public void SaveInFile(List<ProductModel> productsList)
        {
            File.WriteAllText(file, "");
            foreach (var product in productsList)
                {
                    SaveInFile(product);
            }
            
        }
        public List<ProductModel> GetProductsFromFile()
        {
            List<ProductModel> productsList = new List<ProductModel>();
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    string description = parts[1];
                    float purchasePrice = float.Parse(parts[2]);
                    float salePrice = float.Parse(parts[3]);
                    float discount = float.Parse(parts[4]);
                    ProductModel product = new ProductModel(name, description, purchasePrice, salePrice, discount);
                    productsList.Add(product);
                }
            }
            return productsList;
        }
    }
}
