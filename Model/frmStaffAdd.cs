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
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Restaurant_Management_System.Model
{
    public partial class frmStaffAdd : Form
    {
        private string language = ucLogin.languages;
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
            string username = "NV" + txtUsername.Text;
            string password = txtPassword.Text;
            string phone = txtPhone.Text;
            string role = cbRole.SelectedItem.ToString();
            if (language == "vi") role = role == "Quản lý" ? "Manager" : role == "Pha chế" ? "Barista" : role == "Tiếp tân" ? "Receptionist" : role == "Phục vụ" ? "Waiter " : "";
            string Strsalary = txtSalary.Text;

            String query = "INSERT INTO Employees(Username, Password, LastName, FirstName, Phone, Role, Salary) " +
                    "VALUES(@Username, @Password, @LastName, @FirstName, @Phone, @Role, @Salary)";


            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(role) ||
                string.IsNullOrEmpty(txtSalary.Text))
            {
                throw new Exception("Lỗi nhập liệu! Vui lòng nhập đầy đủ thông tin nhân viên!");
            }

            if (!decimal.TryParse(txtSalary.Text, out decimal salary) || salary < 0)
            {
                throw new Exception("Lỗi nhập liệu! Lương nhân viên không hợp lệ!");
            }

            SqlParameter[] parameters = new SqlParameter[]
{
            new SqlParameter("@Username", username),
            new SqlParameter("@Password", password),
            new SqlParameter("@LastName", lastName),
            new SqlParameter("@FirstName", firstName),
            new SqlParameter("@Phone", phone),
           // new SqlParameter("@Image", DBNull.Value),
            new SqlParameter("@Role", role),
            new SqlParameter("@Salary", salary)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                if (language == "en") MessageBox.Show("Employee added successfully!", "Notification");
                else MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
            }
            else
            {
                if (language == "en")  MessageBox.Show("No change were made.", "Notification");
                else MessageBox.Show("Không có thay đổi nào được thực hiện.", "Thông báo");
            }
        }
        private void UpdateEmployee(string employeeID)
        {
            // Lấy dữ liệu từ form
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string username = txtUsername.Text.Trim();
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
                if (language == "en")
                {
                    throw new Exception("Input error! Please enter full information!");
                }
                else
                {
                    throw new Exception("Lỗi nhập liệu! Vui lòng nhập đầy đủ thông tin nhân viên!");
                }
            }

            if (!decimal.TryParse(strSalary, out decimal salary) || salary < 0)
            {
                if (language == "en")
                {
                    throw new Exception("Input error! Salary is not valid!");
                }
                else
                {
                    throw new Exception("Lỗi nhập liệu! Lương nhân viên không hợp lệ!");
                }
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
                if (language == "en")
                {
                    MessageBox.Show("Employee information has been updated successfully!","Notification");
                }
                else
                {
                    MessageBox.Show("Thông tin nhân viên đã được cập nhật thành công!","Thông báo");
                }
                this.Close();
            }
            else
            {
                if (language == "en") MessageBox.Show("No changes were made.","Notification");
                else MessageBox.Show("Không có thay đổi nào được thực hiện.","Thông báo");
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            bool AddStaff = false;
            try
            {
                if (EmployeeID == "")
                {
                    AddStaff = true;
                    InsertEmployee();
                    this.Close();
                }
                else
                {
                    UpdateEmployee(EmployeeID);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (AddStaff)
                {
                    if (language == "en") MessageBox.Show("Error adding employee: " + ex.Message, "Notification");
                    else MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Notification");
                    
                }
                if (language == "en") MessageBox.Show("Error updating employee: " + ex.Message, "Notification");
                else MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Notification");
            }         
        }

        private void frmStaffAdd_Load(object sender, EventArgs e)
        {
            load_language(language);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            lblInfo.Text = LocalizationHelper.GetString("lblInfo");
            lblAccount.Text = LocalizationHelper.GetString("lblAccount");
            lblFirstname.Text = LocalizationHelper.GetString("lblFirstName");
            lblLastName.Text = LocalizationHelper.GetString("lblLastName");
            lblUsername.Text = LocalizationHelper.GetString("lblUsername");
            lblPassword.Text = LocalizationHelper.GetString("lblPassword");
            lblPhone.Text = LocalizationHelper.GetString("lblPhone");
            lblRole.Text = LocalizationHelper.GetString("lblRole");
            lblSalary.Text = LocalizationHelper.GetString("lblSalary");
            btnSave.Text = LocalizationHelper.GetString("btnSave");
            btnClose.Text = LocalizationHelper.GetString("btnClose");
            txtFirstName.PlaceholderText = LocalizationHelper.GetString("txtFirstname2");
            txtLastName.PlaceholderText = LocalizationHelper.GetString("txtLastname2");
            txtPassword.PlaceholderText = LocalizationHelper.GetString("txtPassword2");
            txtPhone.PlaceholderText = LocalizationHelper.GetString("txtPhone2");
            txtUsername.PlaceholderText = LocalizationHelper.GetString("txtUsername2");
        }
    }
}
