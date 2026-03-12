using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Order
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        void AddOrder(Order order);
        void EditOrder(Order order);
    }
}
