using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLib.Product;
using DemoLib.View;

namespace DemoForm
{
    public partial class ProductCard: UserControl, IProductCard
    {
        private Product product_;
        public ProductCard()
        {
            InitializeComponent();
        }

        public void ShowProductInfo(Product product)
        {
            product_ = product;

            categoryLabel.Text = product.category_;
            nameLabel.Text = product.name_;
            descriptionTextBox.Text = product.description_;
            manufacturerTextBox.Text = product.manufacturer_;
            supplierTextBox.Text = product.supplier_;
            priceLabel.Text = product.price_.ToString();
            unitLabel.Text = product.unit_;
            countLabel.Text = product.count_.ToString();
            discountLabel.Text = product.discount_.ToString();
            if (!string.IsNullOrEmpty(product.pic_))
            {
                picBox.Load(product.pic_);
            }
            else
            {
                picBox.Load("picture.png");
            }
        }
    }
}
