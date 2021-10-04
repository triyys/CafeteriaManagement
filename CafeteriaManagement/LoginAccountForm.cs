using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeteriaManagement.DAO;
using CafeteriaManagement.DTO;

namespace CafeteriaManagement
{
    public partial class LoginAccountForm : Form
    {
        public LoginAccountForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = loginNameTextBox.Text;
            string passWord = loginPasswordTextBox.Text;

            if (LoginAuthentication(userName, passWord))
            {
                AccountModel loginAccount = AccountDAO.GetAccountByUserName(userName);

                TableManagerForm frm = new TableManagerForm(loginAccount);
                this.Hide();
                frm.ShowDialog();
                this.Show(); 
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        private bool LoginAuthentication(string userName, string passWord)
        {
            return AccountDAO.AuthenticationLogin(userName, passWord);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginAccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
