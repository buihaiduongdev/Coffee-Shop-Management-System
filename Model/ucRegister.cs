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
            register();
        }

        private void btnSwitchToLogin2_Click(object sender, EventArgs e)
        {
            OnSwitchToLogin?.Invoke();
        }

        private void register()
        {
            string username = txtUsername.Text;
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            string password = txtPassword.Text;
            string phone = txtPhone.Text;


            if (username.Contains("NV"))
            {
                MessageBox.Show("Tài khoản này đã tồn tại.");
                return;
            }

            string checkQuery = "SELECT COUNT(*) FROM Customers WHERE Username = @username";
            SqlParameter[] checkParams = new SqlParameter[]
            {
                new SqlParameter("@username", username)
            };
             
            int userExists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

            if (userExists > 0)
            {
                MessageBox.Show("Tài khoản đã tồn tại.");
                return;
            }

            // Nếu tài khoản chưa tồn tại, thực hiện thêm vào bảng Customers
            string insertQuery = "INSERT INTO Customers (Username, FirstName, LastName, Password, Phone) " +
                            "VALUES (@username, @firstName, @lastName, @password, @phone)";
            SqlParameter[] insertParams = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@firstName", firstName),
                new SqlParameter("@lastName", lastName),
                new SqlParameter("@password", password),
                new SqlParameter("@phone", phone)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Đăng ký thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại.");
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
