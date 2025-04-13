using Restaurant_Management_System.Backend;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class frmDetailInfo : Form
    {
        int orderDetailID;

        public frmDetailInfo(int orderDetailID)
        {
            InitializeComponent();
            this.orderDetailID = orderDetailID;
        }

        public void LoadOrderDetail(int orderDetailID)
        {
            try
            {
                // Corrected query with proper table name [Order Details] and schema [dbo]
                string query = @"SELECT [OrderDetailID], [ProductID], [UnitPrice], [Quantity], 
                                       [Ice], [Sugar], [Size]
                                FROM [CoffeeShopDB].[dbo].[Order Details]
                                WHERE [OrderDetailID] = @OrderDetailID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@OrderDetailID", orderDetailID)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng.");
                    return;
                }

                DataRow row = dt.Rows[0];

                orderdetailInfo order = new orderdetailInfo()
                {
                    OrderDetailID = Convert.ToInt32(row["OrderDetailID"]),
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Ice = row["Ice"].ToString(),
                    Sugar = row["Sugar"].ToString(),
                    Size = row["Size"].ToString()
                };

                ucDetail detail = new ucDetail();
                detail.Dock = DockStyle.Fill;
                detail.SetData(order);
                this.Controls.Clear();
                this.Controls.Add(detail);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL: {ex.Message}\nVui lòng kiểm tra kết nối cơ sở dữ liệu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void frmDetailInfo_Load(object sender, EventArgs e)
        {
            LoadOrderDetail(orderDetailID);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}