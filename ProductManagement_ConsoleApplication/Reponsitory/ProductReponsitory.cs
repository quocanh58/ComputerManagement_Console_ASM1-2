using ProductObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement_ConsoleApplication.Reponsitory
{
    public class ProductReponsitory : IProductReponsitory
    {
        List<Product> ListPrducts = null;
        public ProductReponsitory()
        {
            ListPrducts = new List<Product>();
        }

        // Add new product
        void IProductReponsitory.AddProduct()
        {
            Product product = new ProductEU();

            product.ProductId = GenerateID();

            Console.Write("Enter name product: ");
            product.ProductName = Convert.ToString(Console.ReadLine());

            Console.Write("Enter type of product:(1.Laptop - 2.Desktop): ");
            product.ProductType = Convert.ToString(Console.ReadLine());

            Console.Write("Enter date input of product: ");
            //product.ProductDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter price of product: ");
            product.ProductPrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter country of product (1.EUROPE - 2.Africa): ");
            product.ProductCountry = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter quantity: ");
            product.ProductQuatity = Convert.ToInt32(Console.ReadLine());

            ListPrducts.Add(product);
        }

        // Return quantity products at present.
        int IProductReponsitory.CountProduct()
        {
            int count = 0;
            if (ListPrducts != null)
            {
                count = ListPrducts.Count;
            }
            return count;
        }

        bool IProductReponsitory.DeleteById(int ID)
        {
            throw new NotImplementedException();
        }

        Product IProductReponsitory.FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        List<Product> IProductReponsitory.FindByName(string keyword)
        {
            throw new NotImplementedException();
        }

        //ID product auto increases
        private int GenerateID()
        {
            int max = 1;
            if (ListPrducts != null && ListPrducts.Count > 0)
            {
                max = ListPrducts[0].ProductId;
                foreach (var product in ListPrducts)
                {
                    if (max < product.ProductId)
                    {
                        max = product.ProductId;
                    }
                }
                max++;
            }
            return max;
        }

        List<Product> IProductReponsitory.getListSinhVien()
        {
            return ListPrducts;
        }

        void IProductReponsitory.ShowProduct(List<Product> listProduct)
        {
            Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, 12} {4, 10} {5, 10} {6, 5}",
                  "ID", "Name", "Type", "DateInput", "Price", "Country", "Quantity");
            if (listProduct != null && listProduct.Count > 0)
            {
                foreach (Product product in listProduct)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, 12} {4, 10} {5, 10} {6, 5}",
                                      product.ProductId, product.ProductName, product.ProductType, product.ProductDate,
                                      product.ProductPrice, product.ProductCountry, product.ProductQuatity);
                }
            }
            Console.WriteLine();
        }

        void IProductReponsitory.SortByPrice()
        {
            throw new NotImplementedException();
        }

        void IProductReponsitory.UpdateProduct(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
