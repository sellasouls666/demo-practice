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

namespace DemoForm
{
    public partial class AddOrEditOrderForm: Form
    {
        private Order newOrder_;
        private OrderService orderService_;
        private int type_;
        public AddOrEditOrderForm(OrderService orderService, int type, Order order)
        {
            InitializeComponent();
            orderService_ = orderService;
            type_ = type;
            newOrder_ = order;
        }

        private void cancelOrderButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddOrEditOrderForm_Load(object sender, EventArgs e)
        {
            if (type_ == 0)
            {
                this.Text = "Добавление заказа";
            }
        }
    }
}
