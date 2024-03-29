﻿using ProductObject;
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

        IProductReponsitory _product;
        public ProductReponsitory()
        {
            ListPrducts = new List<Product>();
        }

        // Add new product
        void IProductReponsitory.AddProduct()
        {
            this._product.AddProduct();
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
            if (this._product.DeleteById(ID))
            {
                return true;
            }
            return false;
        }

        Product IProductReponsitory.FindByID(int ID)
        {
            return this._product.FindByID(ID);
        }

        List<Product> IProductReponsitory.FindByName(string keyword)
        {
            return _product.FindByName(keyword);
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
            _product.getListSinhVien().Sort();
        }

        void IProductReponsitory.UpdateProduct(int ID)
        {
            //
        }
    }
}
