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
using Restaurant_Management_System.Backend;
using Restaurant_Management_System.CustomerModel;

namespace Restaurant_Management_System
{
    public partial class frmTableManagement : Form
    {
        public frmTableManagement()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void loadtable()
        {
            string query = @"SELECT * FROM Tables WHERE IsDeleted = 0";
            dt = DatabaseHelper.ExecuteQuery(query);
            flpTablee.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                Table tableData = new Table(
                    Convert.ToInt32(row["TableID"]),
                    Convert.ToInt32(row["Capacity"]),
                    (row["Status"]).ToString()
                );

                var tableUC = new ucTable(tableData);

                tableUC.OnTableSelected += (tableName) =>
                {
                    updateStatus(tableName, "Occupy");
                    loadtable();
                };

                tableUC.OnTableUnselected += (tableName) =>
                {
                    updateStatus(tableName, "Empty");
                    loadtable();
                };


                flpTablee.Controls.Add(tableUC);
            }
        }

        private void updateStatus(string tableName, string newStatus)
        {
            int tableID = int.Parse(tableName.Replace("Bàn ", ""));

            string query = @"UPDATE Tables 
                            SET Status = @Status 
                            WHERE TableID = @TableID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Status", newStatus),
                new SqlParameter("@TableID", tableID)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            if (rowsAffected == 0)
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void frmTableManagement_Load(object sender, EventArgs e)
        {
            loadtable();
        }
    }
}
