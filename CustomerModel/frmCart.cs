using Restaurant_Management_System.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant_Management_System.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;
using Restaurant_Management_System.CustomerModel;

namespace Restaurant_Management_System.Customer
{
    public partial class frmCart : Form
    {
        private int customerID;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
        );

        private void borderRadius()
        {
            int radius = 100; // Độ bo góc tuỳ chỉnh
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

        BindingList<Item> itemList;
        public frmCart(BindingList<Item> cart, int CustomerID)
        {
            InitializeComponent();
            itemList = cart;
            itemList.ListChanged += (s, e) => loadItem();
            customerID = CustomerID;
        }


        private void frmCart_Load(object sender, EventArgs e)
        {

            borderRadius();
            loadItem();
            config();
            loadRows();
        }
        private void loadRows()
        {
            int headerHeight = dgvCart.ColumnHeadersHeight;
            int rowHeight = dgvCart.RowTemplate.Height;
            int rowCount = dgvCart.RowCount;

            dgvCart.Height = headerHeight + rowHeight * Math.Min(rowCount, 7);

            if (rowCount > 7)
            {
                dgvCart.ScrollBars = ScrollBars.Vertical;
                dgvCart.Width = dgvCart.Width + 17;
            }

        }

        private void config()
        {
            dgvCart.AlternatingRowsDefaultCellStyle = null;
            dgvCart.Height = dgvCart.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + dgvCart.ColumnHeadersHeight;
            dgvCart.Columns["colQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void loadItem()
        {
            var rowTotalPrice = new
            {
                ProductID = 0,
                ProductName = "Tổng",
                Price = itemList.Sum(item => item.Product.Price * item.Quantity),
                Quantity = itemList.Sum(item => item.Quantity),
                Ice = "",
                Size = "",
                Sugar = ""
     
            };

            dgvCart.DataSource = itemList.Select(item => new
            {
                ProductID = item.Product.ProductID,
                ProductName = item.Product.ProductName,
                Price = item.Product.Price,
                Quantity = item.Quantity,
                Ice = item.Product.Ice,
                Size = item.Product.Size,
                Sugar = item.Product.Sugar

            }).Append(rowTotalPrice).ToList();

            var totalRow = dgvCart.Rows[dgvCart.Rows.Count - 1];
            totalRow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#804000"); ;
            totalRow.DefaultCellStyle.ForeColor = Color.White;
            totalRow.DefaultCellStyle.Font = new Font("Jetbrains Mono", 13, FontStyle.Bold);

            DataGridViewImageColumn colDelete = (DataGridViewImageColumn)dgvCart.Columns["colDelete"];
            colDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colDelete.DisplayIndex = dgvCart.Columns.Count - 1;
            for (int i = 0; i < dgvCart.Rows.Count; i++) 
            {
                dgvCart.Rows[i].Cells["colDelete"].Value = Properties.Resources.delete;
            }
            dgvCart.ClearSelection();

        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["colDelete"].Index && e.RowIndex >= 0)
            { 
                if (e.RowIndex == itemList.Count)
                {
                    itemList.Clear();
                } else
                {
                    itemList.RemoveAt(e.RowIndex);
                }
            }
            loadItem();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            checkout();
        }
        private string orderType = "TakeAway";
        private string paymentType = "Cash";
        private int? tableID;
        private void checkout()
        {
      
            DateTime currentDateTime = DateTime.Now;
           
            try
            {
                if (tableID != null) {
                    string query = @"UPDATE Tables 
                                    SET status = 'Occupied'
                                    WHERE TableID = @TableID";

                    SqlParameter[] para = { new SqlParameter("@TableID", tableID) };

                    DatabaseHelper.ExecuteNonQuery(query, para);
                            
                }

                string query2 = "INSERT INTO Orders (CustomerID, OrderDay, OrderType, PaymentType) VALUES " +
                    "(@CustomerID, @OrderDay, @OrderType, @PaymentType); SELECT SCOPE_IDENTITY();";
                SqlParameter[] parameters = {
                    new SqlParameter("@CustomerID", customerID),
                    new SqlParameter("@OrderDay", currentDateTime),
                    new SqlParameter("@OrderType", orderType),
                    new SqlParameter("@PaymentType", paymentType)
                    

                };
                object result = DatabaseHelper.ExecuteScalar(query2, parameters);
                int orderID = Convert.ToInt32(result);
                string query3 = "INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Ice, Size, Sugar) " +
                    "VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Ice, @Size, @Sugar); SELECT SCOPE_IDENTITY();";

                string query4 = "INSERT INTO Preparations (PreparationID,Status, TableID) VALUES (@PreparationID,@Status, @TableID)";
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (!row.IsNewRow && row.Cells["colProductName"].Value.ToString() != "Tổng")
                    {
                        int productID = Convert.ToInt32(row.Cells["colProductID"].Value);
                        decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                        int quantity = Convert.ToInt32(row.Cells["colQuantity"].Value);
                        string ice = Convert.ToString(row.Cells["colIce"].Value);
                        string sugar = Convert.ToString(row.Cells["colSugar"].Value);
                        string size = Convert.ToString(row.Cells["colSize"].Value);

                        SqlParameter[] parameters2 = {
                            new SqlParameter("@OrderID", orderID),
                            new SqlParameter("@ProductID", productID),
                            new SqlParameter("@UnitPrice", price),
                            new SqlParameter("@Quantity", quantity),
                            new SqlParameter("@Ice", ice),
                            new SqlParameter("@Size", size),
                            new SqlParameter("@Sugar", sugar)
                        };
                        object detailResult = DatabaseHelper.ExecuteScalar(query3, parameters2);
                        int orderDetailID = Convert.ToInt32(detailResult);
                        SqlParameter[] parameters3 = {
                            new SqlParameter("@PreparationID", orderDetailID),
                            new SqlParameter("@Status", "Pending"),
                            new SqlParameter("@TableID", (object)tableID ?? DBNull.Value
)
                        };
                        DatabaseHelper.ExecuteNonQuery(query4, parameters3);
                    }
                }
                itemList.Clear();
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gbPaymentMethod_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            btnCard.Enabled = false;
            paymentType = "Cash";
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            btnCash.Enabled = false;
            frmOnlinePayment frmOnlinePayment = new frmOnlinePayment();
            frmOnlinePayment.ShowDialog();

            paymentType = "Online";
        }

        private void btnCash_DoubleClick(object sender, EventArgs e)
        {
            btnCard.Enabled = true;
            
        }

        private void btnCard_DoubleClick(object sender, EventArgs e)
        {
            btnCash.Enabled = true;
        }

        private void btnTackaway_Click(object sender, EventArgs e)
        {
            btnDiveIn.Enabled = false;
            orderType = "TakeAway";
        }

        private void btnTackaway_DoubleClick(object sender, EventArgs e)
        {
            btnDiveIn.Enabled = true;
        }

        private void btnDiveIn_Click(object sender, EventArgs e)
        {
            btnTackaway.Enabled = false;
            frmReserveTable tableForm = new frmReserveTable();




            if (tableForm.ShowDialog() == DialogResult.OK)
            {
                string selectedTable = tableForm.SelectedTableName;
                btnDiveIn.Text = selectedTable;
                orderType = "DineIn";

                string tableIDStr = selectedTable.Replace("Bàn ", "").Trim();
                tableID = Convert.ToInt32(tableIDStr);

                
            }
        }

        private void btnDiveIn_DoubleClick(object sender, EventArgs e)
        {
            btnTackaway.Enabled = true;
        }
    }
}
