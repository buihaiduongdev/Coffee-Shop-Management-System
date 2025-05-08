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
using System.Diagnostics.Tracing;

namespace Restaurant_Management_System.View
{
    public partial class frmStaffView : Form
    {
        private string language = ucLogin.languages;
        private Employee manager;
        public frmStaffView(Employee manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        Color ButtonEnabled = Color.FromArgb(255, 192, 128);
        Color ButtonDisable = Color.Silver;
       
        private void ApplyCustomTheme()
        {
            // Xóa theme mặc định
            dgvEmployee.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvEmployee.EnableHeadersVisualStyles = false;

            // Header
            dgvEmployee.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 99, 76);
            dgvEmployee.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEmployee.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmployee.ColumnHeadersHeight = 40;

            // Dòng thường
            dgvEmployee.DefaultCellStyle.BackColor = Color.FromArgb(165, 140, 100); // Be sáng
            dgvEmployee.DefaultCellStyle.ForeColor = Color.Black;
            dgvEmployee.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvEmployee.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224); // Nâu vừa
            dgvEmployee.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEmployee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa

            // Dòng xen kẽ
            dgvEmployee.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 177, 142); // Xám nhạt  

            // Bảng
            dgvEmployee.BackgroundColor = Color.AntiqueWhite;
            dgvEmployee.BorderStyle = BorderStyle.None;
            dgvEmployee.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmployee.RowTemplate.Height = 35;

            // Khác
            dgvEmployee.ReadOnly = false;
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AllowUserToResizeRows = false;
            dgvEmployee.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void frmStaffView_Load(object sender, EventArgs e)
        {
            //FixEditDataGridView();
            ApplyCustomTheme();
            LoadEmployeeData();
            load_language(language);
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
                if (language == "en") lblNumberEmployee.Text = $"Employee [{dt.Rows.Count}]";
                else lblNumberEmployee.Text = $"Nhân viên [{dt.Rows.Count}]";
                dgvEmployee.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                if (language == "en") MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadEmployeeDataSplitRole(string role)
        {
            role =  role == "Pha chế" ? "Barista" : role == "Quản lý" ? "Manager" : role == "Tiếp tân" ? "Receptionist" : role == "Phục vụ" ? "Waiter" : role;
            string query = $@"SELECT EmployeeID, 
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
                if (language == "en") lblNumberEmployee.Text = $"Employee [{dt.Rows.Count}]";
                else lblNumberEmployee.Text = $"Nhân viên [{dgvEmployee.RowCount}]";
                dgvEmployee.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                if (language == "en") MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        public void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaffAdd frm = new frmStaffAdd("");
            frm.cbRole.DataSource = language == "en" ? new List<string>() { "", "Manager", "Barista", "Receptionist", "Waiter" } : new List<string>() { "", "Quản lý", "Pha chế", "Tiếp tân", "Phục vụ" };
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
                        frm.txtUsername.Text = row["Username"].ToString();
                        frm.txtUsername.Enabled = false;
                        frm.txtPassword.Text = row["Password"].ToString();
                        frm.txtPhone.Text = row["Phone"].ToString();
                        frm.txtSalary.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,0}", row["Salary"]);
                        frm.cbRole.DataSource = language == "en" ? new List<string>() { "", "Manager", "Barista", "Receptionist", "Waiter" } : new List<string>() { "", "Quản lý", "Pha chế", "Tiếp tân", "Phục vụ" };
                        string role = row["Role"].ToString();
                        frm.cbRole.SelectedItem = language == "en" ? role : role == "Manager" ? "Quản lý" : role == "Barista" ? "Pha chế" : role == "Receptionist" ? "Tiếp tân" : role == "Waiter" ? "Phục vụ" : "";
                        frm.ShowDialog();
                        LoadEmployeeData(); // Cập nhật lại danh sách nhân viên sau khi chỉnh sửa
                    }
                    else
                    {
                        if (language == "en") MessageBox.Show("Employee not found in the system!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show("Không tìm thấy nhân viên trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            if (language == "en") MessageBox.Show("Error deleting employee!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else MessageBox.Show("Lỗi khi xóa nhân viên!");
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
                if (language == "en") save.Title = "Select where to save the Excel file";
                else save.Title = "Chọn nơi lưu file Excel";
                save.FileName = "employee.xlsx";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.License.SetNonCommercialPersonal("Excel");
                        using (ExcelPackage pack = new ExcelPackage())
                        {
                            var ws = pack.Workbook.Worksheets.Add("Sheet1");
                            int month = DateTime.Now.Month;
                            if (language == "en") ws.Cells[1, 1].Value = $"EMPLOYEE LIST - MONTH {month}";
                            else ws.Cells[1, 1].Value = $"DANH SÁCH NHÂN VIÊN THÁNG {month}";
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
                            if (language == "en") MessageBox.Show("Exported Excel successfully!", "Notification");
                            else MessageBox.Show("Đã xuất Excel thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        if (language == "en") MessageBox.Show("Error exporting Excel: " + ex.Message);
                        else MessageBox.Show("Lỗi xuất file excel: " + ex.Message);
                    }

                }
            }
        }

        private void btnSaveAsReport_Click(object sender, EventArgs e)
        {
            string query = null;
            string role = null;
            {
                if (btnAllPeople.FillColor == ButtonEnabled)
                {
                    query = @"SELECT * FROM Employees WHERE IsDeleted = 0";
                    role = " ";
                }
                else
                {
                    if (btnBarista.FillColor == ButtonEnabled) role = btnBarista.Text;
                    else if (btnManager.FillColor == ButtonEnabled) role = btnManager.Text;
                    else if (btnReceptionist.FillColor == ButtonEnabled) role = btnReceptionist.Text;
                    else if (btnWaiter.FillColor == ButtonEnabled) role = btnWaiter.Text;
                    else role = btnWaiter.Text;
                    query = $@"SELECT * FROM Employees WHERE Role = N'{role}' and IsDeleted = 0";
                }
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                EmployeeReport rpt = new EmployeeReport();
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("ManagerName", manager.LastName + " " + manager.FirstName);
                rpt.SetParameterValue("Role", role);
                frmReportView report = new frmReportView(manager, rpt);
                report.ShowDialog();
            }
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            btnAdd.Text = LocalizationHelper.GetString("btnAddStaff");
            btnAllPeople.Text = LocalizationHelper.GetString("btnAllPeople");
            btnBarista.Text = LocalizationHelper.GetString("btnBarista");
            btnManager.Text = LocalizationHelper.GetString("btnManager");
            btnReceptionist.Text = LocalizationHelper.GetString("btnReceptionist");
            btnSaveAsReport.Text = LocalizationHelper.GetString("btnSaveAsReport");
            btnSaveExcel.Text = LocalizationHelper.GetString("btnSaveExcel");
            btnWaiter.Text = LocalizationHelper.GetString("btnWaiter");
            txtSearch.PlaceholderText = LocalizationHelper.GetString("txtSearch4");
            dgvEmployee.Columns["dgvFullName"].HeaderText = LocalizationHelper.GetString("dgvFullName");
            dgvEmployee.Columns["dgvPhone"].HeaderText = LocalizationHelper.GetString("dgvPhone");
            dgvEmployee.Columns["dgvRole"].HeaderText = LocalizationHelper.GetString("dgvRole");
            dgvEmployee.Columns["dgvPhone"].HeaderText = LocalizationHelper.GetString("dgvPhone");

        }
    }
}