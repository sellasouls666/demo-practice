namespace DemoForm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.userFioLabel = new System.Windows.Forms.Label();
            this.cardProduct = new DemoForm.ProductCard();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProductsListBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 19;
            this.ProductsListBox.Location = new System.Drawing.Point(0, 0);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(112, 373);
            this.ProductsListBox.TabIndex = 0;
            this.ProductsListBox.SelectedIndexChanged += new System.EventHandler(this.ProductsListBox_SelectedIndexChanged);
            // 
            // userFioLabel
            // 
            this.userFioLabel.AutoSize = true;
            this.userFioLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.userFioLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userFioLabel.Location = new System.Drawing.Point(1086, 0);
            this.userFioLabel.Name = "userFioLabel";
            this.userFioLabel.Size = new System.Drawing.Size(45, 19);
            this.userFioLabel.TabIndex = 2;
            this.userFioLabel.Text = "label1";
            // 
            // cardProduct
            // 
            this.cardProduct.BackColor = System.Drawing.Color.Chartreuse;
            this.cardProduct.Location = new System.Drawing.Point(118, 32);
            this.cardProduct.Name = "cardProduct";
            this.cardProduct.Size = new System.Drawing.Size(1000, 329);
            this.cardProduct.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(112, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Поиск:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.Location = new System.Drawing.Point(172, -1);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(132, 26);
            this.searchTextBox.TabIndex = 4;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 373);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userFioLabel);
            this.Controls.Add(this.cardProduct);
            this.Controls.Add(this.ProductsListBox);
            this.Name = "MainForm";
            this.Text = "Товары";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ProductsListBox;
        private ProductCard cardProduct;
        private System.Windows.Forms.Label userFioLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}

