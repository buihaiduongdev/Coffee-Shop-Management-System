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
using System.Threading.Tasks;

namespace Restaurant_Management_System.Barista
{
    public partial class frmKitchen : Form
    {
        public static frmKitchen FrmKitchen;
        string status = "";
        private Guna2Button previousButton = null;
        private static readonly Font ButtonFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        int baristaID;
        public frmKitchen(int BaristaID)
        {
            InitializeComponent();
            baristaID = BaristaID;
        }

        private void frmKitchen_Load(object sender, EventArgs e)
        {
            FrmKitchen = this;
            flpOrders.Controls.Clear();
            tnPending.Checked = true;
            status = "Pending"; // Đặt trạng thái mặc định là "Pending"
            LoadOrders(status);

            Guna2Button btnTable = new Guna2Button();
            btnTable.Font = ButtonFont;
            btnTable.Text = "ALL";
            btnTable.Tag = "-1";
            btnTable.Size = new Size(150, 50);
            btnTable.FillColor = Color.FromArgb(84, 60, 20);
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
             WHERE IsDeleted = 0
            ";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Guna2Button btnTable = new Guna2Button();
                string tableID = dt.Rows[i]["TableID"].ToString(); // Lấy giá trị ID

                btnTable.Font = ButtonFont;
                btnTable.Text = "Table " + tableID; // Hiển thị trên nút
                btnTable.Tag = tableID; // Gán ID vào Tag
                btnTable.Size = new Size(150, 50);
                btnTable.FillColor = Color.FromArgb(240, 187, 120);
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
                    previousButton.FillColor = Color.FromArgb(240, 187, 120); // Màu ban đầu
                }

                // Cập nhật màu cho nút vừa được nhấn
                clickedButton.FillColor = Color.FromArgb(84, 60, 20); // Màu khi chọn

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
            SELECT O.OrderID, OD.Quantity, O.OrderDay, Pre.PreparationID, Pre.Status, O.status,
                   Pre.StartTime, Pre.EndTime, Pre.TableID, p.ProductName
            FROM Orders as O
            JOIN [Order Details] OD ON O.OrderID = OD.OrderID
            JOIN Preparations as Pre ON Pre.PreparationID = OD.OrderDetailID
            JOIN Products P ON P.ProductID = OD.ProductID
            WHERE Pre.Status = @StatusFilter AND Pre.StartTime BETWEEN DATEADD(HOUR, -2, GETDATE()) AND GETDATE() AND O.status = 'Confirmed'
             ";
            // lấy 2 tiếng trước thôiiiii
          List<SqlParameter> parameters = new List<SqlParameter>
          {
            new SqlParameter("@StatusFilter", statusFilter)
          };

            if (tableID != -1)
            {
                query += " AND Pre.TableID = @TableID";
                parameters.Add(new SqlParameter("@TableID", tableID));
            }

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());


            flpOrders.SuspendLayout();
            flpOrders.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int preparationID = Convert.ToInt32(row["PreparationID"]);
                string name = row["ProductName"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);
                string orderID = row["OrderID"].ToString();
                string status = row["Status"].ToString();
                DateTime orderTime = Convert.ToDateTime(row["OrderDay"]);

                TimeSpan elapsed = DateTime.Now - orderTime;

                ucKitchen orderControl = new ucKitchen(preparationID, name, orderID, quantity, status, elapsed, baristaID);
                orderControl.Size = new Size(150, 200);
                orderControl.RefreshOrders = () => LoadOrders(statusFilter);

                flpOrders.Controls.Add(orderControl);
            }

            flpOrders.ResumeLayout();
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
