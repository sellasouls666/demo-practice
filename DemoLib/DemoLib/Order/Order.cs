using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.Order
{
    public class Order
    {
        public int id_ { get; set; }
        public DateTime orderDate_ { get; set; }
        public DateTime delieveryDate_ { get; set; }
        public int idPickup_ { get; set; }
        public string fio_ { get; set; }
        public int code_ { get; set; }
        public string status_ { get; set; }
        public string userLogin_ { get; set; }
        public List<OrderProductRecord> orderProducts { get; set; }
    }
}
