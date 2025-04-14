//// CustomerModel/frmDetailInfo.cs
//using Restaurant_Management_System.Backend;
////using Restaurant_Management_System.Models;
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace Restaurant_Management_System.CustomerModel
//{
//    public partial class frmDetailInfo : Form
//    {
//        private readonly int _orderDetailID;

//        public frmDetailInfo(int orderDetailID)
//        {
//            InitializeComponent();
//            _orderDetailID = orderDetailID;
//            this.StartPosition = FormStartPosition.CenterScreen;
//            this.Text = $"Chi tiết đơn hàng #{orderDetailID}";
//        }

//        private void frmDetailInfo_Load(object sender, EventArgs e)
//        {
//            LoadOrderDetail(_orderDetailID);
//        }

//        public void LoadOrderDetail(int orderDetailID)
//        {
//            try
//            {
//                string query = @"
//                SELECT 
//                    od.OrderDetailID, od.OrderID, od.ProductID, od.UnitPrice, 
//                    od.Quantity, od.Ice, od.Sugar, od.Size, 
//                    p.ProductName, p.CategoryName, p.Image as ProductImage
//                FROM [Order Details] od
//                INNER JOIN Orders o ON od.OrderID = o.OrderID
//                INNER JOIN Products p ON od.ProductID = p.ProductID
//                WHERE od.OrderDetailID = @OrderDetailID";

//                SqlParameter[] parameters = { new SqlParameter("@OrderDetailID", orderDetailID) };

//                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

//                if (dt.Rows.Count == 0)
//                {
//                    MessageBox.Show("Không tìm thấy chi tiết đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    this.Close();
//                    return;
//                }

//                var detail = new OrderDetailProduct
//                {
//                    OrderDetailID = Convert.ToInt32(dt.Rows[0]["OrderDetailID"]),
//                    OrderID = Convert.ToInt32(dt.Rows[0]["OrderID"]),
//                    ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]),
//                    UnitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]),
//                    Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]),
//                    Ice = dt.Rows[0]["Ice"].ToString(),
//                    Sugar = dt.Rows[0]["Sugar"].ToString(),
//                    Size = dt.Rows[0]["Size"].ToString(),
//                   // OrderDate = Convert.ToDateTime(dt.Rows[0]["OrderDate"]),
//                    ProductName = dt.Rows[0]["ProductName"].ToString(),
//                    CategoryName = dt.Rows[0]["CategoryName"].ToString(),
//                    ProductImage = dt.Rows[0]["ProductImage"] as byte[]
//                };

//                var ucDetail = new ucDetail();
//                ucDetail.Dock = DockStyle.Fill;
//                ucDetail.SetData(detail);

//                this.Controls.Clear();
//                this.Controls.Add(ucDetail);
//            }
//            catch (SqlException ex)
//            {
//                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                this.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                this.Close();
//            }
//        }
//    }
//}
// CustomerModel/frmDetailInfo.cs
using Restaurant_Management_System.Backend;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class frmDetailInfo : Form
    {
        private readonly int _orderId;

        public frmDetailInfo(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = $"Chi tiết đơn hàng #{orderId}";
        }

        private void frmDetailInfo_Load(object sender, EventArgs e)
        {
            LoadOrderDetails(_orderId);
        }
        public void LoadOrderDetails(int orderId)
        {
            try
            {
                string query = @"
        SELECT 
            od.OrderDetailID, od.OrderID, od.ProductID, od.UnitPrice, 
            od.Quantity, od.Ice, od.Sugar, od.Size, 
            p.ProductName, p.CategoryName, p.Image as ProductImage
        FROM [Order Details] od
        INNER JOIN Orders o ON od.OrderID = o.OrderID
        INNER JOIN Products p ON od.ProductID = p.ProductID
        WHERE od.OrderID = @OrderID
        ORDER BY od.OrderDetailID";

                SqlParameter[] parameters = { new SqlParameter("@OrderID", orderId) };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                var orderDetails = new List<OrderDetailProduct>();

                foreach (DataRow row in dt.Rows)
                {
                    orderDetails.Add(new OrderDetailProduct
                    {
                        OrderDetailID = Convert.ToInt32(row["OrderDetailID"]),
                        OrderID = Convert.ToInt32(row["OrderID"]),
                        ProductID = Convert.ToInt32(row["ProductID"]),
                        UnitPrice = row["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(row["UnitPrice"]) : 0m,
                        Quantity = row["Quantity"] != DBNull.Value ? Convert.ToInt32(row["Quantity"]) : 0,
                        Ice = row["Ice"] != DBNull.Value ? row["Ice"].ToString() : "N/A",
                        Sugar = row["Sugar"] != DBNull.Value ? row["Sugar"].ToString() : "N/A",
                        Size = row["Size"] != DBNull.Value ? row["Size"].ToString() : "N/A",

                        ProductName = row["ProductName"] != DBNull.Value ? row["ProductName"].ToString() : "Unknown",
                        CategoryName = row["CategoryName"] != DBNull.Value ? row["CategoryName"].ToString() : "Unknown",
                        ProductImage = row["ProductImage"] as byte[],

                    });
                }

                MessageBox.Show($"Số chi tiết đơn hàng: {orderDetails.Count}", "Debug");

                var ucDetail = new ucDetail();
                ucDetail.Dock = DockStyle.Fill;
                ucDetail.SetData(orderDetails, orderId);

                this.Controls.Clear();
                this.Controls.Add(ucDetail);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu:\n{ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi:\n{ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


    }
}