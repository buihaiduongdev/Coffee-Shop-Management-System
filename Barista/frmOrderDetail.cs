using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.Barista
{
    public partial class frmOrderDetail : Form
    {
        int PreID = -1;
        public frmOrderDetail(int preID)
        {
            InitializeComponent();
            this.PreID = preID;
        }
    }
}
