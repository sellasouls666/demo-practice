namespace DemoForm
{
    partial class OrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ordersListBox = new System.Windows.Forms.ListBox();
            this.cardOrder = new DemoForm.OrderCard();
            this.SuspendLayout();
            // 
            // ordersListBox
            // 
            this.ordersListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ordersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ordersListBox.FormattingEnabled = true;
            this.ordersListBox.ItemHeight = 20;
            this.ordersListBox.Location = new System.Drawing.Point(0, 0);
            this.ordersListBox.Name = "ordersListBox";
            this.ordersListBox.Size = new System.Drawing.Size(62, 191);
            this.ordersListBox.TabIndex = 0;
            this.ordersListBox.SelectedIndexChanged += new System.EventHandler(this.ordersListBox_SelectedIndexChanged);
            // 
            // cardOrder
            // 
            this.cardOrder.BackColor = System.Drawing.Color.Chartreuse;
            this.cardOrder.Location = new System.Drawing.Point(74, 12);
            this.cardOrder.Name = "cardOrder";
            this.cardOrder.Size = new System.Drawing.Size(488, 160);
            this.cardOrder.TabIndex = 1;
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 191);
            this.Controls.Add(this.cardOrder);
            this.Controls.Add(this.ordersListBox);
            this.Name = "OrdersForm";
            this.Text = "Заказы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ordersListBox;
        private OrderCard cardOrder;
    }
}