using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Product
{
    internal class ProductService
    {
        private ProductRepository _repository = new ProductRepository();
        public ProductService()
        { }
        public List<ProductModel> GetAllProducts()
        {
            return _repository.GetProductsFromFile();
        }
        public void SaveProduct(ProductModel product)
        {
            _repository.SaveInFile(product);
        }
        public ProductModel SearchByName(string name)
        { 
            foreach(var product in _repository.GetProductsFromFile())
            {
                if (product.GetName() == name)
                {
                    return product;
                }
            }
            return null;
        }
        public bool UpdteProductPrice(string name, float SalePrice)
        { 
            List<ProductModel> productsList = _repository.GetProductsFromFile();
            foreach(var product in productsList)
            {
                if (product.GetName() == name)
                {
                    product.SetSalePrice(SalePrice);
                    _repository.SaveInFile(productsList);
                    return true;
                }
            } 
            return false;
        }
        public bool DeleteProduct(string name)
        {
            List<ProductModel> productsList = _repository.GetProductsFromFile();
            int count = 0;
            foreach (var product in productsList)
            {
                if (product.GetName() == name)
                {
                    productsList.RemoveAt(count);
                    _repository.SaveInFile(productsList);
                    return true;
                }
                count++;
            }
            return false;
        }
    }
}
