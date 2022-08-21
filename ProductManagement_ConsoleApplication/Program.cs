using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductObject;
using ProductManagement_ConsoleApplication.Reponsitory;

namespace ProductManagement_ConsoleApplication;

public class ProductManagement_ConsoleApplication
{
    public static void Main(string[] args)
    {

        while (true)
        {
            IProductReponsitory productReponsitory = new ProductReponsitory();
            ProductManager productManager = new ProductManager();

            Console.WriteLine("");
            Console.WriteLine("\t\t  PRODUCT MANAGEMENT");
            Console.WriteLine("\t\t\t*****\n");
            Console.WriteLine("*************************MENU**************************");
            Console.WriteLine("**  1. Add new product.                              **");
            Console.WriteLine("**  2. Update information a product by ID            **");
            Console.WriteLine("**  3. Delete product by ID.                         **");
            Console.WriteLine("**  4. Search product by Name.                       **");
            Console.WriteLine("**  5. Sort list product by Price (asdescending).    **");
            Console.WriteLine("**  6. Show list product.                            **");
            Console.WriteLine("**  7. Show list cost of product EURPOE.             **");
            Console.WriteLine("**  8. Show list cost of product ARFICA.             **");
            Console.WriteLine("**  9. Check product in stock.                       **");
            Console.WriteLine("**  0. Exit                                          **");
            Console.WriteLine("*******************************************************");
            Console.Write("Enter your choice: ");

            try
            {
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("\n1. Add a new product.");
                        productManager.AddProduct();
                        Console.WriteLine("\n>> Add a new product successfull !!");
                        break;
                    case 2:
                        Console.WriteLine("\n2. Update a product.");
                        Console.Write("Enter ID you want to update: ");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        productManager.UpdateProduct(updateId);
                        Console.WriteLine("Product ID: " + updateId + " had updated !!");
                        break;
                    case 3:
                        if (productManager.CountProduct() > 0)
                        {
                            Console.WriteLine("\n3. Delete a product by ID...");
                            Console.Write("Enter ID you want to delete: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (productManager.DeleteById(id))
                            {
                                Console.WriteLine("Product ID: " + id + "had deleted !");
                            }
                        }
                        else
                        {
                            Console.WriteLine(">> List product is empty !!");
                        }
                        break;

                    case 4:
                        if (productManager.CountProduct() > 0)
                        {
                            Console.WriteLine("4. Find a product by name..");
                            Console.Write("Enter name product to find: ");
                            string name = Convert.ToString(Console.ReadLine());
                            List<Product> findProduct = productManager.FindProductByName(name);
                            if (findProduct != null)
                            {
                                productManager.ShowProduct(findProduct);
                            }
                            else
                            {
                                Console.WriteLine("Don't find " + name + "in list product");
                            }
                        }
                        else
                        {
                            Console.WriteLine("List product is empty !!");
                        }
                        break;
                    case 5:
                        if (productManager.CountProduct() > 0)
                        {
                            Console.WriteLine("\n5. Sort lis product by Price (asdescending)");
                            productManager.SortByPrice();
                            productManager.ShowProduct(productManager.getListProduct());
                        }
                        else
                        {
                            Console.WriteLine("List product is empty !!");
                        }
                        break;
                    case 6:
                        if (productManager.CountProduct() > 0)
                        {
                            Console.WriteLine("\n6. Show list product.");
                            productManager.ShowProduct(productManager.getListProduct());
                            int count = productManager.CountProduct();
                            Console.WriteLine("Total: " + count + " product(s)");
                        }
                        else
                        {
                            Console.WriteLine("List product is empty !!");
                        }
                        break;
                    case 7:
                        productManager.ShowLisCostEU();
                        break;
                    case 8:
                        productManager.ShowLisCostARF();
                        break;
                    case 9:
                        if (productManager.CountProduct() > 0)
                        {
                            Console.Write("Enter name product to checking: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Product product = productManager.FindProductByID(id);
                            if (product.ProductQuatity == 0)
                            {
                                Console.WriteLine("Product has ID " + product.ProductId + " not stocking !");
                            }
                            else
                            {
                                Console.WriteLine("Product has ID " + product.ProductId + " stock " 
                                                                     + product.ProductQuatity + " product(s)");
                            }
                        }
                        else
                        {
                            Console.WriteLine("List product is empty !!");
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nYou have exited the program...");
                        return;
                    default:
                        Console.WriteLine("\nDon't have a function...");
                        Console.WriteLine("\nPlease, you choose other function !");
                        break;
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Not valid. Please choose again !!");
            }
        }
    }
}