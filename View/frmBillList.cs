using Guna.UI2.WinForms;
using Restaurant_Management_System.Backend;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmBillList : SampleView
    {
        int receptionistID;
        private string language = ucLogin.languages;
        public frmBillList(int ReceptionistID)
        {
            InitializeComponent();
            receptionistID = ReceptionistID;
        }

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
            load_language(language);
        }
        private void ApplyCustomTheme()
        {
            try
            {

                //// Header
                dgvBill.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 99, 76);
                dgvBill.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvBill.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvBill.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBill.ColumnHeadersHeight = 40;

                // Dòng thường
                dgvBill.DefaultCellStyle.BackColor = Color.FromArgb(165, 140, 100); // Be sáng
                dgvBill.DefaultCellStyle.ForeColor = Color.Black;
                dgvBill.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvBill.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224); // Nâu vừa
                dgvBill.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBill.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Dòng xen kẽ
                dgvBill.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 177, 142); // Xám nhạt  

                // Bảng
                dgvBill.BackgroundColor = Color.AntiqueWhite;
                dgvBill.BorderStyle = BorderStyle.None;
                dgvBill.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvBill.RowTemplate.Height = 35;

                // Khác
                dgvBill.ReadOnly = false;
                dgvBill.AllowUserToAddRows = false;
                dgvBill.AllowUserToResizeRows = false;
                dgvBill.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi áp dụng theme: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void LoadData()
        {
            string query = @"
                    SELECT o.OrderID, o.OrderType, o.Status, sum(od.Quantity * od.UnitPrice) as Total
                    FROM Orders o
                    JOIN [Order Details] od
                    ON o.OrderID = od.OrderID
                    Where o.Status = 'Pending'
                    GROUP BY o.OrderID, o.OrderType, o.Status
                ";

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                dgvBill.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvBill.Rows.Add();
                    dgvBill.Rows[i].Cells["dgvSrNo"].Value = i + 1; // 
                    dgvBill.Rows[i].Cells["dgvOrderID"].Value = dt.Rows[i]["OrderID"];
                    dgvBill.Rows[i].Cells["dgvOrderType"].Value = dt.Rows[i]["OrderType"];
                    dgvBill.Rows[i].Cells["dgvStatus"].Value = dt.Rows[i]["Status"];
                    dgvBill.Rows[i].Cells["dgvTotal"].Value = dt.Rows[i]["Total"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ApplyCustomTheme();
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvBill.Columns["dgvConfirm"].Index)
                {
                    string orderID = dgvBill.Rows[e.RowIndex].Cells["dgvOrderID"].Value.ToString();
                    string updateQuery = "UPDATE Orders SET Status = 'Confirmed', EmployeeID = @EmployeeID " +
                                        "WHERE OrderID = @OrderID";

                    SqlParameter[] param = {
                        new SqlParameter("@OrderID", orderID) ,
                        new SqlParameter("@EmployeeID", receptionistID)
                    };

                    try
                    {
                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(updateQuery, param);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Đã xác nhận hóa đơn {orderID} thành công!");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xác nhận hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (e.ColumnIndex == dgvBill.Columns["dgvReject"].Index)
                {
                    string orderID = dgvBill.Rows[e.RowIndex].Cells["dgvOrderID"].Value.ToString();

                    string updateQuery = "UPDATE Orders SET Status = 'Rejected', EmployeeID = @EmployeeID " +
                                        "WHERE OrderID = @OrderID";

                    SqlParameter[] param = {
                        new SqlParameter("@OrderID", orderID) ,
                        new SqlParameter("@EmployeeID", receptionistID) 
                    };

                    try
                    {
                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(updateQuery, param);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Đã từ chối hóa đơn {orderID} thành công!");
                         
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi từ chối hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.Cells["dgvOrderID"].Value != null  &&
                    row.Cells["dgvOrderType"].Value != null && row.Cells["dgvStatus"].Value != null)
                {
                    string orderID = row.Cells["dgvOrderID"].Value.ToString().ToLower();                 
                    string orderType = row.Cells["dgvOrderType"].Value.ToString().ToLower();
                    string status = row.Cells["dgvStatus"].Value.ToString().ToLower();

                    row.Visible = orderID.Contains(searchValue) || 
                                  orderType.Contains(searchValue) || status.Contains(searchValue);
                }
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            guna2HtmlLabel1.Text = LocalizationHelper.GetString("guna2HtmlLabel1");
            guna2HtmlLabel2.Text = LocalizationHelper.GetString("guna2HtmlLabel2");

            dgvBill.Columns["dgvOrderID"].HeaderText = LocalizationHelper.GetString("dgvOrderID");
            dgvBill.Columns["dgvOrderType"].HeaderText = LocalizationHelper.GetString("dgvOrderType");
            dgvBill.Columns["dgvStatus"].HeaderText = LocalizationHelper.GetString("dgvStatus");
            dgvBill.Columns["dgvTotal"].HeaderText = LocalizationHelper.GetString("dgvTotal");

        }
    }
}
