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
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmTableAdd : Form
    {
        public frmTableAdd(int tableID)
        {
            InitializeComponent();
            TableID = tableID;
        }
        int TableID;

        private void frmTableAdd_Load(object sender, EventArgs e)
        {
        }
        public void InsertTable()
        {
            // Lấy giá trị TableID mới
            string query = "SELECT MAX(TableID) FROM Tables";
            object result = DatabaseHelper.ExecuteScalar(query);
            int tableID = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1; // Bắt đầu từ 1 nếu bảng trống
            string status = cmbStatus.SelectedItem.ToString();

            if (string.IsNullOrEmpty(status) || string.IsNullOrEmpty(txtCapacity.Text))
            {
                throw new Exception("Lỗi nhập liệu! Vui lòng điền đầy dủ tất cả thông tin");
            }
            // Kiểm tra giá trị nhập từ txtCapacity
            if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
            {
                throw new Exception("Lỗi nhập liệu! Vui lòng nhập một số hợp lệ cho sức chứa!");
            }
            string queryInsert = @"
                INSERT INTO Tables(TableID, Capacity, Status)
                VALUES(@TableID, @Capacity, @Status)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TableID", tableID),
                new SqlParameter("@Capacity", capacity),
                new SqlParameter("@Status", status)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(queryInsert, parameters);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Bàn đã được thêm thành công!");
            }
            else
            {
                MessageBox.Show("Không thể thêm bàn. Vui lòng thử lại.");
            }
        }

        public void UpdateTable(int tableID)
        {
            string status = cmbStatus.SelectedItem.ToString();

            if (string.IsNullOrEmpty(status) || string.IsNullOrEmpty(txtCapacity.Text))
            {
                throw new Exception("Lỗi nhập liệu! Vui lòng điền đầy dủ tất cả thông tin");
            }

            if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
            {
                throw new Exception("Lỗi nhập liệu! Vui lòng nhập một số hợp lệ cho sức chứa!");
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
                MessageBox.Show("Bàn đã được cập nhật thành công!", "Notification");
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào được thực hiện.", "Notification");
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
                if (AddTable) MessageBox.Show("Lỗi khi thêm bàn: " + ex.Message, "Notification");
                else MessageBox.Show("Lỗi khi cập nhật bàn: " + ex.Message, "Notification");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
