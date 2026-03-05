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
    public partial class AuthorizeForm: Form
    {
        private UserService service_ = new UserService();
        public AuthorizeForm()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (String.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Пожалуйста, введите логин");
                return;
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, введите пароль");
                return;
            }

            User user = service_.GetUserByLogin(login);

            if (user == null)
            {
                MessageBox.Show("Пользователь с указанным логином не найден");
                return;
            }

            if (user.password_ == password)
            {
                MainForm mainForm = new MainForm(user);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Пароль неверен");
                return;
            }
        }
    }
}
