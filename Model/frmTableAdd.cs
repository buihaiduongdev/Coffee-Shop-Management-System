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
    public partial class frmTableAdd : SampleAdd
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
            try
            {
                // Lấy giá trị TableID mới
                string query = "SELECT MAX(TableID) FROM Tables";
                object result = DatabaseHelper.ExecuteScalar(query);
                int tableID = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1; // Bắt đầu từ 1 nếu bảng trống

                // Kiểm tra giá trị nhập từ txtCapacity
                if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
                {
                    MessageBox.Show("Vui lòng nhập một số hợp lệ cho sức chứa!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string status = cmbStatus.SelectedItem.ToString();

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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bàn: " + ex.Message);
            }
        }

        public void UpdateTable(int tableID)
        {
            try
            {
                if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
                {
                    MessageBox.Show("Vui lòng nhập một số hợp lệ cho sức chứa!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string status = cmbStatus.SelectedItem.ToString() ; 

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
                    MessageBox.Show("Bàn đã được cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật bàn: " + ex.Message);
            }
        }
        


        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (TableID == -1) 
            {
                InsertTable();
                this.Close();
            }
            else 
            {
                UpdateTable(TableID);
                this.Close();
            }
        
        }
        private void txtCapacity_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
