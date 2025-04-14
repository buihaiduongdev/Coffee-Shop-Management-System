using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using Restaurant_Management_System.Setting;

namespace Restaurant_Management_System.Barista
{
    public partial class frmBarista : Form
    {
        int baristaID;
        public frmBarista(Employee emp)
        {
            InitializeComponent();
            baristaID = emp.ID;
        }
        public void AddControls(Form form)
        {
            centerPanel.Controls.Clear();
            form.TopLevel = false;
            centerPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        private void btnKitchen_Click(object sender, EventArgs e)
        {
            AddControls(new frmKitchen(baristaID));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmBarista_Load(object sender, EventArgs e)
        {
            AddControls(new frmKitchen(baristaID));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            AddControls(new frmSettingView(baristaID));

        }
    }
}
