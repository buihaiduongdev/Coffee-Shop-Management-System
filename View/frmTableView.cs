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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant_Management_System.View
{
    public partial class frmTableView :Form
    {
        private string language = ucLogin.languages;
        public frmTableView()
        {
            InitializeComponent();
            IconTableFree.HoverState.FillColor = IconTableFree.FillColor;
            IconTableFree.HoverState.BorderColor = IconTableFree.BorderColor;
            IconTableFree.PressedColor = IconTableFree.FillColor;

            IconTableReserved.HoverState.FillColor = IconTableReserved.FillColor;
            IconTableReserved.HoverState.BorderColor = IconTableReserved.BorderColor;
            IconTableReserved.PressedColor = IconTableReserved.FillColor;
        }
        private void ApplyCustomTheme()
        {
            // Xóa theme mặc định
            dgvTables.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvTables.EnableHeadersVisualStyles = false;

            // Header
            dgvTables.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 99, 76);
            dgvTables.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTables.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTables.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTables.ColumnHeadersHeight = 40;

            // Dòng thường
            dgvTables.DefaultCellStyle.BackColor = Color.FromArgb(165, 140, 100); // Be sáng
            dgvTables.DefaultCellStyle.ForeColor = Color.Black;
            dgvTables.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTables.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224); // Nâu vừa
            dgvTables.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTables.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 

            // Dòng xen kẽ
            dgvTables.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 177, 142); // Xám nhạt  
            dgvTables.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 177, 142);

            // Bảng
            dgvTables.BackgroundColor = Color.FromArgb(165, 140, 100);
            dgvTables.BorderStyle = BorderStyle.None;
            dgvTables.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTables.RowTemplate.Height = 35;

            // Khác
            dgvTables.ReadOnly = false;
            dgvTables.AllowUserToAddRows = false;
            dgvTables.AllowUserToResizeRows = false;
            dgvTables.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void frmTableView_Load(object sender, EventArgs e)
        {
            
            LoadTableData();
            List<string> status = language == "vi" ? new List<string>() { "Trạng thái", "Đã có người", "Trống", "Không khả thi" }  : new List<string>() { "Status", "Occupied" ,"Empty", "Unvailable"};
            cbbStatus.DataSource = status;
            load_language(language);
            //ApplyCustomTheme();
        }
        DataTable dt;
        private void LoadTableData()
        {
            string query = @"
            SELECT TableID, Capacity, Status
            FROM Tables WHERE IsDeleted = 0"; // Chỉ lấy cột cần thiết

            try
            {
                int reserved = 0;
                int free = 0;
                dt = DatabaseHelper.ExecuteQuery(query); 

                dgvTables.Rows.Clear();
                dgvTables.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvTables.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvTables.Rows.Add();
                    dgvTables.Rows[i].Cells["dgvSno"].Value = i + 1; 
                    dgvTables.Rows[i].Cells["dgvTableID"].Value = dt.Rows[i]["TableID"];
                    dgvTables.Rows[i].Cells["dgvCapacity"].Value = dt.Rows[i]["Capacity"];
                    dgvTables.Rows[i].Cells["dgvStatus"].Value = dt.Rows[i]["Status"];
                    if (dt.Rows[i]["Status"].ToString().Trim() == "Occupied") reserved++;
                    else if (dt.Rows[i]["Status"].ToString().Trim() == "Empty") free++;
                }
                lblNumberTableFree.Text = free.ToString();
                lblNumberTableReserved.Text = reserved.ToString();
                dgvTables.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                if (language == "en") MessageBox.Show("Error loading table data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Lỗi khi tải dữ liệu bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ApplyCustomTheme();
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> status = language == "vi" ? new List<string>() { "", "Đã có người", "Trống", "Không khả thi" } : new List<string>() {"", "Occupied", "Empty", "Unvailable" };
            frmTableAdd frm = new frmTableAdd(-1);
            frm.cmbStatus.DataSource = status;
            frm.ShowDialog();
            LoadTableData();
        }

        public void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvTables.Rows)
            {
                if (row.Cells["dgvTableID"].Value != null && 
                    row.Cells["dgvStatus"].Value != null)
                {
                    string id = row.Cells["dgvTableID"].Value.ToString().ToLower();
                    string status = row.Cells["dgvStatus"].Value.ToString().ToLower();

                    row.Visible = id.Contains(searchValue) || status.Contains(searchValue);
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
                    string status = Convert.ToString(dgvTables.CurrentRow.Cells["dgvStatus"].Value);
                    frm.cmbStatus.DataSource = language == "vi" ? new List<string>() { "Trạng thái", "Đã có người", "Trống", "Không khả thi" } : new List<string>() { "Status", "Occupied", "Empty", "Unvailable" };
                    frm.cmbStatus.SelectedItem = status;
                    frm.ShowDialog();
                    LoadTableData();
                }

                if (e.ColumnIndex == dgvTables.Columns["dgvdel"].Index) 
                {
                    string tableID = dgvTables.Rows[e.RowIndex].Cells["dgvTableID"].Value.ToString();
                    DialogResult result = language == "en" ? MessageBox.Show($"Are you wish to delete table {tableID}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) : MessageBox.Show($"Bạn có chắc muốn xóa bàn {tableID}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = $"UPDATE Tables SET IsDeleted = 1 WHERE TableID = @TableID";
                        SqlParameter[] param = { new SqlParameter("@TableID", tableID) };

                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(deleteQuery, param);
                        if (rowsAffected > 0)
                        {
                            if (language == "en") MessageBox.Show($"Table {tableID} has been deleted successfully!");
                            else MessageBox.Show($"Đã xóa bàn {tableID} thành công!");
                            LoadTableData(); 
                        }
                        else
                        {
                            if (language == "en") MessageBox.Show("Lỗi khi xóa bàn!");
                            else MessageBox.Show("Error when deleting table!");
                        }
                    }
                }
            }
        }

        private void IconTableFree_Click(object sender, EventArgs e)
        {
            IconTableFree.FillColor = Color.SpringGreen;
            IconTableFree.BorderColor = Color.SpringGreen;
        }

        private void IconTableReserved_Click(object sender, EventArgs e)
        {
            IconTableReserved.FillColor = Color.Salmon;
            IconTableReserved.BorderColor = Color.Salmon;
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterValue = cbbStatus.Text;
            if (filterValue == "Status" || filterValue == "Trạng thái")
            {
                cbbStatus.SelectedText = "Category";
                cbbStatus.ForeColor = Color.Gray;
                LoadTableData();
            }
            else
            {
                filterValue = filterValue == "Trống" ? "Empty" : filterValue == "Đã có người" ? "Occupied" : "Unvailable";
                cbbStatus.ForeColor = Color.Black;
                string query = $"SELECT * FROM Tables WHERE Status = '{filterValue}'";
                try
                {
                    dt = DatabaseHelper.ExecuteQuery(query);
                    dgvTables.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvTables.Rows.Add();
                        dgvTables.Rows[i].Cells["dgvSno"].Value = i + 1;
                        dgvTables.Rows[i].Cells["dgvTableID"].Value = dt.Rows[i]["TableID"];
                        dgvTables.Rows[i].Cells["dgvCapacity"].Value = dt.Rows[i]["Capacity"];
                        dgvTables.Rows[i].Cells["dgvStatus"].Value = dt.Rows[i]["Status"];
                    }
                }
                catch (Exception ex)
                {
                    
                    if (language == "en") MessageBox.Show("Error loading product data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvTables_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvTables.Columns["dgvStatus"].DefaultCellStyle = new DataGridViewCellStyle();
            if (dgvTables.Columns[e.ColumnIndex].Name == "dgvStatus" && e.Value != null)
            {
                string status = e.Value.ToString().Trim().ToLower();
                if (status == "empty")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.SelectionForeColor = Color.Green;
                }
                else if (status == "reserved" || status == "occupied")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Gray;
                    e.CellStyle.SelectionForeColor = Color.Gray;
                }
            }
        }

        private void IconTableReserved_MouseLeave(object sender, EventArgs e)
        {
            IconTableReserved.FillColor = Color.Salmon;
            IconTableReserved.BorderColor = Color.Salmon;
        }

        private void dgvTables_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            lblTable.Text = LocalizationHelper.GetString("lblTable");
            btnAddTable.Text = LocalizationHelper.GetString("btnAddTable");
            lblEmptyTable.Text = LocalizationHelper.GetString("lblEmptyTable");
            lblReservedTable.Text = LocalizationHelper.GetString("lblReservedTable");
            txtSearch.PlaceholderText = LocalizationHelper.GetString("txtSearchTable");
            dgvTables.Columns["dgvTableID"].HeaderText = LocalizationHelper.GetString("dgvTableID");
            dgvTables.Columns["dgvCapacity"].HeaderText = LocalizationHelper.GetString("dgvCapacity");
            dgvTables.Columns["dgvStatus"].HeaderText = LocalizationHelper.GetString("dgvStatus");
            dgvTables.Columns["dgvedit"].HeaderText = LocalizationHelper.GetString("dgvedit");
            dgvTables.Columns["dgvdel"].HeaderText = LocalizationHelper.GetString("dgvdel");
        }

        private void lblTable_Click(object sender, EventArgs e)
        {

        }

        private void lblTable_Click_1(object sender, EventArgs e)
        {

        }
    }
}
