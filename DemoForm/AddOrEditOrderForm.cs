using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.Order;
using DemoLib.Pickup;
using DemoLib.Product;

namespace DemoForm
{
    public partial class AddOrEditOrderForm: Form
    {
        private Order newOrder_;
        private OrderService orderService_;
        private int type_;
        private PickupService pickupService_;
        public AddOrEditOrderForm(OrderService orderService, int type, Order order, PickupService pickupService)
        {
            InitializeComponent();
            orderService_ = orderService;
            type_ = type;
            newOrder_ = order;
            pickupService_ = pickupService;
        }

        private void cancelOrderButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddOrEditOrderForm_Load(object sender, EventArgs e)
        {
            addressComboBox.DataSource = null;
            addressComboBox.DataSource = pickupService_.GetAllPickups();
            addressComboBox.DisplayMember = "address_";
            if (type_ == 0)
            {
                this.Text = "Добавление заказа";
                idTextBox.Value = orderService_.GenerateNextId();
                statusComboBox.Text = "Новый";
            }
        }

        private void okOrderButton_Click(object sender, EventArgs e)
        {
            if (type_ == 0)
            {
                Order addOrder = new Order();
                addOrder.id_ = (int)idTextBox.Value;
                addOrder.status_ = statusComboBox.Text;
                addOrder.idPickup_ = pickupService_.GetPickupId(addressComboBox.Text);
                addOrder.orderDate_ = orderDateTimePicker.Value;
                addOrder.delieveryDate_ = dateDelieveryTimePicker.Value;
                newOrder_ = (Order)addOrder;
                DialogResult = DialogResult.OK;
            }
        }

        public Order GetNewOrder()
        {
            return newOrder_;
        }
    }
}
