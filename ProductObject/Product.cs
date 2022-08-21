using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductObject
{
    public abstract class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string ProductDate { get; set; }
        public double ProductPrice { get; set; }
        public int ProductCountry { get; set; }
        public int ProductQuatity { get; set; }

        public Product(int productId, string productName, string productType, string productDate, double productPrice, int productCountry, int productQuatity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductType = productType;
            ProductDate = productDate;
            ProductPrice = productPrice;
            ProductCountry = productCountry;
            ProductQuatity = productQuatity;
        }
        public Product() { }

        public override string? ToString()
        {
            return "Id: " + ProductId + "\tName: " + ProductName + "\tType: " + ProductType +
                   "\tDateInput: " + ProductDate + "\tPrice: " + ProductPrice + "\tCountry: " + ProductCountry +
                   "\tQuantity: " + ProductQuatity;
        }
        public abstract double CalculatorCost();
        public virtual void DisplayInfo()
        {
            Console.Write("Product " + ProductName + " has ID: " + ProductId);
        }

    }
}
