using Guna.UI2.WinForms;
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

namespace Restaurant_Management_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string query = 
                "SELECT * " +
                "FROM Employees " +
                "WHERE Username = @username AND Password = @password";


            SqlParameter[] parameters = {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successfull!");
                this.Hide();
                frmMain mainForm = new frmMain();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Please enter user and password.");
                txtPassword.Clear();
                txtPassword.Focus();    
            }
        
            //Guna2MessageDialog guna2MessageDialog = new Guna2MessageDialog();
            //guna2MessageDialog.Show("Please enter user and password");// Chua can giua duoc
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
