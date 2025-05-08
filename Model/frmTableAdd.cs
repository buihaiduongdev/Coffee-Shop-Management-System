using Restaurant_Management_System.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmTableAdd : Form
    {
        private string language = ucLogin.languages;
        public frmTableAdd(int tableID)
        {
            InitializeComponent();
            TableID = tableID;
        }
        int TableID;

        private void frmTableAdd_Load(object sender, EventArgs e)
        {
            load_language(language);
        }
        public void InsertTable()
        {
            // Lấy giá trị TableID mới
            string query = "SELECT MAX(TableID) FROM Tables";
            object result = DatabaseHelper.ExecuteScalar(query);
            string status = cmbStatus.SelectedItem.ToString();
            status = status == "Trống" ? "Empty" : status == "Đã có người" ? "Occupied" : "Unvailable";

            if (string.IsNullOrEmpty(status) || string.IsNullOrEmpty(txtCapacity.Text))
            {
                if (language == "en")
                {
                    throw new Exception("Input error! Please fill in all the information");
                }
                else
                {
                    throw new Exception("Lỗi nhập liệu! Vui lòng điền đầy dủ tất cả thông tin");
                }
            }
            // Kiểm tra giá trị nhập từ txtCapacity
            if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
            {
                if (language == "en")
                {
                    throw new Exception("Input error! Please enter a valid number for capacity!");
                }
                else
                {
                    throw new Exception("Lỗi nhập liệu! Vui lòng nhập một số hợp lệ cho sức chứa!");
                }
            }
            string queryInsert = @"
                INSERT INTO Tables(Capacity, Status)
                VALUES(@Capacity, @Status)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Capacity", capacity),
                new SqlParameter("@Status", status)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(queryInsert, parameters);

            if (rowsAffected > 0)
            {
                if (language == "en")
                {
                    MessageBox.Show("Table added successfully!");
                }
                else
                {
                    MessageBox.Show("Bàn đã được thêm thành công!");
                }
            }
            else
            {
                if (language == "en")
                {
                    MessageBox.Show("Failed to add table. Please try again.");
                }
                else
                {
                    MessageBox.Show("Không thể thêm bàn. Vui lòng thử lại.");
                }
            }
        }

        public void UpdateTable(int tableID)
        {
            string status = cmbStatus.SelectedItem.ToString();
            status = status == "Trống" ? "Empty" : status == "Đã có người" ? "Occupied" : "Unvailable";

            if (string.IsNullOrEmpty(status) || string.IsNullOrEmpty(txtCapacity.Text))
            {
                if (language == "en")
                {
                    throw new Exception("Input error! Please fill in all the information");
                }
                else
                {
                    throw new Exception("Lỗi nhập liệu! Vui lòng điền đầy dủ tất cả thông tin");
                }
            }

            if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
            {
                if (language == "en")
                {
                    throw new Exception("Input error! Please enter a valid number for capacity!");
                }
                else
                {
                    throw new Exception("Lỗi nhập liệu! Vui lòng nhập một số hợp lệ cho sức chứa!");
                }
            }

            string queryUpdate = @"
                UPDATE Tables 
                SET Capacity = @Capacity, 
                    Status = @Status
                WHERE TableID = @TableID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TableID", tableID),
                new SqlParameter("@Capacity", capacity),
                new SqlParameter("@Status", status)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(queryUpdate, parameters);

            if (rowsAffected > 0)
            {
                if (language == "en")
                {
                    MessageBox.Show("Table updated successfully!", "Notification");
                }
                else
                {
                    MessageBox.Show("Bàn đã được cập nhật thành công!", "Thông báo");
                }
     
            }
            else
            {
                if (language == "en")
                {
                    MessageBox.Show("Failed to update table. Please try again.", "Notification");
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật bàn. Vui lòng thử lại.", "Thông báo");
                }
            }
        }
        


        public void btnSave_Click(object sender, EventArgs e)
        {
            bool AddTable = false;
            try
            {
                if (TableID == -1)
                {
                    AddTable = true;
                    InsertTable();
                    this.Close();
                }
                else
                {
                    UpdateTable(TableID);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (AddTable)
                {
                    if (language == "en")
                    {
                        MessageBox.Show("Error when adding table: " + ex.Message, "Notification");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm bàn: " + ex.Message, "Thông báo");
                    }
                }
                else
                {
                    if (language == "en")
                    {
                        MessageBox.Show("Error when updating table: " + ex.Message, "Notification");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi cập nhật bàn: " + ex.Message, "Thông báo");
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            lblTableAdd.Text = LocalizationHelper.GetString("lblTableAdd");
            lblCapacity.Text = LocalizationHelper.GetString("lblCapacity");
            lblStatus.Text = LocalizationHelper.GetString("lblStatus");
            btnSave.Text = LocalizationHelper.GetString("btnSave");
            btnClose.Text = LocalizationHelper.GetString("btnClose");
            txtCapacity.PlaceholderText = LocalizationHelper.GetString("txtCapacity");
        }
    }
}
