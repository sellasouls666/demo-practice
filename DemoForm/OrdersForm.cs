using DemoLib.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.User;

namespace DemoForm
{
    public partial class OrdersForm: Form
    {
        private OrderService orderService_;
        private List<Order> orders_ = new List<Order>();
        private User currentUser_ = null;
        public OrdersForm(User user)
        {
            InitializeComponent();
            currentUser_ = user;
        }
    }
}
