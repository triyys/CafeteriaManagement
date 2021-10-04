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
using System.Globalization;

namespace CafeteriaManagement
{
    public partial class TableManagerForm : Form
    {
        private AccountModel loginAccount;

        public TableManagerForm(AccountModel acc)
        {
            InitializeComponent();

            this.loginAccount = acc;
            PermissionToAdminAccount(loginAccount.Type);

            LoadTables();
            LoadCategories();
            LoadTableComboBox(switchTableComboBox);
        }

        #region METHODS

        void PermissionToAdminAccount(int type)
        {
            adminToolStripMenuItem.Enabled = (type == 1);

            thôngTinToolStripMenuItem.Text += $" ({ loginAccount.DisplayName })";
        }

        private void LoadCategories()
        {
            List<FoodCategoryModel> foodCategories = FoodCategoryDAO.GetCategoryList();
            categoryComboBox.DataSource = foodCategories;
            categoryComboBox.DisplayMember = "Name";
        }

        private void LoadFoodsByCategoryId(int id)
        {
            List<FoodModel> foods = FoodDAO.GetFoodsByFoodCategoryId(id);
            foodComboBox.DataSource = foods;
            foodComboBox.DisplayMember = "Name";
        }

        private void LoadTables()
        {
            tableFLPanel.Controls.Clear();

            List<TableModel> tables = TableDAO.GetTableList();

            foreach (TableModel t in tables)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };

                btn.Text = $"{ t.Name }{ Environment.NewLine }{ t.Status }";
                btn.Click += btn_Click;
                btn.Tag = t;

                switch (t.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                tableFLPanel.Controls.Add(btn);
            }
        }

        private void ShowBill(int id)
        {
            mainListView.Items.Clear();

            List<MenuModel> menus = MenuDAO.GetMenusByTableId(id);
            float totalPrice = 0;

            foreach (MenuModel menu in menus)
            {
                ListViewItem lsvItem = new ListViewItem(menu.FoodName.ToString());
                lsvItem.SubItems.Add(menu.Count.ToString());
                lsvItem.SubItems.Add(menu.Price.ToString());
                lsvItem.SubItems.Add(menu.TotalPrice.ToString());

                totalPrice += menu.TotalPrice;

                mainListView.Items.Add(lsvItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");

            totalPriceTextBox.Text = totalPrice.ToString("c", culture);
        }

        private void LoadTableComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = TableDAO.GetTableList();
            comboBox.DisplayMember = "Name";
        }

        #endregion

        #region EVENTS
        private void btn_Click(object sender, EventArgs e)
        {
            int currentTableId = ((sender as Button).Tag as TableModel).Id;
            mainListView.Tag = (sender as Button).Tag;
            ShowBill(currentTableId);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfileForm frm = new AccountProfileForm(loginAccount);

            frm.UpdateAccount += Frm_UpdateAccount;
            frm.ShowDialog();
        }

        private void Frm_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinToolStripMenuItem.Text = $"Thông tin tài khoản ({ e.Acc.DisplayName })";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm frm = new AdminForm();
            frm.ShowDialog();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
            {
                return;
            }

            FoodCategoryModel fc = cb.SelectedItem as FoodCategoryModel;
            id = fc.Id;

            LoadFoodsByCategoryId(id);
        }

        private void addFoodButton_Click(object sender, EventArgs e)
        {
            TableModel currentTable = mainListView.Tag as TableModel;

            int currentBillId = BillDAO.GetUncheckedBillIdByTableId(currentTable.Id);
            int selectedFoodId = (foodComboBox.SelectedItem as FoodModel).Id;
            int selectedCount = (int)foodCountNumericUpDown.Value;

            if (currentBillId == -1)
            {
                BillDAO.InsertBill(currentTable.Id);
                BillInfoDAO.InsertBillInfo(BillDAO.GetMaxIdBill(), selectedFoodId, selectedCount);
            }
            else
            {
                BillInfoDAO.InsertBillInfo(currentBillId, selectedFoodId, selectedCount);
            }

            ShowBill(currentTable.Id);

            LoadTables();
        }

        private void checkOutButton_Click(object sender, EventArgs e)
        {
            TableModel currentTable = mainListView.Tag as TableModel;

            int currentBillId = BillDAO.GetUncheckedBillIdByTableId(currentTable.Id);
            int discount = (int)discountNumericUpDown.Value;

            double totalPrice = Convert.ToDouble(totalPriceTextBox.Text.Split(',')[0].Replace(".", ""));
            double mustpayPrice = totalPrice - totalPrice / 100 * discount;

            if (currentBillId != -1)
            {
                DialogResult mess = MessageBox.Show($"Bạn có chắc thanh toán hóa đơn cho { currentTable.Name }\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> { totalPrice } - ({ totalPrice } / 100) x { discount } = { mustpayPrice }",
                    "Thông báo",
                    MessageBoxButtons.OKCancel);

                if (mess == DialogResult.OK)
                {
                    BillDAO.CheckOut(currentBillId, discount, (float)mustpayPrice);

                    ShowBill(currentTable.Id);

                    LoadTables();
                }
            }
        }
        #endregion

        private void switchTableButton_Click(object sender, EventArgs e)
        {
            TableModel currentTable = mainListView.Tag as TableModel;
            TableModel switchTable = switchTableComboBox.SelectedItem as TableModel;

            int from = currentTable.Id;
            int to = switchTable.Id;

            if (MessageBox.Show($"Bạn có thật sự muốn chuyển { currentTable.Name } sang { switchTable.Name }", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableDAO.SwitchTable(from, to);

                LoadTables();
            }
        }
    }
}
