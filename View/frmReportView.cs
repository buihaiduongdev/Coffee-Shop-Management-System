using CrystalDecisions.CrystalReports.Engine;
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

namespace Restaurant_Management_System.View
{
    public partial class frmReportView : Form
    {
        private Employee manager;
        private ReportDocument report;
        public frmReportView(Employee manager, ReportDocument report)
        {
            InitializeComponent();
            this.manager = manager;
            this.report = report;
        }
        private void rpvReport_Load(object sender, EventArgs e)
        { 
            rpvReport.ReportSource = report;
            rpvReport.Refresh();
        }

        private void frmEmployeeReportView_Load(object sender, EventArgs e)
        {

        }
    }
}
