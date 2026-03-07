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
            }
        }

        public Product GetNewProduct()
        {
            return newProduct_;
        }
    }
}
