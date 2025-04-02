using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using Restaurant_Management_System.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//sửa check state cho icon thành cùng loại màu trắng
namespace Restaurant_Management_System
{
    public partial class frmMain : Form
    {
        private static Panel CenterPanel = new Panel();
        private Employee manager;
        private int id;
        //
        public frmMain(Employee emp)
        {
            InitializeComponent();
            manager = emp;
            id = manager.ID;
        }
        public frmMain(){
            InitializeComponent();
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void AddControls(Form form)
        {
            centerPanel.Controls.Clear();
            form.TopLevel = false;
            centerPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //lbUser.Text = MainClass.USER;
            MenuSlide.Width = 250;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControls(new frmCategoryView());
        }

        private void centerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            AddControls(new frmTableViews());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmProductView());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControls(new frmStaffView());
        }


        private void btnKitchen_Click(object sender, EventArgs e)
        {
            AddControls(new frmKitchenView());
        }


        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (MenuSlide.Width == 250) // Nếu đang mở rộng
            {
                MenuSlide.Width = 85; // Thu nhỏ
            }
            else
            {
                MenuSlide.Width = 250; // Mở rộng
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
