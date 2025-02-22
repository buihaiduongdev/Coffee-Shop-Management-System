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
        public frmStaffAdd()
        {
            InitializeComponent();
        }
        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
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
                // Gọi ExecuteNonQuery và lấy số dòng bị ảnh hưởng
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                // Kiểm tra số dòng bị ảnh hưởng và kích hoạt hành động
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
                // Bắt lỗi và hiển thị thông báo
                MessageBox.Show("Lỗi khi thực thi câu lệnh SQL: " + ex.Message);
            }
        }

        private void frmStaffAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
