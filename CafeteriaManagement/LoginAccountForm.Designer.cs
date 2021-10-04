namespace CafeteriaManagement
{
    partial class LoginAccountForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.loginButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.loginPasswordPanel = new System.Windows.Forms.Panel();
            this.loginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginPasswordLabel = new System.Windows.Forms.Label();
            this.loginNamePanel = new System.Windows.Forms.Panel();
            this.loginNameTextBox = new System.Windows.Forms.TextBox();
            this.loginNameLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.loginPasswordPanel.SuspendLayout();
            this.loginNamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.loginButton);
            this.mainPanel.Controls.Add(this.exitButton);
            this.mainPanel.Controls.Add(this.loginPasswordPanel);
            this.mainPanel.Controls.Add(this.loginNamePanel);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(444, 152);
            this.mainPanel.TabIndex = 0;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(211, 109);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(98, 30);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Đăng nhập";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(331, 109);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(98, 30);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Thoát";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // loginPasswordPanel
            // 
            this.loginPasswordPanel.Controls.Add(this.loginPasswordTextBox);
            this.loginPasswordPanel.Controls.Add(this.loginPasswordLabel);
            this.loginPasswordPanel.Location = new System.Drawing.Point(3, 56);
            this.loginPasswordPanel.Name = "loginPasswordPanel";
            this.loginPasswordPanel.Size = new System.Drawing.Size(438, 47);
            this.loginPasswordPanel.TabIndex = 1;
            // 
            // loginPasswordTextBox
            // 
            this.loginPasswordTextBox.Location = new System.Drawing.Point(159, 14);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.loginPasswordTextBox.Size = new System.Drawing.Size(276, 20);
            this.loginPasswordTextBox.TabIndex = 2;
            this.loginPasswordTextBox.Text = "123";
            this.loginPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginPasswordLabel.Location = new System.Drawing.Point(3, 10);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(103, 24);
            this.loginPasswordLabel.TabIndex = 0;
            this.loginPasswordLabel.Text = "Mật khẩu:";
            // 
            // loginNamePanel
            // 
            this.loginNamePanel.Controls.Add(this.loginNameTextBox);
            this.loginNamePanel.Controls.Add(this.loginNameLabel);
            this.loginNamePanel.Location = new System.Drawing.Point(3, 3);
            this.loginNamePanel.Name = "loginNamePanel";
            this.loginNamePanel.Size = new System.Drawing.Size(438, 47);
            this.loginNamePanel.TabIndex = 0;
            // 
            // loginNameTextBox
            // 
            this.loginNameTextBox.Location = new System.Drawing.Point(159, 14);
            this.loginNameTextBox.Name = "loginNameTextBox";
            this.loginNameTextBox.Size = new System.Drawing.Size(276, 20);
            this.loginNameTextBox.TabIndex = 1;
            this.loginNameTextBox.Text = "ngoductri";
            // 
            // loginNameLabel
            // 
            this.loginNameLabel.AutoSize = true;
            this.loginNameLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginNameLabel.Location = new System.Drawing.Point(3, 10);
            this.loginNameLabel.Name = "loginNameLabel";
            this.loginNameLabel.Size = new System.Drawing.Size(150, 24);
            this.loginNameLabel.TabIndex = 0;
            this.loginNameLabel.Text = "Tên đăng nhập:";
            // 
            // LoginAccountForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(468, 176);
            this.Controls.Add(this.mainPanel);
            this.Name = "LoginAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginAccountForm_FormClosing);
            this.mainPanel.ResumeLayout(false);
            this.loginPasswordPanel.ResumeLayout(false);
            this.loginPasswordPanel.PerformLayout();
            this.loginNamePanel.ResumeLayout(false);
            this.loginNamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel loginNamePanel;
        private System.Windows.Forms.Label loginNameLabel;
        private System.Windows.Forms.Panel loginPasswordPanel;
        private System.Windows.Forms.Label loginPasswordLabel;
        private System.Windows.Forms.TextBox loginPasswordTextBox;
        private System.Windows.Forms.TextBox loginNameTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button exitButton;
    }
}

