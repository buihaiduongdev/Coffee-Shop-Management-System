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
        public static string languages = "vi";
        public ucLogin()
        {
            InitializeComponent();
           
        }

        public ucLogin(string language)
        {
            InitializeComponent();
            languages = language;
            load_language();
        }

        public bool PasswordChar { get; internal set; }

        public event Action OnSwitchToRegister;
        public event Action OnLoginSuccess;

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

            if (username.Length >= 2 && username.Substring(0, 2) == "NV")
            {
                Employee emp = AccountDAO.CheckEmployeeLogin(username, password);

                if (emp != null)
                {
                    this.Hide();
                    Form mainForm = null;
                    if (emp.Role == "Manager")
                    {
                        mainForm = new frmMainManager(emp);
                    }
                    else if (emp.Role == "Receptionist")
                    {
                        mainForm = new frmMainEmployee(emp);
                    }

                    if (mainForm != null)
                    {
                        mainForm.ShowDialog();
                    }
                    this.Show();
                    OnLoginSuccess?.Invoke();
                }
                else
                {
                    if (languages == "en") MessageBox.Show("Username or password is not correct", "Notification");
                    else MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Thông báo");
                }
            }
            else
            {
                if (languages == "en") MessageBox.Show("Username or password is not correct", "Notification");
                else MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Thông báo");
            }
        }
        private void load_language()
        {
            LocalizationHelper.SetLanguage(languages);
            btnLogin.Text = LocalizationHelper.GetString("btnLogin");
            btnLanguage.Text = LocalizationHelper.GetString("btnLanguage");
            txtUsername.PlaceholderText = LocalizationHelper.GetString("txtUsername");
            txtPassword.PlaceholderText = LocalizationHelper.GetString("txtPassword");
            btnSwitchToRegister.Text = LocalizationHelper.GetString("btnSwitchToRegister");
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            if (!btnLanguage.Checked)
            {
                languages = "en";
                btnLanguage.Checked = true;
                load_language();
            }
            else
            {
                languages = "vi";
                btnLanguage.Checked = false;
                load_language();
            }
        }
    }
}
