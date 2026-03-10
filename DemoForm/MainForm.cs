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
using System.Reflection;
using DemoLib.Order;

namespace DemoForm
{
    public partial class MainForm: Form
    {
        private ProductService service_;
        private List<Product> products_ = new List<Product>();
        private User currentUser_ = null;
        private OrderService orderService_;
        public MainForm(User user)
        {
            currentUser_ = user;
            InitializeComponent();

            var repository = new ProductRepository();
            service_ = new ProductService(repository);

            var orderRepository = new OrderRepository();
            orderService_ = new OrderService(orderRepository);

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
            CheckRole();

            supplierComboBox.DataSource = service_.GetAllSuppliers();
            logoPicBox.Load("icon.png");
        }

        private bool IsNotSettedSearchAndFilter()
        {
            return string.IsNullOrEmpty(searchTextBox.Text)
                && supplierComboBox.Text == "Все поставщики";
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (IsNotSettedSearchAndFilter())
            {
                ShowProducts(products_);
                return;
            }

            List<Product> resultProducts = SearchAndFilter(searchTextBox.Text);
            ShowProducts(resultProducts);
        }

        private List<Product> SearchAndFilter(string searchingText)
        {
            List<Product> resultProducts = new List<Product>();

            foreach (Product product in products_)
            {
                // Проверяем, соответствует ли товар критериям поиска
                bool matchesSearch = string.IsNullOrEmpty(searchingText) ||
                                    product.articul_.ToLower().Contains(searchingText.ToLower()) ||
                                    product.name_.ToLower().Contains(searchingText.ToLower()) ||
                                    product.unit_.ToLower().Contains(searchingText.ToLower()) ||
                                    product.supplier_.ToLower().Contains(searchingText.ToLower()) ||
                                    product.manufacturer_.ToLower().Contains(searchingText.ToLower()) ||
                                    product.category_.ToLower().Contains(searchingText.ToLower()) ||
                                    product.description_.ToLower().Contains(searchingText.ToLower());

                // Проверяем, соответствует ли товар фильтру по поставщику
                bool matchesSupplier = supplierComboBox.Text == "Все поставщики" ||
                                      product.supplier_ == supplierComboBox.Text;

                // Товар добавляется, если выполняются оба условия
                if (matchesSearch && matchesSupplier)
                {
                    resultProducts.Add(product);
                }
            }

            return resultProducts;
        }

        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsNotSettedSearchAndFilter())
            {
                ShowProducts(products_);
                return;
            }

            List<Product> resultProducts = SearchAndFilter(searchTextBox.Text);
            ShowProducts(resultProducts);
        }

        private void supplierComboBox_TextChanged(object sender, EventArgs e)
        {
            if (IsNotSettedSearchAndFilter())
            {
                ShowProducts(products_);
                return;
            }

            List<Product> resultProducts = SearchAndFilter(searchTextBox.Text);
            ShowProducts(resultProducts);
        }

        private void CheckRole()
        {
            if (currentUser_ != null)
            {
                userFioLabel.Text = currentUser_.fio_;
            }
            if (currentUser_ == null)
            {
                userFioLabel.Text = "Гость";
            }
            if (currentUser_ == null || currentUser_.role_ == "Авторизированный клиент")
            {
                searchTextBox.Enabled = false;
                supplierComboBox.Enabled = false;
                sortIncButton.Enabled = false;
                sortDecButton.Enabled = false;
            }
            if (currentUser_ == null || currentUser_.role_ == "Авторизированный клиент" || currentUser_.role_ == "Менеджер")
            {
                addButton.Enabled = false;
            }    
        }

        private void sortIncButton_Click(object sender, EventArgs e)
        {
            products_ = products_.OrderBy(p => p.count_).ToList();
            List<Product> resultProducts = SearchAndFilter(searchTextBox.Text);
            ShowProducts(resultProducts);
        }

        private void sortDecButton_Click(object sender, EventArgs e)
        {
            products_ = products_.OrderByDescending(p => p.count_).ToList();
            List<Product> resultProducts = SearchAndFilter(searchTextBox.Text);
            ShowProducts(resultProducts);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddOrEditForm addForm = new AddOrEditForm(service_, 0, null);
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    service_.AddProduct(addForm.GetNewProduct());
                    products_.Clear();
                    products_ = service_.GetAllProducts();
                    ShowProducts(products_);
                    if (ProductsListBox.Items.Count > 0)
                        ProductsListBox.SelectedIndex = 0;
                    searchTextBox.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Ошибка добавления товара",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void cardProduct_DoubleClick(object sender, EventArgs e)
        {
            if (currentUser_ == null || currentUser_.role_ != "Администратор")
            {
                return;
            }    
            var item = ProductsListBox.SelectedItem;
            if (item == null) return;

            var client = item as Product;
            if (client == null) return;

            AddOrEditForm editForm = new AddOrEditForm(service_, 1, client);
            DialogResult result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    service_.EditProduct(editForm.GetNewProduct());
                    products_.Clear();
                    products_ = service_.GetAllProducts();
                    ShowProducts(products_);
                    searchTextBox.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Ошибка редактирования товара",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var item = ProductsListBox.SelectedItem;
            if (item == null) return;

            var product = item as Product;
            if (product == null) return;

            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить товар {product.articul_}?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (!orderService_.CheckArticul(product))
                {
                    try
                    {
                        service_.DeleteProduct(product);
                        products_.Clear();
                        products_ = service_.GetAllProducts();
                        ShowProducts(products_);
                        if (ProductsListBox.Items.Count > 0)
                            ProductsListBox.SelectedIndex = 0;
                        searchTextBox.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,
                                        "Ошибка удаления товара",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Вы не можете удалить товар, который заказан",
                        "Ошибка удаления товара",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
