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
    /// <summary>
    /// SYS 10: thoi gian UI tu 7:40 -> 12. BE bo qua phan nay
    /// </summary>
    public partial class frmAddCustomer : Form
    {
        public string orderType = "";
        public int driverID = 0;
        public string cusName = "";
        public string cusPhone = "";
        public int mainID = 0;
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            if(orderType == "Take Away")
            {
                //lblDriver.Visible = false;
                cbDriver.Visible = true;
            }

            //string qry = "";
            //MainClass.CBFill(qry, cbDriver);

            if(mainID > 0)
            {
                cbDriver.SelectedValue = driverID;
            }
        }

        private void cbDriver_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
