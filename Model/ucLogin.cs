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

        public bool PasswordChar { get; internal set; }

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
                 Employee emp = AccountDAO.CheckEmployeeLogin(username, password);

                if (emp != null)
                {
                    this.Hide();

                    if (emp.Role == "Manager")
                    {
                        frmMain f = new frmMain(emp);
                        f.ShowDialog();
                    }
                    else if (emp.Role == "Barista")
                    {
                        frmBarista b = new frmBarista(emp); 
                        b.ShowDialog();
                    }
                    else if (emp.Role == "Receptionist")
                    {
                        frmReceptionist b = new frmReceptionist(emp);
                        b.ShowDialog();
                    }
                    this.Show();
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
                }
            }
            else
            {

                CustomerInfo cus = AccountDAO.CheckCustomerLogin(username, password);
                if (cus != null)
                {
                    this.Hide();
                    frmCustomer f = new frmCustomer(cus); // truyền Customer
                    f.ShowDialog();
                    this.Show();

                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
                }
            }
        }

    }
}
