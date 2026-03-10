using DemoLib.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Order
{
    public class OrderService
    {
        private IOrderRepository repository_;
        public OrderService(IOrderRepository repository)
        {
            repository_ = repository;
        }
    }
}
