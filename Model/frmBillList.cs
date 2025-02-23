using Guna.UI2.WinForms;
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
    public partial class frmBillList : SampleAdd
    {
        public frmBillList()
        {
            InitializeComponent();
        }

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string qry = @"select MainID, TableName, WaiterName, orderType, status, total from
                        where status <> 'Pending'";
            ListBox lb = new ListBox();
            lb.Items.Add(dvgId);
            lb.Items.Add(dvgTable);
            lb.Items.Add(dvgWaiter);
            lb.Items.Add(dvgOrderType);
            lb.Items.Add(dvgStatus);
            lb.Items.Add(dvgTotal);

            //MainClass.LoadData(qry, guna2DataGridView, lb);
           
        }
        public int MainID = 0;
        private void dgvCategory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvCategory.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }
        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (guna2DataGridView2.CurrentCell.OwningColumn.Name == "dvgedit")
            //{
            //    
            //    MainID = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dvgid"].Value);
            //    this.Close();
            //    
            //}
           
            //Chưa có file BE MainClass

        }
        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
