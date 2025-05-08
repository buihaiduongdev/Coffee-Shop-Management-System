using Guna.UI2.WinForms;
using Restaurant_Management_System.Backend;
using Restaurant_Management_System.View;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmOrder : Form
    {
        int receptionistID;
        private string language = ucLogin.languages;
        Color ButtonEnabled = Color.FromArgb(255, 192, 128);
        Color ButtonDisable = Color.Silver;
        public frmOrder(int ReceptionistID)
        {
            InitializeComponent();
            receptionistID = ReceptionistID;
        }

        private void frmBillList_Load(object sender, EventArgs e)
        {
            dtDate.Value = DateTime.Now;
            load_language(language);
            LoadData(DateTime.Now.ToString());
        }
        private void ApplyCustomTheme()
        {
            try
            {

                //// Header
                dgvBill.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 99, 76);
                dgvBill.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvBill.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvBill.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBill.ColumnHeadersHeight = 40;

                // Dòng thường
                dgvBill.DefaultCellStyle.BackColor = Color.FromArgb(165, 140, 100); // Be sáng
                dgvBill.DefaultCellStyle.ForeColor = Color.Black;
                dgvBill.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvBill.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224); // Nâu vừa
                dgvBill.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBill.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Dòng xen kẽ
                dgvBill.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 177, 142); // Xám nhạt  

                // Bảng
                dgvBill.BackgroundColor = Color.AntiqueWhite;
                dgvBill.BorderStyle = BorderStyle.None;
                dgvBill.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvBill.RowTemplate.Height = 35;

                // Khác
                dgvBill.ReadOnly = false;
                dgvBill.AllowUserToAddRows = false;
                dgvBill.AllowUserToResizeRows = false;
                dgvBill.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi áp dụng theme: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void LoadData(string date)
        {
            string query = $@"
                    SELECT o.OrderID, o.OrderType, o.Status, o.OrderDay, sum(od.Quantity * od.UnitPrice) as Total
                    FROM Orders o
                    JOIN [Order Details] od
                    ON o.OrderID = od.OrderID
                    Where o.Status = 'Pending' and CONVERT(date,o.Orderday) = '{date}'
                    GROUP BY o.OrderID, o.OrderType, o.Status, o.OrderDay
                ";

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                dgvBill.Rows.Clear();
                decimal total = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvBill.Rows.Add();
                    dgvBill.Rows[i].Cells["dgvSrNo"].Value = i + 1; // 
                    dgvBill.Rows[i].Cells["dgvOrderID"].Value = dt.Rows[i]["OrderID"];
                    dgvBill.Rows[i].Cells["dgvOrderType"].Value = dt.Rows[i]["OrderType"];
                    dgvBill.Rows[i].Cells["dgvOrderDay"].Value = dt.Rows[i]["OrderDay"];
                    dgvBill.Rows[i].Cells["dgvTotal"].Value = string.Format(new CultureInfo("vi-VN"), "{0:#,0}", dt.Rows[i]["Total"]);
                    total += Convert.ToDecimal(dt.Rows[i]["Total"]);
                }
                if (dt.Rows.Count <= 1)
                {
                    lblNumberOder.Text = $"{dt.Rows.Count}";

                }
                else lblNumberOder.Text = $"{dt.Rows.Count}";
                lblRevenue.Text = "+ " + string.Format(new CultureInfo("vi-VN"), "{0:#,0}", total) + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ApplyCustomTheme();
        }


        public void LoadDataSplitType(string date, string type)
        {
            string query = $@"
                    SELECT o.OrderID, o.OrderType, o.Status, o.OrderDay, sum(od.Quantity * od.UnitPrice) as Total
                    FROM Orders o
                    JOIN [Order Details] od
                    ON o.OrderID = od.OrderID
                    Where o.Status = 'Pending' and CONVERT(date,o.Orderday) = '{date}' and o.OrderType =  '{type}'
                    GROUP BY o.OrderID, o.OrderType, o.Status, o.OrderDay
                ";

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                decimal total = 0;
                dgvBill.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvBill.Rows.Add();
                    dgvBill.Rows[i].Cells["dgvSrNo"].Value = i + 1; // 
                    dgvBill.Rows[i].Cells["dgvOrderID"].Value = dt.Rows[i]["OrderID"];
                    dgvBill.Rows[i].Cells["dgvOrderType"].Value = dt.Rows[i]["OrderType"];
                    DateTime orderDateTime = (DateTime)dt.Rows[i]["OrderDay"];
                    dgvBill.Rows[i].Cells["dgvOrderDay"].Value = orderDateTime.ToString("HH:mm");
                    dgvBill.Rows[i].Cells["dgvTotal"].Value = string.Format(new CultureInfo("vi-VN"), "{0:#,0}", dt.Rows[i]["Total"]);
                    total += Convert.ToDecimal(dt.Rows[i]["Total"]); 
                }
                if (dt.Rows.Count <= 1)
                {
                    lblNumberOder.Text = $"{dt.Rows.Count}";

                }
                else lblNumberOder.Text = $"{dt.Rows.Count}";
                lblRevenue.Text = "+ " + string.Format(new CultureInfo("vi-VN"), "{0:#,0}", total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ApplyCustomTheme();
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvBill.Columns["dgvview"].Index)
                {
                    string orderID = dgvBill.Rows[e.RowIndex].Cells["dgvOrderID"].Value.ToString();
                    string query4_1 = @"SELECT * FROM [Order Details] WHERE OrderID = @OrderID";
                    string query4_2 = @"SELECT * FROM Products";
                    SqlParameter[] paraOrderID = { new SqlParameter("@OrderID", orderID) };
                    DataTable order = DatabaseHelper.ExecuteQuery(query4_1, paraOrderID);
                    order.TableName = "Order Details";
                    DataTable products = DatabaseHelper.ExecuteQuery(query4_2);
                    products.TableName = "Products";
                    DataSet ds = new DataSet();
                    ds.Tables.Add(order);
                    ds.Tables.Add(products);
                    Reciept rpt = new Reciept();
                    rpt.SetDataSource(ds);
                    rpt.SetParameterValue("Receptionist", "");
                    rpt.SetParameterValue("Table", "- 1");
                    rpt.SetParameterValue("OrderID", orderID);
                    rpt.SetParameterValue("Payment", "");
                    //frmReportView report = new frmReportView(rpt);
                    frmReportView report = new frmReportView(null, rpt);
                    report.ShowDialog();
                }
            }
        }



        public void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.Cells["dgvOrderID"].Value != null &&
                    row.Cells["dgvOrderType"].Value != null)
                {
                    string orderID = row.Cells["dgvOrderID"].Value.ToString().ToLower();
                    string orderType = row.Cells["dgvOrderType"].Value.ToString().ToLower();

                    row.Visible = orderID.Contains(searchValue) ||
                                  orderType.Contains(searchValue);
                }
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            lblBillList.Text = LocalizationHelper.GetString("lblBillList");
            dgvBill.Columns["dgvOrderID"].HeaderText = LocalizationHelper.GetString("dgvOrderID");
            dgvBill.Columns["dgvOrderType"].HeaderText = LocalizationHelper.GetString("dgvOrderType");
            dgvBill.Columns["dgvOrderDay"].HeaderText = LocalizationHelper.GetString("dgvOrderDay");
            dgvBill.Columns["dgvTotal"].HeaderText = LocalizationHelper.GetString("dgvTotal");
            dgvBill.Columns["dgvview"].HeaderText = LocalizationHelper.GetString("dgvview");
            txtSearch.Text = LocalizationHelper.GetString("txtSearch");
            btnAllType.Text = LocalizationHelper.GetString("btnAllType");
            btnTakeAway.Text = LocalizationHelper.GetString("btnTakeAway");
            btnDinein.Text = LocalizationHelper.GetString("btnDinein");
            guna20HtmlLabel2.Text = LocalizationHelper.GetString("guna20HtmlLabel2");
            guna20HtmlLabel1.Text = LocalizationHelper.GetString("guna20HtmlLabel1");
            //lblNumberOder.Text = LocalizationHelper.GetString("lblNumberOder");




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            string type = btnAllType.FillColor == ButtonEnabled ? "" : btnDinein.FillColor == ButtonEnabled ? "DineIn" : "TakeAway";
            string date = dtDate.Value.ToString("yyyy-MM-dd");
            if (type == "") LoadData(date);
            else LoadDataSplitType(date, type);
        }

        private void btnAllType_Click(object sender, EventArgs e)
        {
            btnAllType.FillColor = ButtonEnabled;
            btnAllType.BorderColor = ButtonEnabled;
            btnDinein.BorderColor = ButtonDisable;
            btnDinein.FillColor = ButtonDisable;
            btnTakeAway.FillColor = ButtonDisable;
            btnTakeAway.BorderColor = ButtonDisable;
            string date = dtDate.Value.ToString("yyyy-MM-dd");
            LoadData(date);
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            btnAllType.FillColor = ButtonDisable;
            btnAllType.BorderColor = ButtonDisable;
            btnDinein.BorderColor = ButtonDisable;
            btnDinein.FillColor = ButtonDisable;
            btnTakeAway.FillColor = ButtonEnabled;
            btnTakeAway.BorderColor = ButtonEnabled;
            string type = "TakeAway";
            string date = dtDate.Value.ToString("yyyy-MM-dd");
            LoadDataSplitType(date, type);
        }

        private void btnDinein_Click(object sender, EventArgs e)
        {

            btnAllType.FillColor = ButtonDisable;
            btnAllType.BorderColor = ButtonDisable;
            btnDinein.BorderColor = ButtonEnabled;
            btnDinein.FillColor = ButtonEnabled;
            btnTakeAway.FillColor = ButtonDisable;
            btnTakeAway.BorderColor = ButtonDisable;
            string type = "DineIn";
            string date = dtDate.Value.ToString("yyyy-MM-dd");
            LoadDataSplitType(date, type);
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.Cells["dgvOrderID"].Value != null &&
                    row.Cells["dgvOrderType"].Value != null)
                {
                    string orderID = row.Cells["dgvOrderID"].Value.ToString().ToLower();
                    string orderType = row.Cells["dgvOrderType"].Value.ToString().ToLower();


                    row.Visible = orderID.Contains(searchValue) ||
                                  orderType.Contains(searchValue);
                }
                }
            }

        private void lblNumberOder_Click(object sender, EventArgs e)
        {

        }
    }
}
