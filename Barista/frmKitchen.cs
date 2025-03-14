using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

using Restaurant_Management_System.Backend;
using System.Collections.Generic;
using System.Data.SqlClient;
using TheArtOfDevHtmlRenderer.Adapters.Entities;
using System.Web.UI.WebControls;
using Guna.UI2.WinForms;

namespace Restaurant_Management_System.Barista
{
    public partial class frmKitchen : Form
    {
        public static frmKitchen FrmKitchen;
        string status = "";
        private Guna2Button previousButton = null;
        public frmKitchen()
        {
            InitializeComponent();
        }

        private void frmKitchen_Load(object sender, EventArgs e)
        {
            FrmKitchen = this;
            flpOrders.Controls.Clear();
            tnPending.Checked = true;
            status = "Pending"; // Đặt trạng thái mặc định là "Pending"
            LoadOrders(status);

            Guna2Button btnTable = new Guna2Button();
            btnTable.Text = "ALL";
            btnTable.Tag = "-1";
            btnTable.Size = new Size(150, 50);
            btnTable.FillColor = Color.Teal;
            btnTable.BorderRadius = 15;
            btnTable.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnTable.Click += BtnTable_Click;
            flpTable.Controls.Add(btnTable);

            loadTable();
            if (flpTable.Controls.Count > 0)
            {
                Guna2Button btnAll = flpTable.Controls[0] as Guna2Button; // Lấy button đầu tiên (ALL)
                if (btnAll != null)
                {
                    btnAll.PerformClick(); // Kích hoạt sự kiện Click
                }
            }
        }

        public void loadTable() {
            string query = @"
             SELECT DISTINCT T.TableID
             FROM Tables as T
             INNER JOIN Preparations Pre ON T.TableID = Pre.TableID
            ";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Guna2Button btnTable = new Guna2Button();
                string tableID = dt.Rows[i]["TableID"].ToString(); // Lấy giá trị ID

                btnTable.Text = "Table " + tableID; // Hiển thị trên nút
                btnTable.Tag = tableID; // Gán ID vào Tag
                btnTable.Size = new Size(150, 50);
                btnTable.FillColor = Color.Teal;
                btnTable.BorderRadius = 15;
                btnTable.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                btnTable.Click += BtnTable_Click;
                flpTable.Controls.Add(btnTable);
            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            if (clickedButton != null)
            {
                // Đổi màu nút trước đó về màu mặc định (nếu có)
                if (previousButton != null && previousButton != clickedButton)
                {
                    previousButton.FillColor = Color.Teal; // Màu ban đầu
                }

                // Cập nhật màu cho nút vừa được nhấn
                clickedButton.FillColor = Color.FromArgb(241, 85, 126); // Màu khi chọn

                // Lưu lại nút đã được nhấn
                previousButton = clickedButton;

                // Chuyển đổi Tag thành ID và tải dữ liệu
                int tableID = Convert.ToInt32(clickedButton.Tag);
                LoadOrders(status, tableID);

            }
        }

        public void LoadOrders(string statusFilter, int tableID = -1)
        {
            string query = @"
            SELECT O.OrderID, OD.Quantity, O.OrderDay, Pre.PreparationID, Pre.Status, Pre.StartTime, Pre.EndTime, Pre.TableID, p.ProductName
            FROM Orders as O
            INNER JOIN Preparations Pre ON O.OrderID = Pre.OrderID
            INNER JOIN Products P ON Pre.ProductID = P.ProductID
            INNER JOIN Tables T ON T.TableID = Pre.TableID
            INNER JOIN Order_Details OD ON O.OrderID = OD.OrderID
            WHERE Pre.Status = @StatusFilter
            ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@StatusFilter", statusFilter)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (tableID != -1) {
            query = @"
            SELECT O.OrderID, OD.Quantity, O.OrderDay, Pre.PreparationID, Pre.Status, Pre.StartTime, Pre.EndTime, Pre.TableID, p.ProductName
            FROM Orders as O
            INNER JOIN Preparations Pre ON O.OrderID = Pre.OrderID
            INNER JOIN Products P ON Pre.ProductID = P.ProductID
            INNER JOIN Tables T ON T.TableID = Pre.TableID
            INNER JOIN Order_Details OD ON O.OrderID = OD.OrderID
            WHERE Pre.Status = @StatusFilter AND Pre.TableID = @TableID
            ";
            parameters = new SqlParameter[]
            {
                 new SqlParameter("@StatusFilter", statusFilter),
                 new SqlParameter("@TableID", tableID)
            };
                dt = DatabaseHelper.ExecuteQuery(query, parameters);
            }
        

            flpOrders.Controls.Clear(); // Xóa các order cũ trước khi load mới

            foreach (DataRow row in dt.Rows)
            {
                int preparationID = Convert.ToInt32(row["PreparationID"]);
                string name = row["ProductName"].ToString();
                int quantity =int.Parse(row["Quantity"].ToString());
                string orderID = row["OrderID"].ToString();
                string status = row["Status"].ToString();
                DateTime orderTime = Convert.ToDateTime(row["OrderDay"]);

                TimeSpan elapsed = DateTime.Now - orderTime; // Tính thời gian chờ

                ucKitchen orderControl = new ucKitchen(preparationID, name, orderID, quantity,status, elapsed);
                orderControl.Size = new Size(150, 200);
                orderControl.RefreshOrders = () => LoadOrders(statusFilter); // Gán delegate
                flpOrders.Controls.Add(orderControl);
            }
        }


        private void btnCompleted_Click(object sender, EventArgs e)
        {
            status = "Completed";
            LoadOrders("Completed");
            

        }

        private void tnPending_Click(object sender, EventArgs e)
        {
            status = "Pending";
            LoadOrders("Pending");
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            status = "Processing";
            LoadOrders("Processing");
        }
    }
}
