using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Barista;
using Restaurant_Management_System.Customer;
using Restaurant_Management_System.Receptionist;
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
    public partial class ucLogin : UserControl
    {
        public ucLogin()
        {
            InitializeComponent();
        }
        public event Action OnSwitchToRegister;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btnSwitchToRegister_Click(object sender, EventArgs e)
        {
            OnSwitchToRegister?.Invoke();
        }


        private void login()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            // Kiểm tra nếu 2 ký tự đầu của username là 'NV'
            if (username.Length >= 2 && username.Substring(0, 2)== "NV")
            {
                // Kiểm tra trong bảng Employees
                string query = "SELECT Role FROM Employees WHERE Username = @username AND Password = @password";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password)
                };

                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                if (result != null)
                {
                    string role = result.ToString();

                    // Kiểm tra role và mở form tương ứng
                    if (role == "Manager")
                    {
                        frmMain managerForm = new frmMain();
                        managerForm.Show();
                    }
                    else if (role == "Barista")
                    {
                        frmBarista baristaForm = new frmBarista();
                        baristaForm.Show();
                    }
                    else if (role == "Receptionist")
                    {
                        frmReceptionist receptionistForm = new frmReceptionist();
                        receptionistForm.Show();
                    }

                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
                }
            }
            else
            {
                
                string query = "SELECT * FROM Customers WHERE Username = @username AND Password = @password";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                int row = dt.Rows.Count;
                if (row == 1)
                {
                    // Nếu tìm thấy khách hàng
                    frmCustomer customerForm = new frmCustomer();
                    customerForm.Show();
                    this.Hide(); // Ẩn form đăng nhập
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
                }
            }
        }

    }
}
