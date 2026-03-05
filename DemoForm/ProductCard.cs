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
            descriptionLabel.Text = product.description_;
            manufacturerLabel.Text = product.manufacturer_;
            supplierLabel.Text = product.supplier_;
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

            if (product.discount_ > 15)
            {
                this.BackColor = ColorTranslator.FromHtml("#2E8B57");
            }
            else
            {
                this.BackColor = Color.FromName("Chartreuse");
            }

            if (product.discount_ != 0)
            {
                priceLabel.Font = new Font(priceLabel.Font, FontStyle.Strikeout);
                priceLabel.ForeColor = Color.FromName("Red");

                newPriceLabel.Text = (product.price_ - (product.price_ / 100 * product.discount_)).ToString();
            }
            else
            {
                priceLabel.Font = new Font(priceLabel.Font, FontStyle.Regular);
                priceLabel.ForeColor = Color.FromName("ControlText");

                newPriceLabel.Text = "";
            }

            if (product.count_ == 0)
            {
                countLabel.ForeColor = Color.FromName("DeepSkyBlue");
                countNameLabel.ForeColor = Color.FromName("DeepSkyBlue");
            }
            else
            {
                countLabel.ForeColor = Color.FromName("ControlText");
                countNameLabel.ForeColor = Color.FromName("ControlText");
            }
        }
    }
}
