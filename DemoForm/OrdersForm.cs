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
using DemoLib.Pickup;

namespace DemoForm
{
    public partial class OrdersForm: Form
    {
        private OrderService orderService_;
        private List<Order> orders_ = new List<Order>();
        private User currentUser_ = null;
        private PickupService pickupService_;
        public OrdersForm(User user)
        {
            InitializeComponent();
            currentUser_ = user;

            var repository = new OrderRepository();
            orderService_ = new OrderService(repository);

            var pickupRepository = new PickupRepository();
            pickupService_ = new PickupService(pickupRepository);

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

        private void ordersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ordersListBox.SelectedItem;
            if (item == null)
            {
                return;
            }

            var order = item as Order;
            if (order == null)
            {
                return;
            }

            string address = pickupService_.GetPickupAddress(order.idPickup_);

            cardOrder.ShowOrderInfo(order, address);
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            AddOrEditOrderForm addForm = new AddOrEditOrderForm(orderService_, 0, null, pickupService_);
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    orderService_.AddOrder(addForm.GetNewOrder());
                    orders_.Clear();
                    orders_ = orderService_.GetAllOrders();
                    ShowOrders(orders_);
                    if (ordersListBox.Items.Count > 0)
                        ordersListBox.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Ошибка добавления заказа",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
