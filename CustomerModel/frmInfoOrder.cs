using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class frmInfoOrder : Form
    {
        int customerID;
        public frmInfoOrder(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
         );
        private void borderRadius(int radius = 60)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                // Thêm các cung tròn vào path
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);                      // Góc trên trái
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);         // Góc trên phải
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);   // Góc dưới phải
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);         // Góc dưới trái
                path.CloseFigure();// Gán region cho Form
                this.Region = new Region(path);
            }
        }
        private void frmInfoOrder_Load(object sender, EventArgs e)
        {
            borderRadius();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucConfirm3_Load(object sender, EventArgs e)
        {

        }

        private void LoadData(string statusFilter, string buttonLabel)
        {
            string query = @"SELECT o.OrderID, o.OrderDay, o.Status
                     FROM Orders AS o
                     WHERE CustomerID = @CustomerID";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@CustomerID", customerID)
            };



            if (statusFilter != "Tất cả")
            {
                query += " AND o.Status = @Status";
                parameters.Add(new SqlParameter("@Status", statusFilter));
            }
            query += " ORDER BY o.OrderDay DESC";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());

            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                orderInfo order = new orderInfo()
                {
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    Orderdate = Convert.ToDateTime(row["OrderDay"]),
                    Status = row["Status"].ToString()
                };

                ucConfirm confirm = new ucConfirm();
                confirm.SetData(order);
                confirm.SetButtonLabel(buttonLabel);
                flowLayoutPanel1.Controls.Add(confirm);
            }
        }


        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadData("Tất cả", "Đơn hàng");
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData("Rejected", "");
        }

        private void btnFeedback_Click(object sender, EventArgs e) { 
    
            LoadData("Received", "Đánh giá");

        }

        private void btnWaitConfirm_Click(object sender, EventArgs e)
        {
            LoadData("Pending", "Hủy đơn");
        }

        private void btnConfirmed_Click(object sender, EventArgs e)
        {
            LoadData("Confirmed", "Nhận hàng");
        }


    }
}
