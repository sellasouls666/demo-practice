using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.User;

namespace DemoForm
{
    public partial class AuthorizeForm: Form
    {
        private UserService service_ = new UserService();
        public AuthorizeForm()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string login = loginBox.Text;
            string password = passwordTextBox.Text;

            if (String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, введите пароль");
                return;
            }

            User user = service_.GetUserByLogin(login);

            if (user.password_ == password)
            {
                MainForm mainForm = new MainForm(user);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пароль неверен");
                return;
            }
        }

        private void AuthorizeForm_Load(object sender, EventArgs e)
        {
            loginBox.DataSource = service_.GetUsersLogins();
        }

        private void guestButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(null);
            mainForm.Show();
            this.Hide();
        }
    }
}
