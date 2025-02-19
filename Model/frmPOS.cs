using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            dgvPOS.BorderStyle = BorderStyle.FixedSingle;
        }

        //SYS6 23:00
        private void addCategory() { 
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
        //cac ham BE load tu 23p den het video
    }
}
