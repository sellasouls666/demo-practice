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
using DemoLib.Product;

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

            var repository = new OrderRepository();
            orderService_ = new OrderService(repository);

            try
            {
                orders_ = orderService_.GetAllOrders();
                ShowOrders(orders_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Ошибка загрузки товаров",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ShowOrders(List<Order> orders)
        {
            ordersListBox.DataSource = null;
            ordersListBox.DataSource = orders;
            ordersListBox.DisplayMember = "id_";
        }
    }
}
