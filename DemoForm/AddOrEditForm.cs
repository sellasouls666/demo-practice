using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.Product;

namespace DemoForm
{
    public partial class AddOrEditForm: Form
    {
        private Product newProduct_;
        private string selectedImagePath_ = "picture.png";
        private ProductService service_;
        private int type_;
        public AddOrEditForm(ProductService service, int type, Product product)
        {
            InitializeComponent();
            service_ = service;
            type_ = type;
            newProduct_ = product;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(articulTextBox.Text))
            {
                MessageBox.Show("Поле 'Артикул' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                articulTextBox.Focus();
                return;
            }

            if (type_ == 0)
            {
                if (CheckArticul(articulTextBox.Text))
                {
                    MessageBox.Show("Уже существует товар с указанным артикулом", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    articulTextBox.Focus();
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Поле 'Название' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(unitTextBox.Text))
            {
                MessageBox.Show("Поле 'Единица измерения' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                unitTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(supplierTextBox.Text))
            {
                MessageBox.Show("Поле 'Поставщик' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                supplierTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(manufacturerTextBox.Text))
            {
                MessageBox.Show("Поле 'Производитель' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                manufacturerTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Поле 'Описание' не может быть пустым!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                descriptionTextBox.Focus();
                return;
            }

            if (type_ == 0)
            {
                Product addProduct = new Product(
                    articulTextBox.Text,
                    nameTextBox.Text,
                    unitTextBox.Text,
                    priceNumeric.Value,
                    supplierTextBox.Text,
                    manufacturerTextBox.Text,
                    categoryComboBox.Text,
                    (int)discountNumeric.Value,
                    (int)countNumeric.Value,
                    descriptionTextBox.Text,
                    selectedImagePath_
                    );
                newProduct_ = (Product)addProduct;
                DialogResult = DialogResult.OK;
            }
        }

        private void AddOrEditForm_Load(object sender, EventArgs e)
        {
            if (type_ == 0)
            {
                pictureBox.Load(selectedImagePath_);
                this.Text = "Добавление товара";
                categoryComboBox.Text = "Мужская обувь";
            }
        }

        public Product GetNewProduct()
        {
            return newProduct_;
        }

        public bool CheckArticul(string articul)
        {
            List<Product> products = service_.GetAllProducts();
            foreach (Product product in products) 
            { 
                if (product.articul_ == articul)
                {
                    return true;
                }
            }
            return false;
        }

        private void addPicButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                openFileDialog.Title = "Выберите изображение для товара";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string sourcePath = openFileDialog.FileName;

                        string fileName = Path.GetFileName(sourcePath);

                        string targetPath = Path.Combine(Application.StartupPath, fileName);

                        File.Copy(sourcePath, targetPath, true);

                        selectedImagePath_ = fileName;

                        pictureBox.Image?.Dispose(); 
                        pictureBox.Image = Image.FromFile(targetPath);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                        MessageBox.Show("Изображение успешно загружено!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
