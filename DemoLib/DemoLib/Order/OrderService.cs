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

        public List<Order> GetAllOrders()
        {
            return repository_.GetAllOrders();
        }

        public void AddOrder(Order order)
        {
            repository_.AddOrder(order);
        }

        public int GenerateNextId()
        {
            List<Order> orders = repository_.GetAllOrders();
            int id = 0;
            foreach (Order o in orders)
            {
                if (o.id_ > id)
                {
                    id = o.id_;
                }
            }
            return id + 1;
            //return repository_.GetAllOrders().Count() + 1;
        }

        public void EditOrder(Order order)
        {
            repository_.EditOrder(order);
        }

        public void DeleteOrder(Order order)
        {
            repository_.DeleteOrder(order);
        }
    }
}
