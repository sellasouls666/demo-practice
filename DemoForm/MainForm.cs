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
        private User currentUser_ = null;
        public MainForm(User user)
        {
            currentUser_ = user;
            InitializeComponent();

            var repository = new ProductRepository();
            service_ = new ProductService(repository);

            try
            {
                products_ = service_.GetAllProducts();
                ShowProducts(products_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Ошибка загрузки товаров",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ShowProducts(List<Product> products)
        {
            ProductsListBox.DataSource = null;
            ProductsListBox.DataSource = products;
            ProductsListBox.DisplayMember = "articul_";
        }

        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ProductsListBox.SelectedItem;
            if (item == null)
            {
                return;
            }

            var product = item as Product;
            if (product == null)
            {
                return;
            }

            cardProduct.ShowProductInfo(product);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (currentUser_ != null)
            {
                userFioLabel.Text = currentUser_.fio_;
            }
            if (currentUser_ == null)
            {
                userFioLabel.Text = "Гость";
            }
        }

        private bool IsNotSettedSearch()
        {
            return string.IsNullOrEmpty(searchTextBox.Text);
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (IsNotSettedSearch())
            {
                ShowProducts(products_);
                return;
            }

            string searchingText = searchTextBox.Text; // условие поиска

            List<Product> resultProducts = new List<Product>();
            foreach (Product product in products_)
            {
                if (string.IsNullOrEmpty(searchingText)
                        || product.articul_.ToLower().Contains(searchingText.ToLower())
                        || product.name_.ToLower().Contains(searchingText.ToLower())
                        || product.unit_.ToLower().Contains(searchingText.ToLower())
                        || product.supplier_.ToLower().Contains(searchingText.ToLower())
                        || product.manufacturer_.ToLower().Contains(searchingText.ToLower())
                        || product.category_.ToLower().Contains(searchingText.ToLower())
                        || product.description_.ToLower().Contains(searchingText.ToLower()))
                {
                    resultProducts.Add(product);
                }
            }

            ShowProducts(resultProducts);
        }
    }
}
