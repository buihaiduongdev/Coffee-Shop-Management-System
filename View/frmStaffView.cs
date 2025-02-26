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

namespace Restaurant_Management_System.View
{
    public partial class frmStaffView : SampleView
    {
        public frmStaffView()
        {
            InitializeComponent();
        }

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
                FROM Employees"; 

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
                    dgvEmployee.Rows[i].Cells["dgvSalary"].Value = dt.Rows[i]["Salary"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaffAdd frm = new frmStaffAdd("");
            frm.ShowDialog();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
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





        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dvgedit")
            //{
            //    frmStaffAdd frm = new frmStaffAdd();
            //    frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dvgid"].Value);
            //    frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dvgName"].Value);
            //    frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dvgPhone"].Value);
            //    frm.cbRole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dvgRole"].Value);
            //    frm.ShowDialog();
            //    GetData();
            //}
            //if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dvgdel")
            //{
            //    //đưa ra thông báo có Xóa hay không
            //    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            //    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            //    if (Guna2MessageDialog1.Show("Bạn có muốn xóa không?") == DialogResult.Yes)
            //    {
            //        int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dvgid"].Value);
            //        string qry = "Delete from staff where staffID= " + id + "";
            //        Hashtable ht = new Hashtable();
            //        MainClass.SQl(qry, ht);

            //        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            //        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            //        guna2MessageDialog1.Show("Deleted successfully...");
            //        GetData();
            //    }
            //}
            //Chưa có file BE MainClass
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

                        // Gán dữ liệu từ database vào các TextBox trên form
                        frm.txtEmployeeID.Text = row["EmployeeID"].ToString();
                        frm.txtEmployeeID.Enabled = false; // Không cho sửa EmployeeID
                        frm.txtFirstName.Text = row["FirstName"].ToString();
                        frm.txtLastName.Text = row["LastName"].ToString();
                        frm.txtUserName.Text = row["Username"].ToString();
                        frm.txtUserName.Enabled = false;
                        frm.txtPassword.Text = row["Password"].ToString();
                        frm.txtPhone.Text = row["Phone"].ToString();
                        frm.cbRole.SelectedItem = row["Role"].ToString();
                        frm.txtSalary.Text = row["Salary"].ToString();

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
                        string deleteQuery = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
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


    }
}
