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
    public partial class MainForm: Form
    {
        private ProductService service_;
        private List<Product> products_ = new List<Product>();
        public MainForm()
        {
            InitializeComponent();

            var repository = new ProductRepository();
            service_ = new ProductService(repository);

            try
            {
                products_ = service_.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Ошибка загрузки товаров",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
