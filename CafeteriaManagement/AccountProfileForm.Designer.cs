namespace CafeteriaManagement
{
    partial class AccountProfileForm
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
            this.loginNamePanel = new System.Windows.Forms.Panel();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.loginNameLabel = new System.Windows.Forms.Label();
            this.displayNamePanel = new System.Windows.Forms.Panel();
            this.displayNameTextBox = new System.Windows.Forms.TextBox();
            this.displayNameLabel = new System.Windows.Forms.Label();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.newPasswordPanel = new System.Windows.Forms.Panel();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.reenterNewPasswordPanel = new System.Windows.Forms.Panel();
            this.reenterNewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.reenterNewPasswordLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.loginNamePanel.SuspendLayout();
            this.displayNamePanel.SuspendLayout();
            this.passwordPanel.SuspendLayout();
            this.newPasswordPanel.SuspendLayout();
            this.reenterNewPasswordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginNamePanel
            // 
            this.loginNamePanel.Controls.Add(this.userNameTextBox);
            this.loginNamePanel.Controls.Add(this.loginNameLabel);
            this.loginNamePanel.Location = new System.Drawing.Point(12, 12);
            this.loginNamePanel.Name = "loginNamePanel";
            this.loginNamePanel.Size = new System.Drawing.Size(438, 47);
            this.loginNamePanel.TabIndex = 2;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(159, 14);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.ReadOnly = true;
            this.userNameTextBox.Size = new System.Drawing.Size(276, 20);
            this.userNameTextBox.TabIndex = 1;
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
            // displayNamePanel
            // 
            this.displayNamePanel.Controls.Add(this.displayNameTextBox);
            this.displayNamePanel.Controls.Add(this.displayNameLabel);
            this.displayNamePanel.Location = new System.Drawing.Point(12, 65);
            this.displayNamePanel.Name = "displayNamePanel";
            this.displayNamePanel.Size = new System.Drawing.Size(438, 47);
            this.displayNamePanel.TabIndex = 3;
            // 
            // displayNameTextBox
            // 
            this.displayNameTextBox.Location = new System.Drawing.Point(159, 14);
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.Size = new System.Drawing.Size(276, 20);
            this.displayNameTextBox.TabIndex = 1;
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.AutoSize = true;
            this.displayNameLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayNameLabel.Location = new System.Drawing.Point(3, 10);
            this.displayNameLabel.Name = "displayNameLabel";
            this.displayNameLabel.Size = new System.Drawing.Size(121, 24);
            this.displayNameLabel.TabIndex = 0;
            this.displayNameLabel.Text = "Tên hiển thị:";
            // 
            // passwordPanel
            // 
            this.passwordPanel.Controls.Add(this.passwordTextBox);
            this.passwordPanel.Controls.Add(this.passwordLabel);
            this.passwordPanel.Location = new System.Drawing.Point(12, 118);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(438, 47);
            this.passwordPanel.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(159, 14);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(276, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(3, 10);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(103, 24);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "Mật khẩu:";
            // 
            // newPasswordPanel
            // 
            this.newPasswordPanel.Controls.Add(this.newPasswordTextBox);
            this.newPasswordPanel.Controls.Add(this.newPasswordLabel);
            this.newPasswordPanel.Location = new System.Drawing.Point(12, 171);
            this.newPasswordPanel.Name = "newPasswordPanel";
            this.newPasswordPanel.Size = new System.Drawing.Size(438, 47);
            this.newPasswordPanel.TabIndex = 5;
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Location = new System.Drawing.Point(159, 14);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(276, 20);
            this.newPasswordTextBox.TabIndex = 1;
            this.newPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordLabel.Location = new System.Drawing.Point(3, 10);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(142, 24);
            this.newPasswordLabel.TabIndex = 0;
            this.newPasswordLabel.Text = "Mật khẩu mới:";
            // 
            // reenterNewPasswordPanel
            // 
            this.reenterNewPasswordPanel.Controls.Add(this.reenterNewPasswordTextBox);
            this.reenterNewPasswordPanel.Controls.Add(this.reenterNewPasswordLabel);
            this.reenterNewPasswordPanel.Location = new System.Drawing.Point(12, 224);
            this.reenterNewPasswordPanel.Name = "reenterNewPasswordPanel";
            this.reenterNewPasswordPanel.Size = new System.Drawing.Size(438, 47);
            this.reenterNewPasswordPanel.TabIndex = 6;
            // 
            // reenterNewPasswordTextBox
            // 
            this.reenterNewPasswordTextBox.Location = new System.Drawing.Point(159, 14);
            this.reenterNewPasswordTextBox.Name = "reenterNewPasswordTextBox";
            this.reenterNewPasswordTextBox.Size = new System.Drawing.Size(276, 20);
            this.reenterNewPasswordTextBox.TabIndex = 1;
            this.reenterNewPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // reenterNewPasswordLabel
            // 
            this.reenterNewPasswordLabel.AutoSize = true;
            this.reenterNewPasswordLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reenterNewPasswordLabel.Location = new System.Drawing.Point(3, 10);
            this.reenterNewPasswordLabel.Name = "reenterNewPasswordLabel";
            this.reenterNewPasswordLabel.Size = new System.Drawing.Size(91, 24);
            this.reenterNewPasswordLabel.TabIndex = 0;
            this.reenterNewPasswordLabel.Text = "Nhập lại:";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(282, 278);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Cập nhật";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(363, 278);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Thoát";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // AccountProfileForm
            // 
            this.AcceptButton = this.updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(459, 313);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.reenterNewPasswordPanel);
            this.Controls.Add(this.newPasswordPanel);
            this.Controls.Add(this.passwordPanel);
            this.Controls.Add(this.displayNamePanel);
            this.Controls.Add(this.loginNamePanel);
            this.Name = "AccountProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Thông tin cá nhân";
            this.loginNamePanel.ResumeLayout(false);
            this.loginNamePanel.PerformLayout();
            this.displayNamePanel.ResumeLayout(false);
            this.displayNamePanel.PerformLayout();
            this.passwordPanel.ResumeLayout(false);
            this.passwordPanel.PerformLayout();
            this.newPasswordPanel.ResumeLayout(false);
            this.newPasswordPanel.PerformLayout();
            this.reenterNewPasswordPanel.ResumeLayout(false);
            this.reenterNewPasswordPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginNamePanel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label loginNameLabel;
        private System.Windows.Forms.Panel displayNamePanel;
        private System.Windows.Forms.TextBox displayNameTextBox;
        private System.Windows.Forms.Label displayNameLabel;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Panel newPasswordPanel;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.Panel reenterNewPasswordPanel;
        private System.Windows.Forms.TextBox reenterNewPasswordTextBox;
        private System.Windows.Forms.Label reenterNewPasswordLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button exitButton;
    }
}