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
    }
}
