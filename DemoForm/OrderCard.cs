using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.Order;

namespace DemoForm
{
    public partial class OrderCard: UserControl
    {
        private Order order_;
        private string address_;
        public OrderCard()
        {
            InitializeComponent();
        }

        public void ShowOrderInfo(Order order, string address)
        {
            order_ = order;
            address_ = address;

            addressLabel.Text = address;
            delieveryDateLabel.Text = order.delieveryDate_.ToString();
            idLabel.Text = order.id_.ToString();
            orderDateLabel.Text = order.orderDate_.ToShortDateString();
            statusLabel.Text = order.status_;
        }
    }
}
