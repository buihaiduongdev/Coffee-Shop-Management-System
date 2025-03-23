using Guna.UI2.WinForms;
using Restaurant_Management_System.Backend;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmBillList : SampleView
    {
        int receptionistID;
        public frmBillList(int ReceptionistID)
        {
            InitializeComponent();
            receptionistID = ReceptionistID;
        }

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string query = @"
                    SELECT o.OrderID, p.TableID, o.OrderType, o.Status, sum(od.Quantity * od.UnitPrice) as Total
                    FROM Orders o
                    JOIN Preparations p
                    ON o.OrderID = p.PreparationID
                    JOIN [Order Details] od
                    ON o.OrderID = od.OrderID
                    Where o.Status = 'Pending'
                    GROUP BY o.OrderID, p.TableID, o.OrderType, o.Status
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
                    dgvBill.Rows[i].Cells["dgvTable"].Value = dt.Rows[i]["TableID"];
                    dgvBill.Rows[i].Cells["dgvOrderType"].Value = dt.Rows[i]["OrderType"];
                    dgvBill.Rows[i].Cells["dgvStatus"].Value = dt.Rows[i]["Status"];
                    dgvBill.Rows[i].Cells["dgvTotal"].Value = dt.Rows[i]["Total"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (row.Cells["dgvOrderID"].Value != null && row.Cells["dgvTable"].Value != null &&
                    row.Cells["dgvOrderType"].Value != null && row.Cells["dgvStatus"].Value != null)
                {
                    string orderID = row.Cells["dgvOrderID"].Value.ToString().ToLower();
                    string table = row.Cells["dgvTable"].Value.ToString().ToLower();
                    string orderType = row.Cells["dgvOrderType"].Value.ToString().ToLower();
                    string status = row.Cells["dgvStatus"].Value.ToString().ToLower();

                    row.Visible = orderID.Contains(searchValue) || table.Contains(searchValue) ||
                                  orderType.Contains(searchValue) || status.Contains(searchValue);
                }
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
