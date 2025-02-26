using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
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

namespace Restaurant_Management_System.View
{
    public partial class frmTableView : SampleView
    {
        public frmTableView()
        {
            InitializeComponent();
        }
        private void frmTableView_Load(object sender, EventArgs e)
        {
            LoadTableData();
        }

        private void LoadTableData()
        {
            string query = @"
        SELECT TableID, Capacity, Status, EmployeeID
        FROM Tables"; // Chỉ lấy cột cần thiết

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query); 

                dgvTables.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvTables.Rows.Add();
                    dgvTables.Rows[i].Cells["dgvSno"].Value = i + 1; 
                    dgvTables.Rows[i].Cells["dgvTableID"].Value = dt.Rows[i]["TableID"];
                    dgvTables.Rows[i].Cells["dgvCapacity"].Value = dt.Rows[i]["Capacity"];
                    dgvTables.Rows[i].Cells["dgvStatus"].Value = dt.Rows[i]["Status"];
                    dgvTables.Rows[i].Cells["dgvEmployeeID"].Value = dt.Rows[i]["EmployeeID"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmTableAdd frm = new frmTableAdd(-1);
            frm.ShowDialog();
            LoadTableData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvTables.Rows)
            {
                if (row.Cells["dgvTableID"].Value != null && row.Cells["dgvStatus"].Value != null && row.Cells["dgvEmployeeID"].Value != null)
                {
                    string id = row.Cells["dgvTableID"].Value.ToString().ToLower();
                    string status = row.Cells["dgvStatus"].Value.ToString().ToLower();
                    string employee = row.Cells["dgvEmployeeID"].Value.ToString().ToLower();

                    row.Visible = id.Contains(searchValue) || status.Contains(searchValue) || employee.Contains(searchValue);
                }
            }
        }


        private void dgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào Header
            {
                if (e.ColumnIndex == dgvTables.Columns["dgvedit"].Index) 
                {
                    string tableID = dgvTables.Rows[e.RowIndex].Cells["dgvTableID"].Value.ToString();
                    int id = Convert.ToInt32(tableID);
                    frmTableAdd frm = new frmTableAdd(id);
                    frm.txtCapacity.Text = Convert.ToString(dgvTables.CurrentRow.Cells["dgvCapacity"].Value);
                    frm.ShowDialog();
                    LoadTableData();
                }

                if (e.ColumnIndex == dgvTables.Columns["dgvdel"].Index) 
                {
                    string tableID = dgvTables.Rows[e.RowIndex].Cells["dgvTableID"].Value.ToString();
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa bàn {tableID}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = $"DELETE FROM Tables WHERE TableID = @TableID";
                        SqlParameter[] param = { new SqlParameter("@TableID", tableID) };

                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(deleteQuery, param);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Đã xóa bàn {tableID} thành công!");
                            LoadTableData(); 
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa bàn!");
                        }
                    }
                }
            }
        }


        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
