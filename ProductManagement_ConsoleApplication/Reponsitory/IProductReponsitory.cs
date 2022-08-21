using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductObject;

namespace ProductManagement_ConsoleApplication.Reponsitory
{
    public interface IProductReponsitory
    {
        public int CountProduct();
        public void AddProduct();
        public void UpdateProduct(int ID);
        public void SortByPrice();
        public Product FindByID(int ID);
        public bool DeleteById(int ID);
        public void ShowProduct(List<Product> product);
        public List<Product> FindByName(String keyword);
        public List<Product> getListSinhVien();
    }
}
