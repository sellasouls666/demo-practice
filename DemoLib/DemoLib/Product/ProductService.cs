using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Product
{
    public class ProductService
    {
        private IProductRepository repository_;
        public ProductService(IProductRepository repository)
        {
            repository_ = repository;
        }
        public List<Product> GetAllProducts()
        {
            return repository_.GetAllProducts();
        }

        public List<string> GetAllSuppliers()
        {
            List<string> allSuppliers = new List<string>();
            allSuppliers.Add("Все поставщики");
            List<Product> allProducts = repository_.GetAllProducts();
            foreach (var product in allProducts)
            {
                if (!allSuppliers.Contains(product.supplier_)) //проверка, что поставщики в списке не повторяются
                {
                    allSuppliers.Add(product.supplier_);
                }
            }
            return allSuppliers;
        }

        public void AddProduct(Product product)
        {
            repository_.AddProduct(product); 
        }
    }
}
