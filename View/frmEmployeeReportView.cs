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
    public partial class frmEmployeeReportView : Form
    {
        private Employee manager;
        public frmEmployeeReportView(Employee manager)
        {
            InitializeComponent();
            this.manager = manager;
        }
        private void rpvReport_Load(object sender, EventArgs e)
        {
            string query = @"SELECT * FROM Employees";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            EmployeeReport rpt = new EmployeeReport();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue("ManagerName", "HElloo");
            rpvReport.ReportSource = rpt;
            rpvReport.Refresh();
        }

        private void frmEmployeeReportView_Load(object sender, EventArgs e)
        {

        }
    }
}
