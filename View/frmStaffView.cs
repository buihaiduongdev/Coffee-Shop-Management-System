using Guna.UI2.WinForms;
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
using OfficeOpenXml;
using System.IO;
using System.Globalization;

namespace Restaurant_Management_System.View
{
    public partial class frmStaffView : Form
    {
        public frmStaffView()
        {
            InitializeComponent();
        }

        Color ButtonEnabled = Color.CornflowerBlue;
        Color ButtonDisable = Color.Silver;

        private void frmStaffView_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }
        private void LoadEmployeeData()
        {
            string query = @"
                SELECT EmployeeID, 
                       (FirstName + ' ' + LastName) AS FullName, 
                       Phone, 
                       Role, 
                       Salary
                FROM Employees WHERE IsDeleted = 0"; 

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                dgvEmployee.Rows.Clear();
                dgvEmployee.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvEmployee.Rows.Add();
                    dgvEmployee.Rows[i].Cells["dgvSno"].Value = i + 1; // STT tự động tăng
                    dgvEmployee.Rows[i].Cells["dgvEmployeeID"].Value = dt.Rows[i]["EmployeeID"];
                    dgvEmployee.Rows[i].Cells["dgvFullName"].Value = dt.Rows[i]["FullName"];
                    dgvEmployee.Rows[i].Cells["dgvPhone"].Value = dt.Rows[i]["Phone"];
                    dgvEmployee.Rows[i].Cells["dgvRole"].Value = dt.Rows[i]["Role"];
                    dgvEmployee.Rows[i].Cells["dgvSalary"].Value = string.Format(new CultureInfo("vi-VN"), "{0:#,0}", dt.Rows[i]["Salary"]);
                }
                lblNumberEmployee.Text = $"Employee [{dt.Rows.Count}]";
                dgvEmployee.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadEmployeeDataSplitRole(string role)
        {
            string query = $@"
                SELECT EmployeeID, 
                       (FirstName + ' ' + LastName) AS FullName, 
                       Phone, 
                       Role, 
                       Salary
                FROM Employees WHERE Role = '{role}' AND IsDeleted = 0";
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                dgvEmployee.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvEmployee.Rows.Add();
                    dgvEmployee.Rows[i].Cells["dgvSno"].Value = i + 1; // STT tự động tăng
                    dgvEmployee.Rows[i].Cells["dgvEmployeeID"].Value = dt.Rows[i]["EmployeeID"];
                    dgvEmployee.Rows[i].Cells["dgvFullName"].Value = dt.Rows[i]["FullName"];
                    dgvEmployee.Rows[i].Cells["dgvPhone"].Value = dt.Rows[i]["Phone"];
                    dgvEmployee.Rows[i].Cells["dgvRole"].Value = dt.Rows[i]["Role"];
                    dgvEmployee.Rows[i].Cells["dgvSalary"].Value = string.Format(new CultureInfo("vi-VN"), "{0:#,0}", dt.Rows[i]["Salary"]);
                }
                lblNumberEmployee.Text = $"Employee [{dgvEmployee.RowCount}]";
                dgvEmployee.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        public void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaffAdd frm = new frmStaffAdd("");
            frm.ShowDialog();
        }

        public void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvEmployee.Rows)
            {
                if (row.Cells["dgvEmployeeID"].Value != null && row.Cells["dgvFullName"].Value != null &&
                    row.Cells["dgvPhone"].Value != null && row.Cells["dgvRole"].Value != null)
                {
                    string id = row.Cells["dgvEmployeeID"].Value.ToString().ToLower();
                    string name = row.Cells["dgvFullName"].Value.ToString().ToLower();
                    string phone = row.Cells["dgvPhone"].Value.ToString().ToLower();
                    string role = row.Cells["dgvRole"].Value.ToString().ToLower();

                    row.Visible = id.Contains(searchValue) || name.Contains(searchValue) ||
                                  phone.Contains(searchValue) || role.Contains(searchValue);
                }
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào Header
            {
                // Xử lý khi bấm vào nút chỉnh sửa (dgvedit)
                if (e.ColumnIndex == dgvEmployee.Columns["dgvedit"].Index)
                {
                    string employeeID = dgvEmployee.Rows[e.RowIndex].Cells["dgvEmployeeID"].Value.ToString();

                    // Lấy dữ liệu từ DB
                    string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";
                    SqlParameter[] param = { new SqlParameter("@EmployeeID", employeeID) };
                    DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        frmStaffAdd frm = new frmStaffAdd(employeeID);

                        frm.txtFirstName.Text = row["FirstName"].ToString();
                        frm.txtLastName.Text = row["LastName"].ToString();
                        frm.txtUserName.Text = row["Username"].ToString();
                        frm.txtUserName.Enabled = false;
                        frm.txtPassword.Text = row["Password"].ToString();
                        frm.txtPhone.Text = row["Phone"].ToString();
                        frm.cbRole.SelectedItem = row["Role"].ToString();
                        frm.txtSalary.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,0}", row["Salary"]);
                        frm.ShowDialog();
                        LoadEmployeeData(); // Cập nhật lại danh sách nhân viên sau khi chỉnh sửa
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Xử lý khi bấm vào nút xóa (dgvdel)
                if (e.ColumnIndex == dgvEmployee.Columns["dgvdel"].Index)
                {
                    string employeeID = dgvEmployee.Rows[e.RowIndex].Cells["dgvEmployeeID"].Value.ToString();
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {employeeID}?",
                                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "UPDATE Employees SET IsDeleted = 1 WHERE EmployeeID = @EmployeeID";
                        SqlParameter[] param = { new SqlParameter("@EmployeeID", employeeID) };

                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(deleteQuery, param);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Đã xóa nhân viên {employeeID} thành công!");
                            LoadEmployeeData(); // Cập nhật lại danh sách nhân viên
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa nhân viên!");
                        }
                    }
                }
            }
        }

        private void btnAllPeople_Click(object sender, EventArgs e)
        {
            btnAllPeople.FillColor = ButtonEnabled;
            btnAllPeople.BorderColor = ButtonEnabled;
            btnManager.FillColor = ButtonDisable;
            btnManager.BorderColor = ButtonDisable;
            btnReceptionist.FillColor = ButtonDisable;
            btnReceptionist.BorderColor = ButtonDisable;
            btnWaiter.FillColor = ButtonDisable;
            btnWaiter.BorderColor = ButtonDisable;
            LoadEmployeeData();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            btnManager.FillColor = ButtonEnabled;
            btnManager.BorderColor = ButtonEnabled;
            btnAllPeople.FillColor = ButtonDisable;
            btnAllPeople.BorderColor = ButtonDisable;
            btnReceptionist.FillColor = ButtonDisable;
            btnReceptionist.BorderColor = ButtonDisable;
            btnWaiter.FillColor = ButtonDisable;
            btnWaiter.BorderColor = ButtonDisable;
            btnBarista.FillColor = ButtonDisable;
            btnBarista.BorderColor = ButtonDisable;
            LoadEmployeeDataSplitRole(btnManager.Text);

        }

        private void btnReceptionist_Click(object sender, EventArgs e)
        {
            btnReceptionist.FillColor = ButtonEnabled;
            btnReceptionist.BorderColor = ButtonEnabled;
            btnAllPeople.FillColor = ButtonDisable;
            btnAllPeople.BorderColor = ButtonDisable;
            btnManager.FillColor = ButtonDisable;
            btnManager.BorderColor = ButtonDisable;
            btnWaiter.FillColor = ButtonDisable;
            btnWaiter.BorderColor = ButtonDisable;
            btnBarista.FillColor = ButtonDisable;
            btnBarista.BorderColor = ButtonDisable;
            LoadEmployeeDataSplitRole(btnReceptionist.Text);
        }

        private void btnBarista_Click(object sender, EventArgs e)
        {
            btnBarista.FillColor = ButtonEnabled;
            btnBarista.BorderColor = ButtonEnabled;
            btnAllPeople.FillColor = ButtonDisable;
            btnAllPeople.BorderColor = ButtonDisable;
            btnManager.FillColor = ButtonDisable;
            btnManager.BorderColor = ButtonDisable;
            btnWaiter.FillColor = ButtonDisable;
            btnWaiter.BorderColor = ButtonDisable;
            btnReceptionist.FillColor = ButtonDisable;
            btnReceptionist.BorderColor = ButtonDisable;
            LoadEmployeeDataSplitRole(btnBarista.Text);
        }

        private void btnWaiter_Click(object sender, EventArgs e)
        {
            btnWaiter.FillColor = ButtonEnabled;
            btnWaiter.BorderColor = ButtonEnabled;
            btnAllPeople.FillColor = ButtonDisable;
            btnAllPeople.BorderColor = ButtonDisable;
            btnManager.FillColor = ButtonDisable;
            btnManager.BorderColor = ButtonDisable;
            btnBarista.FillColor = ButtonDisable;
            btnBarista.BorderColor = ButtonDisable;
            btnReceptionist.FillColor = ButtonDisable;
            btnReceptionist.BorderColor = ButtonDisable;
            LoadEmployeeDataSplitRole(btnWaiter.Text);
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Excel File |*.xlsx";
                save.Title = "Chọn nơi lưu file Excel";
                save.FileName = "employee.xlsx";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.License.SetNonCommercialPersonal("Hello");
                        using (ExcelPackage pack = new ExcelPackage())
                        {
                            var ws = pack.Workbook.Worksheets.Add("Sheet1");
                            int month = DateTime.Now.Month;
                            ws.Cells[1, 1].Value = $"DANH SÁCH NHÂN VIÊN THÁNG {month}";
                            ws.Cells[1, 1, 1, dgvEmployee.Columns.Count - 1].Merge = true;
                            ws.Cells[1, 1].Style.Font.Size = 20;
                            ws.Cells[1, 1].Style.Font.Bold = true;
                            ws.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            
                            for (int i = 0; i< dgvEmployee.Columns.Count - 2; i++)
                            {
                                ws.Cells[3, i + 1].Value = dgvEmployee.Columns[i].HeaderText;
                            }

                            for (int i=0; i< dgvEmployee.Rows.Count;i++)
                            {
                                for (int j=0; j < dgvEmployee.Columns.Count - 2; j++)
                                {
                                    ws.Cells[i + 3, j + 1].Value = dgvEmployee.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            FileInfo info = new FileInfo(save.FileName);
                            pack.SaveAs(info);
                            MessageBox.Show("Đã xuất Excel thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file excel: " + ex.Message);
                    }

                }
            }
        }
    }
}