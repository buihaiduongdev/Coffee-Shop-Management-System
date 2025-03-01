using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

using Restaurant_Management_System.Backend;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Restaurant_Management_System.Barista
{
    public partial class frmKitchen : Form
    {
        public frmKitchen()
        {
            InitializeComponent();
        }

        private void frmKitchen_Load(object sender, EventArgs e)
        {
            flpOrders.Controls.Clear();
            LoadOrders("Pending");
        }

        public void LoadOrders(string statusFilter)
        {
            string query = @"
            SELECT O.OrderID, O.OrderDay, Pre.PreparationID, Pre.Status, Pre.StartTime, Pre.EndTime, Pre.TableID, p.ProductName
            FROM Orders as O
            INNER JOIN Preparations Pre ON O.OrderID = Pre.OrderID
            INNER JOIN Products P ON Pre.ProductID = P.ProductID
            WHERE Pre.Status = @StatusFilter
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@StatusFilter", statusFilter)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            flpOrders.Controls.Clear(); // Xóa các order cũ trước khi load mới

            foreach (DataRow row in dt.Rows)
            {
                int preparationID = Convert.ToInt32(row["PreparationID"]);
                string name = row["ProductName"].ToString();
                string status = row["Status"].ToString();
                DateTime orderTime = Convert.ToDateTime(row["OrderDay"]);

                TimeSpan elapsed = DateTime.Now - orderTime; // Tính thời gian chờ

                ucKitchen orderControl = new ucKitchen(preparationID, name, status, elapsed);
                orderControl.RefreshOrders = () => LoadOrders(statusFilter); // Gán delegate

                flpOrders.Controls.Add(orderControl);
            }
        }


        private void btnCompleted_Click(object sender, EventArgs e)
        {
            LoadOrders("Completed");

        }

        private void tnPending_Click(object sender, EventArgs e)
        {
            LoadOrders("Pending");

        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            LoadOrders("Processing");

        }
    }
}
