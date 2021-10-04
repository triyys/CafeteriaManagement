namespace CafeteriaManagement
{
    partial class TableManagerForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewPanel = new System.Windows.Forms.Panel();
            this.mainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkOutPanel = new System.Windows.Forms.Panel();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.switchTableComboBox = new System.Windows.Forms.ComboBox();
            this.switchTableButton = new System.Windows.Forms.Button();
            this.discountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkOutButton = new System.Windows.Forms.Button();
            this.addFoodPanel = new System.Windows.Forms.Panel();
            this.foodCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.addFoodButton = new System.Windows.Forms.Button();
            this.foodComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.tableFLPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainMenuStrip.SuspendLayout();
            this.listViewPanel.SuspendLayout();
            this.checkOutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountNumericUpDown)).BeginInit();
            this.addFoodPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinToolStripMenuItem,
            this.chứcNăngToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.thôngTinToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thanhToánToolStripMenuItem,
            this.thêmMónToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // thanhToánToolStripMenuItem
            // 
            this.thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            this.thanhToánToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.thanhToánToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.thanhToánToolStripMenuItem.Text = "Thanh toán";
            // 
            // thêmMónToolStripMenuItem
            // 
            this.thêmMónToolStripMenuItem.Name = "thêmMónToolStripMenuItem";
            this.thêmMónToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.thêmMónToolStripMenuItem.Text = "Thêm món";
            // 
            // listViewPanel
            // 
            this.listViewPanel.Controls.Add(this.mainListView);
            this.listViewPanel.Location = new System.Drawing.Point(435, 94);
            this.listViewPanel.Name = "listViewPanel";
            this.listViewPanel.Size = new System.Drawing.Size(353, 277);
            this.listViewPanel.TabIndex = 2;
            // 
            // mainListView
            // 
            this.mainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.mainListView.GridLines = true;
            this.mainListView.Location = new System.Drawing.Point(3, 3);
            this.mainListView.Name = "mainListView";
            this.mainListView.Size = new System.Drawing.Size(347, 271);
            this.mainListView.TabIndex = 0;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            this.mainListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 136;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 85;
            // 
            // checkOutPanel
            // 
            this.checkOutPanel.Controls.Add(this.totalPriceTextBox);
            this.checkOutPanel.Controls.Add(this.switchTableComboBox);
            this.checkOutPanel.Controls.Add(this.switchTableButton);
            this.checkOutPanel.Controls.Add(this.discountNumericUpDown);
            this.checkOutPanel.Controls.Add(this.checkOutButton);
            this.checkOutPanel.Location = new System.Drawing.Point(435, 374);
            this.checkOutPanel.Name = "checkOutPanel";
            this.checkOutPanel.Size = new System.Drawing.Size(353, 64);
            this.checkOutPanel.TabIndex = 3;
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Location = new System.Drawing.Point(169, 9);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.ReadOnly = true;
            this.totalPriceTextBox.Size = new System.Drawing.Size(98, 20);
            this.totalPriceTextBox.TabIndex = 8;
            this.totalPriceTextBox.Text = "0";
            this.totalPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // switchTableComboBox
            // 
            this.switchTableComboBox.FormattingEnabled = true;
            this.switchTableComboBox.Location = new System.Drawing.Point(3, 40);
            this.switchTableComboBox.Name = "switchTableComboBox";
            this.switchTableComboBox.Size = new System.Drawing.Size(77, 21);
            this.switchTableComboBox.TabIndex = 7;
            // 
            // switchTableButton
            // 
            this.switchTableButton.Location = new System.Drawing.Point(3, 3);
            this.switchTableButton.Name = "switchTableButton";
            this.switchTableButton.Size = new System.Drawing.Size(77, 31);
            this.switchTableButton.TabIndex = 6;
            this.switchTableButton.Text = "Chuyển bàn";
            this.switchTableButton.UseVisualStyleBackColor = true;
            this.switchTableButton.Click += new System.EventHandler(this.switchTableButton_Click);
            // 
            // discountNumericUpDown
            // 
            this.discountNumericUpDown.Location = new System.Drawing.Point(169, 35);
            this.discountNumericUpDown.Name = "discountNumericUpDown";
            this.discountNumericUpDown.Size = new System.Drawing.Size(98, 20);
            this.discountNumericUpDown.TabIndex = 5;
            this.discountNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkOutButton
            // 
            this.checkOutButton.Location = new System.Drawing.Point(273, 3);
            this.checkOutButton.Name = "checkOutButton";
            this.checkOutButton.Size = new System.Drawing.Size(77, 57);
            this.checkOutButton.TabIndex = 3;
            this.checkOutButton.Text = "Thanh toán";
            this.checkOutButton.UseVisualStyleBackColor = true;
            this.checkOutButton.Click += new System.EventHandler(this.checkOutButton_Click);
            // 
            // addFoodPanel
            // 
            this.addFoodPanel.Controls.Add(this.foodCountNumericUpDown);
            this.addFoodPanel.Controls.Add(this.addFoodButton);
            this.addFoodPanel.Controls.Add(this.foodComboBox);
            this.addFoodPanel.Controls.Add(this.categoryComboBox);
            this.addFoodPanel.Location = new System.Drawing.Point(435, 27);
            this.addFoodPanel.Name = "addFoodPanel";
            this.addFoodPanel.Size = new System.Drawing.Size(353, 64);
            this.addFoodPanel.TabIndex = 4;
            // 
            // foodCountNumericUpDown
            // 
            this.foodCountNumericUpDown.Location = new System.Drawing.Point(307, 24);
            this.foodCountNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.foodCountNumericUpDown.Name = "foodCountNumericUpDown";
            this.foodCountNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.foodCountNumericUpDown.TabIndex = 3;
            this.foodCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // addFoodButton
            // 
            this.addFoodButton.Location = new System.Drawing.Point(224, 4);
            this.addFoodButton.Name = "addFoodButton";
            this.addFoodButton.Size = new System.Drawing.Size(77, 57);
            this.addFoodButton.TabIndex = 2;
            this.addFoodButton.Text = "Thêm món";
            this.addFoodButton.UseVisualStyleBackColor = true;
            this.addFoodButton.Click += new System.EventHandler(this.addFoodButton_Click);
            // 
            // foodComboBox
            // 
            this.foodComboBox.FormattingEnabled = true;
            this.foodComboBox.Location = new System.Drawing.Point(3, 40);
            this.foodComboBox.Name = "foodComboBox";
            this.foodComboBox.Size = new System.Drawing.Size(215, 21);
            this.foodComboBox.TabIndex = 1;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(3, 4);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(215, 21);
            this.categoryComboBox.TabIndex = 0;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // tableFLPanel
            // 
            this.tableFLPanel.AutoScroll = true;
            this.tableFLPanel.Location = new System.Drawing.Point(12, 27);
            this.tableFLPanel.Name = "tableFLPanel";
            this.tableFLPanel.Size = new System.Drawing.Size(417, 411);
            this.tableFLPanel.TabIndex = 5;
            // 
            // TableManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableFLPanel);
            this.Controls.Add(this.addFoodPanel);
            this.Controls.Add(this.checkOutPanel);
            this.Controls.Add(this.listViewPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "TableManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lí quán cafe";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.listViewPanel.ResumeLayout(false);
            this.checkOutPanel.ResumeLayout(false);
            this.checkOutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountNumericUpDown)).EndInit();
            this.addFoodPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.foodCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel listViewPanel;
        private System.Windows.Forms.ListView mainListView;
        private System.Windows.Forms.Panel checkOutPanel;
        private System.Windows.Forms.Panel addFoodPanel;
        private System.Windows.Forms.ComboBox foodComboBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.NumericUpDown foodCountNumericUpDown;
        private System.Windows.Forms.Button addFoodButton;
        private System.Windows.Forms.Button checkOutButton;
        private System.Windows.Forms.FlowLayoutPanel tableFLPanel;
        private System.Windows.Forms.NumericUpDown discountNumericUpDown;
        private System.Windows.Forms.ComboBox switchTableComboBox;
        private System.Windows.Forms.Button switchTableButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmMónToolStripMenuItem;
    }
}