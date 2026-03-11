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
            this.sortDecButton = new System.Windows.Forms.Button();
            this.logoPicBox = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cardProduct = new DemoForm.ProductCard();
            this.deleteButton = new System.Windows.Forms.Button();
            this.ordersButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).BeginInit();
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
            this.ProductsListBox.Size = new System.Drawing.Size(112, 386);
            this.ProductsListBox.TabIndex = 0;
            this.ProductsListBox.SelectedIndexChanged += new System.EventHandler(this.ProductsListBox_SelectedIndexChanged);
            // 
            // userFioLabel
            // 
            this.userFioLabel.AutoSize = true;
            this.userFioLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.userFioLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userFioLabel.Location = new System.Drawing.Point(1262, 0);
            this.userFioLabel.Name = "userFioLabel";
            this.userFioLabel.Size = new System.Drawing.Size(45, 19);
            this.userFioLabel.TabIndex = 2;
            this.userFioLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(116, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Поиск:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.Location = new System.Drawing.Point(176, 20);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(132, 26);
            this.searchTextBox.TabIndex = 4;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(325, 21);
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
            this.supplierComboBox.Location = new System.Drawing.Point(494, 20);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(149, 27);
            this.supplierComboBox.TabIndex = 6;
            this.supplierComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);
            this.supplierComboBox.TextChanged += new System.EventHandler(this.supplierComboBox_TextChanged);
            // 
            // sortIncButton
            // 
            this.sortIncButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.sortIncButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortIncButton.Location = new System.Drawing.Point(668, 9);
            this.sortIncButton.Name = "sortIncButton";
            this.sortIncButton.Size = new System.Drawing.Size(192, 45);
            this.sortIncButton.TabIndex = 7;
            this.sortIncButton.Text = "Отсортировать по возрастанию количества на складе";
            this.sortIncButton.UseVisualStyleBackColor = false;
            this.sortIncButton.Click += new System.EventHandler(this.sortIncButton_Click);
            // 
            // sortDecButton
            // 
            this.sortDecButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.sortDecButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortDecButton.Location = new System.Drawing.Point(882, 9);
            this.sortDecButton.Name = "sortDecButton";
            this.sortDecButton.Size = new System.Drawing.Size(192, 45);
            this.sortDecButton.TabIndex = 8;
            this.sortDecButton.Text = "Отсортировать по убыванию количества на складе";
            this.sortDecButton.UseVisualStyleBackColor = false;
            this.sortDecButton.Click += new System.EventHandler(this.sortDecButton_Click);
            // 
            // logoPicBox
            // 
            this.logoPicBox.Location = new System.Drawing.Point(1133, 22);
            this.logoPicBox.Name = "logoPicBox";
            this.logoPicBox.Size = new System.Drawing.Size(162, 139);
            this.logoPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPicBox.TabIndex = 9;
            this.logoPicBox.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.addButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(1133, 180);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(162, 36);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Добавить товар";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cardProduct
            // 
            this.cardProduct.BackColor = System.Drawing.Color.Chartreuse;
            this.cardProduct.Location = new System.Drawing.Point(118, 64);
            this.cardProduct.Name = "cardProduct";
            this.cardProduct.Size = new System.Drawing.Size(1000, 309);
            this.cardProduct.TabIndex = 1;
            this.cardProduct.DoubleClick += new System.EventHandler(this.cardProduct_DoubleClick);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.deleteButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(1133, 222);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(162, 36);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Удалить товар";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // ordersButton
            // 
            this.ordersButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ordersButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ordersButton.Location = new System.Drawing.Point(1133, 268);
            this.ordersButton.Name = "ordersButton";
            this.ordersButton.Size = new System.Drawing.Size(162, 36);
            this.ordersButton.TabIndex = 12;
            this.ordersButton.Text = "Заказы";
            this.ordersButton.UseVisualStyleBackColor = false;
            this.ordersButton.Click += new System.EventHandler(this.ordersButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 386);
            this.Controls.Add(this.ordersButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.logoPicBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).EndInit();
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
        private System.Windows.Forms.PictureBox logoPicBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button ordersButton;
    }
}

