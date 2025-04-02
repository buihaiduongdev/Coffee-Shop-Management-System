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
    public partial class frmTableViews : Form
    {
        public frmTableViews()
        {
            InitializeComponent();
        }

        private void dgvTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvTables.Rows)
            {
                if (row.Cells["dgvTableID"].Value != null && row.Cells["dgvStatus"].Value != null)
                {
                    string id = row.Cells["dgvTableID"].Value.ToString().ToLower();
                    string status = row.Cells["dgvStatus"].Value.ToString().ToLower();


                    row.Visible = id.Contains(searchValue) || status.Contains(searchValue);
                }
            }
        }
        private void LoadTableData()
        {
            string query = @"
        SELECT TableID, Capacity, Status
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
                }
                dgvTables.DefaultCellStyle.Font = new Font("Arial", 16, FontStyle.Regular);
                dgvTables.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
                dgvTables.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmTableViews_Load(object sender, EventArgs e)
        {
            LoadTableData();
        }
    }
}
