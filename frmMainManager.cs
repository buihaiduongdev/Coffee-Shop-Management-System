using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using Restaurant_Management_System.Setting;
using Restaurant_Management_System.View;
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
//sửa check state cho icon thành cùng loại màu trắng
namespace Restaurant_Management_System
{
    public partial class frmMainManager : Form
    {
        private static Panel CenterPanel = new Panel();
        private Employee manager;
        private int id;
        private string language = ucLogin.languages;

        public frmMainManager(Employee emp)
        {
            InitializeComponent();
            manager = emp;
            id = manager.ID;
        }
        public frmMainManager() {
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
            load_language(language);
            //lblTitle.Text = 
            AddControls(new frmHome());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome(manager));
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
            AddControls(new frmTableView());
            btnTable.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            btnTable.CheckedState.Image = global::Restaurant_Management_System.Properties.Resources.store;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmProductView(manager));
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControls(new frmStaffView(manager));
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

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            AddControls(new frmSettingView(id));
        }

        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            btnHome.Text = LocalizationHelper.GetString("btnHome");
            btnCategory.Text = LocalizationHelper.GetString("btnCategory");
            btnProduct.Text = LocalizationHelper.GetString("btnProduct");
            btnSetting.Text = LocalizationHelper.GetString("btnSetting");
            btnStaff.Text = LocalizationHelper.GetString("btnStaff");
            btnTable.Text = LocalizationHelper.GetString("btnTable");
            btnOrder.Text = LocalizationHelper.GetString("btnOrder");
            btnLogout.Text = LocalizationHelper.GetString("btnLogout");
            lblInventory.Text = LocalizationHelper.GetString("lblInventory");
            lblManager.Text = LocalizationHelper.GetString("lblManager");
            lblOverview.Text = LocalizationHelper.GetString("lblOverview");
            lblTitle.Text = LocalizationHelper.GetString("lblTitle");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            AddControls(new frmOrder(id));
        }
    }
}
