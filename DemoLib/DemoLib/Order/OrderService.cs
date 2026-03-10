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

        public bool CheckArticul(DemoLib.Product.Product product)
        {
            List<Order> orders = new List<Order>();
            orders = repository_.GetAllOrders();
            foreach (Order o in orders)
            {
                foreach (OrderProductRecord op in o.orderProducts)
                {
                    if (op.articul_.Contains(product.articul_))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
