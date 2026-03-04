using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLib.Product;

namespace DemoLib.View
{
    public interface IProductCard
    {
        void ShowProductInfo(DemoLib.Product.Product product);
    }
}
