using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System.Product
{
    internal class ProductModel
    {
        private string name;
        private string description;
        private float purchasePrice;
        private float salePrice;
        private float discount;

        public ProductModel()
        { }

        public ProductModel(string name, string description, float pPrice, float salePrice, float discount)
        {
            this.name = name;
            this.description = description;
            this.purchasePrice = pPrice;
            this.salePrice = salePrice;
            this.discount = discount;
        }
        public void SetName(string name) { this.name = name; }
        public string GetName() { return this.name; }
        public void SetDescription(string description) { this.description = description; }
        public string GetDescription() { return this.description; }
        public void SetPurchasePrice(float purchasePrice) { this.purchasePrice = purchasePrice; }
        public float GetPurchasePrice() { return this.purchasePrice; }
        public void SetSalePrice(float salePrice) { this.salePrice = salePrice; }
        public float GetSalePrice() { return this.salePrice - discount; }
        public float GetDiscount() { return this.discount; }

        public override string ToString()
        {
            return $"Product Name: {name},Description: {description},Purchase Price: {purchasePrice},Sale Price: {salePrice},Discount: {discount}";
        }
    }
}
