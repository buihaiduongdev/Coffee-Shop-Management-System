using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant_Management_System.Model;

namespace Restaurant_Management_System.Barista
{
    public partial class frmBarista : Form
    {
        public frmBarista()
        {
            InitializeComponent();
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
            AddControls(new frmKitchen());
        }
    }
}
