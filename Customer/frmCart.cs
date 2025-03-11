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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant_Management_System.Customer
{
    public partial class frmCart : Form
    {

        BindingList<Item> itemList;
        public frmCart(BindingList<Item> cart)
        {
            InitializeComponent();
            itemList = cart;
            itemList.ListChanged += (s, e) => loadItem();
        }


        private void frmCart_Load(object sender, EventArgs e)
        {
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
                Quantity = itemList.Sum(item => item.Quantity)
            };

            dgvCart.DataSource = itemList.Select(item => new
            {
                ProductID = item.Product.ProductID,
                ProductName = item.Product.ProductName,
                Price = item.Product.Price,
                Quantity = item.Quantity
            }).Append(rowTotalPrice).ToList();

            var totalRow = dgvCart.Rows[dgvCart.Rows.Count - 1];
            totalRow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#804000"); ;
            totalRow.DefaultCellStyle.ForeColor = Color.White;
            totalRow.DefaultCellStyle.Font = new Font("Jetbrains Mono", 13, FontStyle.Bold);

            DataGridViewImageColumn colDelete = (DataGridViewImageColumn)dgvCart.Columns["colDelete"];
            colDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
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

        private void checkout()
        {
            DateTime currentDateTime = DateTime.Now;
            string orderType = "Takeaway";
            try
            {
                string query2 = "INSERT INTO Orders (OrderDay, OrderType) VALUES (@OrderDay, @OrderType); SELECT SCOPE_IDENTITY();";
                SqlParameter[] parameters = {
                    new SqlParameter("@OrderDay", currentDateTime),
                    new SqlParameter("@OrderType", orderType)
                };
                object result = DatabaseHelper.ExecuteScalar(query2, parameters);
                int orderID = Convert.ToInt32(result);
                string query3 = "INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity) " +
                    "VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity); SELECT SCOPE_IDENTITY();";

                string query4 = "INSERT INTO Preparations (PreparationID,Status) VALUES (@PreparationID,@Status)";
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (!row.IsNewRow && row.Cells["colProductName"].Value.ToString() != "Tổng")
                    {
                        int productID = Convert.ToInt32(row.Cells["colProductID"].Value);
                        decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                        int quantity = Convert.ToInt32(row.Cells["colQuantity"].Value);
                        SqlParameter[] parameters2 = {
                            new SqlParameter("@OrderID", orderID),
                            new SqlParameter("@ProductID", productID),
                            new SqlParameter("@UnitPrice", price),
                            new SqlParameter("@Quantity", quantity)
                        };
                        object detailResult = DatabaseHelper.ExecuteScalar(query3, parameters2);
                        int orderDetailID = Convert.ToInt32(detailResult);
                        SqlParameter[] parameters3 = {
                            new SqlParameter("@PreparationID", orderDetailID),
                            new SqlParameter("@Status", "Pending")
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
    }
}
