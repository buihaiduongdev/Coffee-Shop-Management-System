using Restaurant_Management_System.Backend;
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

namespace Restaurant_Management_System.Model
{
    public partial class ucRegister : UserControl
    {
        public ucRegister()
        {
            InitializeComponent();
        }
        public event Action OnSwitchToLogin;
        private void btnRegister_Click(object sender, EventArgs e)
        {
            updatePassword();
        }

        private void btnSwitchToLogin2_Click(object sender, EventArgs e)
        {
            OnSwitchToLogin?.Invoke();
        }

        private void updatePassword()
        {
            string username = txtUsername.Text;
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            string newPassword = txtPassword.Text;
            string phone = txtPhone.Text;

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            string checkQuery = @"SELECT COUNT(*) 
                                FROM Employees 
                                WHERE Username = @username 
                                AND LastName = @lastName 
                                AND Phone = @phone
                                AND FirstName = @firstName";

            SqlParameter[] checkParams = {
                new SqlParameter("@username", username),
                new SqlParameter("@lastName", lastName),
                new SqlParameter("@phone", phone),
                new SqlParameter("@firstName", firstName)
            };


            int userExists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

            if (userExists == 0)
            {
                MessageBox.Show("Thông tin xác thực không chính xác!");
                return;
            }


            string updateQuery = @"UPDATE Employees 
                                SET Password = @password 
                                WHERE Username = @username 
                                AND LastName = @lastName 
                                AND Phone = @phone
                                AND FirstName = @firstName";

            SqlParameter[] updateParams = {
                new SqlParameter("@password", newPassword),
                new SqlParameter("@username", username),
                new SqlParameter("@lastName", lastName),
                new SqlParameter("@phone", phone),
                new SqlParameter("@firstName", firstName)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(updateQuery, updateParams);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                OnSwitchToLogin?.Invoke();
            }
            else
            {
                MessageBox.Show("Lỗi hệ thống, vui lòng thử lại!");
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
