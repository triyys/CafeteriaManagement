using CafeteriaManagement.DAO;
using CafeteriaManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeteriaManagement
{
    public partial class AccountProfileForm : Form
    {
        private AccountModel userAccount;

        public AccountProfileForm(AccountModel acc)
        {
            InitializeComponent();

            userAccount = acc;
            ChangeAccountInfo(userAccount);
        }

        private void ChangeAccountInfo(AccountModel acc)
        {
            userNameTextBox.Text = acc.UserName;
            displayNameTextBox.Text = acc.DisplayName;
        }

        private void UpdateAccountInfo()
        {
            string userName = userNameTextBox.Text;
            string displayName = displayNameTextBox.Text;
            string password = passwordTextBox.Text;
            string newPassword = newPasswordTextBox.Text;
            string reenterNewPassword = reenterNewPasswordTextBox.Text;

            if (!newPassword.Equals(reenterNewPassword))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.AuthenticationUpdateAccountInfo(userName, displayName, password, newPassword))
                {
                    MessageBox.Show("Cập nhật thành công.");

                    // C# hỗ trợ ghi ngắn gọn cách viết code khi kiểm tra UpdateAccount != null?
                    UpdateAccount?.Invoke(this, new AccountEvent(AccountDAO.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }

        public event EventHandler<AccountEvent> UpdateAccount;

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }

    public class AccountEvent: EventArgs
    {
        private AccountModel acc;

        public AccountModel Acc { get => acc; set => acc = value; }

        public AccountEvent(AccountModel account)
        {
            Acc = account;
        }
    }
}
