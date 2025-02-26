using Restaurant;
using Restaurant_Management_System.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Restaurant_Management_System.Model
{
    public partial class frmStaffAdd : SampleAdd
    {
        public frmStaffAdd(string employeeID)
        {
            InitializeComponent();
            EmployeeID = employeeID;
        }
        string EmployeeID;
        private void InsertEmployee()
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string employeeID = txtEmployeeID.Text;
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string phone = txtPhone.Text;
            string role = cbRole.SelectedItem.ToString();
            string Strsalary = txtSalary.Text;
            decimal salary = decimal.Parse(txtSalary.Text);

            String query = "INSERT INTO Employees(EmployeeID, Username, Password, LastName, FirstName, Phone, Image, Role, Salary) " +
                   "VALUES(@EmployeeID, @Username, @Password, @LastName, @FirstName, @Phone, @Image, @Role, @Salary)";

            // Tạo các tham số để truyền vào câu lệnh SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID", employeeID),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@Image", DBNull.Value),  // Giá trị NULL cho Image
                new SqlParameter("@Role", role),
                new SqlParameter("@Salary", salary)
            };

            try
            {
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Nhân viên đã được thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi câu lệnh SQL: " + ex.Message);
            }
        }
        private void UpdateEmployee(string employeeID)
        {
            try
            {
                // Lấy dữ liệu từ form
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string username = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string role = cbRole.SelectedItem?.ToString();
                string strSalary = txtSalary.Text.Trim();

                // Kiểm tra dữ liệu nhập hợp lệ
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                    string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(role) ||
                    string.IsNullOrEmpty(strSalary))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(strSalary, out decimal salary) || salary < 0)
                {
                    MessageBox.Show("Lương nhân viên không hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Câu lệnh UPDATE
                string query = @"
                    UPDATE Employees 
                    SET Username = @Username, 
                        Password = @Password, 
                        LastName = @LastName, 
                        FirstName = @FirstName, 
                        Phone = @Phone, 
                        Role = @Role, 
                        Salary = @Salary
                    WHERE EmployeeID = @EmployeeID";

                // Tham số truyền vào SQL
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@EmployeeID", employeeID),
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@LastName", lastName),
                    new SqlParameter("@FirstName", firstName),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@Role", role),
                    new SqlParameter("@Salary", salary)
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thông tin nhân viên đã được cập nhật thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if(EmployeeID =="")
            {
                InsertEmployee();
                this.Close();
            }
            else
            {
                UpdateEmployee(EmployeeID);
                this.Close();
            }
        }

        private void frmStaffAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
