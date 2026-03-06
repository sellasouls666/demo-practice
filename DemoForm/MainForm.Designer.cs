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
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.sortIncButton = new System.Windows.Forms.Button();
            this.cardProduct = new DemoForm.ProductCard();
            this.sortDecButton = new System.Windows.Forms.Button();
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
            this.ProductsListBox.Size = new System.Drawing.Size(112, 404);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(116, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Поиск:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.Location = new System.Drawing.Point(176, 38);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(132, 26);
            this.searchTextBox.TabIndex = 4;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(325, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите поставщика:";
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(494, 38);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(149, 27);
            this.supplierComboBox.TabIndex = 6;
            this.supplierComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);
            this.supplierComboBox.TextChanged += new System.EventHandler(this.supplierComboBox_TextChanged);
            // 
            // sortIncButton
            // 
            this.sortIncButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortIncButton.Location = new System.Drawing.Point(668, 27);
            this.sortIncButton.Name = "sortIncButton";
            this.sortIncButton.Size = new System.Drawing.Size(192, 45);
            this.sortIncButton.TabIndex = 7;
            this.sortIncButton.Text = "Отсортировать по возрастанию количества на складе";
            this.sortIncButton.UseVisualStyleBackColor = true;
            this.sortIncButton.Click += new System.EventHandler(this.sortIncButton_Click);
            // 
            // cardProduct
            // 
            this.cardProduct.BackColor = System.Drawing.Color.Chartreuse;
            this.cardProduct.Location = new System.Drawing.Point(118, 78);
            this.cardProduct.Name = "cardProduct";
            this.cardProduct.Size = new System.Drawing.Size(1000, 309);
            this.cardProduct.TabIndex = 1;
            // 
            // sortDecButton
            // 
            this.sortDecButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortDecButton.Location = new System.Drawing.Point(882, 27);
            this.sortDecButton.Name = "sortDecButton";
            this.sortDecButton.Size = new System.Drawing.Size(192, 45);
            this.sortDecButton.TabIndex = 8;
            this.sortDecButton.Text = "Отсортировать по убыванию количества на складе";
            this.sortDecButton.UseVisualStyleBackColor = true;
            this.sortDecButton.Click += new System.EventHandler(this.sortDecButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 404);
            this.Controls.Add(this.sortDecButton);
            this.Controls.Add(this.sortIncButton);
            this.Controls.Add(this.supplierComboBox);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox supplierComboBox;
        private System.Windows.Forms.Button sortIncButton;
        private System.Windows.Forms.Button sortDecButton;
    }
}

