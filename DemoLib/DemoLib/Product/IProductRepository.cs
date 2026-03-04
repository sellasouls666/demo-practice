using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Product
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
    }
}
