using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeteriaManagement.DAO;
using CafeteriaManagement.DTO;
using MySql.Data.MySqlClient;

namespace CafeteriaManagement
{
    public partial class AdminForm : Form
    {
        private BindingSource foodList = new BindingSource();
        private BindingSource accountList = new BindingSource();
        private BindingSource categoryList = new BindingSource();
        private BindingSource tableList = new BindingSource();

        public AdminForm()
        {
            InitializeComponent();

            LoadDateTimePickerBill();
            LoadFullBillsByDateTime(fromDateDTPicker.Value, toDateDTPicker.Value);

            // Các data grid view lúc này có DataSource là một binding
            // cho nên các hàm AddBinding vẫn sẽ hoạt động tốt nếu như reload lại cái biến BindingSource
            accountDataGridView.DataSource = accountList;
            foodDataGridView.DataSource = foodList;
            foodCategoryDataGridView.DataSource = categoryList;
            tableDataGridView.DataSource = tableList;

            LoadAccounts();
            AddAccountBinding();

            LoadFoods();
            AddFoodBinding();

            LoadCategories();
            AddCategoryBinding();

            LoadTables();
            AddTableBinding();
        }

        #region METHODS

        private void AddAccountBinding()
        {
            loginNameTextBox.DataBindings.Add(new Binding("Text", accountDataGridView.DataSource, "Tên người dùng", true, DataSourceUpdateMode.Never));
            displayNameTextBox.DataBindings.Add(new Binding("Text", accountDataGridView.DataSource, "Tên hiển thị", true, DataSourceUpdateMode.Never));
            accountTypeTextBox.DataBindings.Add(new Binding("Text", accountDataGridView.DataSource, "Loại tài khoản", true, DataSourceUpdateMode.Never));
        }

        private void LoadAccounts()
        {
            accountList.DataSource = AccountDAO.GetAccountList();
        }

        private List<FoodModel> SearchFoodsByName(string name)
        {
            return FoodDAO.SearchFoodsByName(name);
        }

        private void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            fromDateDTPicker.Value = new DateTime(today.Year, today.Month, 1);
            toDateDTPicker.Value = fromDateDTPicker.Value.AddMonths(1).AddDays(-1);
        }

        private void LoadFullBillsByDateTime(DateTime checkIn, DateTime checkOut)
        {
            billDataGridView.DataSource = BillDAO.GetFullBillsByDateTime(checkIn, checkOut);
        }

        private void AddFoodBinding()
        {
            foodIdTextBox.DataBindings.Add(new Binding("Text",
                foodDataGridView.DataSource,
                "Id", true,
                DataSourceUpdateMode.Never));
            foodNameTextBox.DataBindings.Add(new Binding("Text",
                foodDataGridView.DataSource,
                "Name", true,
                DataSourceUpdateMode.Never));
            foodPriceNumericUpDown.DataBindings.Add(new Binding("Value",
                foodDataGridView.DataSource,
                "Price", true,
                DataSourceUpdateMode.Never));
        }

        private void LoadFoods()
        {
            foodList.DataSource = FoodDAO.GetFoodList();
        }

        private void AddCategoryBinding()
        {
            foodCategoryIdTextBox.DataBindings.Add(new Binding("Text",
                foodCategoryDataGridView.DataSource,
                "Id", true,
                DataSourceUpdateMode.Never));
            foodCategoryNameTextBox.DataBindings.Add(new Binding("Text",
                foodCategoryDataGridView.DataSource,
                "Name", true,
                DataSourceUpdateMode.Never));
        }

        private void LoadCategories()
        {
            List<FoodCategoryModel> categories = FoodCategoryDAO.GetCategoryList();

            foodCategoryComboBox.DataSource = categories;
            foodCategoryComboBox.DisplayMember = "Name";

            categoryList.DataSource = categories;
        }

        private void AddTableBinding()
        {
            tableIdTextBox.DataBindings.Add(new Binding("Text",
                tableDataGridView.DataSource,
                "Id", true,
                DataSourceUpdateMode.Never));
            tableNameTextBox.DataBindings.Add(new Binding("Text",
                tableDataGridView.DataSource,
                "Name", true,
                DataSourceUpdateMode.Never));
            tableStatusTextBox.DataBindings.Add(new Binding("Text",
                tableDataGridView.DataSource,
                "Status", true,
                DataSourceUpdateMode.Never));
        }

        private void LoadTables()
        {
            tableList.DataSource = TableDAO.GetTableList();
        }

        #endregion

        #region EVENTS
        private void viewBillButton_Click(object sender, EventArgs e)
        {
            LoadFullBillsByDateTime(fromDateDTPicker.Value, toDateDTPicker.Value);
        }

        private void foodIdTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (foodDataGridView.SelectedCells.Count > 0)
                {
                    int id = (int)foodDataGridView.SelectedCells[0].OwningRow.Cells["CategoryId"].Value;

                    FoodCategoryModel foodCategory = FoodCategoryDAO.GetCategoryById(id);

                    foodCategoryComboBox.SelectedItem = foodCategory;

                    int index = -1;
                    int i = 0;

                    foreach (FoodCategoryModel fc in foodCategoryComboBox.Items)
                    {
                        if (fc.Id == foodCategory.Id)
                        {
                            index = i;
                            break;
                        }

                        ++i;
                    }

                    foodCategoryComboBox.SelectedIndex = index;
                }
            }
            catch {}
        }

        private void searchFoodButton_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodsByName(searchFoodNameTextBox.Text);
        }

        private void addFoodButton_Click(object sender, EventArgs e)
        {
            string name = foodNameTextBox.Text;
            int categoryId = (foodCategoryComboBox.SelectedItem as FoodCategoryModel).Id;
            float price = (float)foodPriceNumericUpDown.Value;

            if (FoodDAO.InsertFood(name, categoryId, price))
            {
                MessageBox.Show("Thêm món thành công");

                LoadFoods();
            }
            else
            {
                MessageBox.Show("Error", "Lỗi khi thêm món", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editFoodButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa món đã chọn?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string name = foodNameTextBox.Text;
                int categoryId = (foodCategoryComboBox.SelectedItem as FoodCategoryModel).Id;
                float price = (float)foodPriceNumericUpDown.Value;
                int id = int.Parse(foodIdTextBox.Text);

                if (FoodDAO.UpdateFood(name, categoryId, price, id))
                {
                    MessageBox.Show("Sửa món thành công");

                    LoadFoods();
                }
                else
                {
                    MessageBox.Show("Lỗi khi sửa món", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        private void deleteFoodButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa món đã chọn?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(foodIdTextBox.Text);

                try
                {
                    if (FoodDAO.DeleteFood(id))
                    {
                        MessageBox.Show("Xóa món thành công");

                        LoadFoods();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa món", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể xóa món đã có trong bill!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void viewFoodButton_Click(object sender, EventArgs e)
        {
            LoadFoods();
        }

        private void addFoodCategoryButton_Click(object sender, EventArgs e)
        {
            string name = foodCategoryNameTextBox.Text;

            if (FoodCategoryDAO.InsertFoodCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công");

                LoadCategories();
            }
            else
            {
                MessageBox.Show("Error", "Lỗi khi thêm danh mục", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editFoodCategoryButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa danh mục đã chọn?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string name = foodCategoryNameTextBox.Text;
                int id = int.Parse(foodCategoryIdTextBox.Text);

                if (FoodCategoryDAO.UpdateFoodCategory(name, id))
                {
                    MessageBox.Show("Sửa danh mục thành công");

                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Error", "Lỗi khi sửa danh mục", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteFoodCategoryButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa danh mục đã chọn?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(foodCategoryIdTextBox.Text);

                try
                {
                    if (FoodCategoryDAO.DeleteFoodCategory(id))
                    {
                        MessageBox.Show("Xóa danh mục thành công");

                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa danh mục", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể xóa danh mục của món ăn sẵn có!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void viewFoodCategoryButton_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void addTableButton_Click(object sender, EventArgs e)
        {
            string name = tableNameTextBox.Text;

            if (TableDAO.InsertTable(name))
            {
                MessageBox.Show("Thêm bàn thành công");

                LoadTables();
            }
            else
            {
                MessageBox.Show("Error", "Lỗi khi thêm bàn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editTableButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa danh mục đã chọn?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string name = tableNameTextBox.Text;
                string status = tableStatusTextBox.Text;
                int id = int.Parse(tableIdTextBox.Text);

                if (TableDAO.UpdateTable(name, status, id))
                {
                    MessageBox.Show("Sửa bàn thành công");

                    LoadTables();
                }
                else
                {
                    MessageBox.Show("Error", "Lỗi khi sửa bàn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteTableButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa bàn đã chọn?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(tableIdTextBox.Text);

                try
                {
                    if (TableDAO.DeleteTable(id))
                    {
                        MessageBox.Show("Xóa bàn thành công");

                        LoadTables();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa bàn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể xóa bàn đã dùng!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void viewTableButton_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void viewAccountButton_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }
        #endregion
    }
}
