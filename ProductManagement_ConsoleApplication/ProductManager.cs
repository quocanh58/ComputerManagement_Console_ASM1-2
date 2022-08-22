using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductObject;

namespace ProductManagement_ConsoleApplication
{
    public class ProductManager
    {
        public static List<Product> listProducts;
        public int GenerateID()
        {
            int max = 1;
            if (listProducts != null && listProducts.Count > 0)
            {
                max = listProducts[0].ProductId;
                foreach (var product in listProducts)
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
        public List<Product> getListProduct()
        {
            return listProducts;
        }

        public void ShowProduct(List<Product> listProduct)
        {
            Console.WriteLine("{0, -5} {1, -20} {2, -13} {3, -21} {4, -10} {5, -10} {6, -5}",
                  "ID", "Name", "Type", "DateInput", "Price", "Country", "Quantity");
            if (listProduct != null && listProduct.Count > 0)
            {
                foreach (Product product in listProduct)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -13} {3, -21} {4, -10} {5, -10} {6, -5}",
                                      product.ProductId, product.ProductName, product.ProductType,
                                      product.ProductDate, product.ProductPrice,
                                      product.ProductCountry == 1 ? "EUROPE" : "ARFICA", product.ProductQuatity);
                }
            }
            Console.WriteLine();
        }

        public List<Product> GetAllProduct()
        {
            return this.GetAllProduct();
        }

        // Add new product
        public void AddProduct()
        {
            Product product = null;

            Console.Write("Enter country of product (1.EUROPE - 2.Africa): ");
            int country = Convert.ToInt32(Console.ReadLine());

            if (country == 1)
            {
                product = new ProductEU();
            }
            else
            {
                product = new ProductAfc();

            }

            product.ProductCountry = country;

            product.ProductId = GenerateID();

            Console.Write("Enter name product: ");
            product.ProductName = Convert.ToString(Console.ReadLine());

            Console.Write("Enter type of product (1.Laptop - 2.Desktop): ");
            string checkType = "";
            int type = Convert.ToInt32(Console.ReadLine());
            if (type == 1)
            {
                checkType = "Laptop";
            }
            else if (type == 2)
            {
                checkType = "Desktop";
            }
            else
            {
                Console.Write("Re-Enter type of product (1.Laptop - 2.Desktop): ");
                checkType = "";
                type = Convert.ToInt32(Console.ReadLine());
            }
            product.ProductType = checkType;

            Console.Write("Enter date input of product (MM DD YYYY): ");
            DateTime dt = DateTime.Parse(Console.ReadLine());
            string str = dt.ToString("yyyy MMMM dd");
            product.ProductDate = str;

            Console.Write("Enter price of product: ");
            double price = Convert.ToDouble(Console.ReadLine());
            while (price <= 0)
            {
                Console.Write("Re-Enter Price: ");
                price = Convert.ToInt32(Console.ReadLine());
            }
            product.ProductPrice = price;

            Console.Write("Enter quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            while (quantity < 0)
            {
                Console.Write("Re-Enter quantity: ");
                quantity = Convert.ToInt32(Console.ReadLine());
            }
            product.ProductQuatity = quantity;

            if (listProducts != null && listProducts.Count > 0)
            {
                listProducts.Add(product);
            }
            else
            {
                listProducts = new List<Product>();
                listProducts.Add(product);
            }

        }

        //Return quantity products at present on list
        public int CountProduct()
        {
            int count = 0;
            if (listProducts != null)
            {
                count = listProducts.Count;
            }
            return count;
        }

        //Sort lis product by price asadescending
        public void SortByPrice()
        {
            listProducts.Sort(delegate (Product pro1, Product pro2)
            {
                return pro1.ProductPrice.CompareTo(pro2.ProductPrice);
            });
        }

        //Delete product by id
        public bool DeleteById(int id)
        {
            bool IsDelete = false;
            Product product = FindProductByID(id);
            if (product != null)
            {
                IsDelete = listProducts.Remove(product);
            }
            return IsDelete;
        }

        //Find product by id
        public Product FindProductByID(int id)
        {
            Product productFind = null;
            if (listProducts != null && listProducts.Count > 0)
            {
                foreach (Product pro in listProducts)
                {
                    if (pro.ProductId == id)
                    {
                        productFind = pro;
                    }
                }
            }
            return productFind;
        }

        //Search product by name
        public List<Product> FindProductByName(string name)
        {
            List<Product> productsFind = new List<Product>();

            if (listProducts != null && listProducts.Count > 0)
            {
                foreach (Product pro in listProducts)
                {
                    if (pro.ProductName.ToUpper().Contains(name.ToUpper()))
                    {
                        productsFind.Add(pro);
                    }
                }
            }
            return productsFind;
        }

        //Update information product
        public void UpdateProduct(int id)
        {
            Product product = FindProductByID(id);
            if (product != null)
            {
                Console.Write("Enter name product: ");
                string name = Convert.ToString(Console.ReadLine());
                if (name != null && name.Length > 0)
                {
                    product.ProductName = name;
                }

                Console.Write("Enter type of product (1.Laptop - 2.Desktop): ");
                string type = Convert.ToString(Console.ReadLine());
                if (type != null && type.Length > 0)
                {
                    product.ProductType = type;
                }

                Console.Write("Enter date input of product (MM DD YYYY): ");
                DateTime dt = DateTime.Parse(Console.ReadLine());
                string str = dt.ToString("yyyy MMMM dd");
                if (str != null && str.Length > 0)
                {
                    product.ProductDate = str;
                }

                Console.Write("Enter pirce product: ");
                string price = Convert.ToString(Console.ReadLine());
                if (price != null && price.Length > 0)
                {
                    product.ProductPrice = Convert.ToDouble(price);
                }

                Console.Write("Enter Country product: ");
                string country = Convert.ToString(Console.ReadLine());
                if (country != null && country.Length > 0)
                {
                    product.ProductCountry = Convert.ToInt32(country);
                }

                Console.Write("Enter quantity product: ");
                string quantity = Convert.ToString(Console.ReadLine());
                if (name != null && name.Length > 0)
                {
                    product.ProductQuatity = Convert.ToInt32(quantity);
                }
            }
            else
            {
                Console.WriteLine("Product has ID: " + id + " not exist !!");
            }
        }

        public void ShowLisCostEU()
        {
            foreach (var pro in listProducts)
            {
                if (pro.ProductCountry == 1)
                {
                    pro.DisplayInfo();
                }
            }
        }
        public void ShowLisCostARF()
        {
            foreach (var pro in listProducts)
            {
                if (pro.ProductCountry == 2)
                {
                    pro.DisplayInfo();
                }
            }
        }


    }
}
