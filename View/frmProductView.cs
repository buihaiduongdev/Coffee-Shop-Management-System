using OfficeOpenXml;
using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Restaurant_Management_System.View
{
    public partial class frmProductView : Form
    {
        private Employee manager;
        public frmProductView(Employee manager)
        {
            InitializeComponent();
            this.manager = manager;
        }
        private DataTable dt;
        private void ApplyCustomTheme()
        {
            try
            {
                // Xóa theme mặc định
                dgvProduct.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
                dgvProduct.EnableHeadersVisualStyles = false;

                // Header
                dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 99, 76);
                dgvProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProduct.ColumnHeadersHeight = 40;

                // Dòng thường
                dgvProduct.DefaultCellStyle.BackColor = Color.FromArgb(165, 140, 100); // Be sáng
                dgvProduct.DefaultCellStyle.ForeColor = Color.Black;
                dgvProduct.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvProduct.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224); // Nâu vừa
                dgvProduct.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Dòng xen kẽ
                dgvProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 177, 142); // Xám nhạt  

                // Bảng
                dgvProduct.BackgroundColor = Color.AntiqueWhite;
                dgvProduct.BorderStyle = BorderStyle.None;
                dgvProduct.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvProduct.RowTemplate.Height = 35;

                // Khác
                dgvProduct.ReadOnly = false;
                dgvProduct.AllowUserToAddRows = false;
                dgvProduct.AllowUserToResizeRows = false;
                dgvProduct.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi áp dụng theme: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            LoadProductData();
            //ApplyCustomTheme();
        }
        private void LoadProductData()
        {
            string query = "SELECT ProductID, ProductName, Price, CategoryName, Image FROM Products WHERE IsDeleted = 0";
            List<string> Categories = new List<string> { "Category" };
            try
            {
                dt = DatabaseHelper.ExecuteQuery(query);
                dgvProduct.Rows.Clear();
                dgvProduct.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                // Duyệt từng dòng dữ liệu từ DataTable và thêm vào DataGridView
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                    dgvProduct.Rows.Add();
                    dgvProduct.Rows[i].Cells["dgvSno"].Value = i + 1; // STT
                    dgvProduct.Rows[i].Cells["dgvProductID"].Value = dt.Rows[i]["ProductID"];
                    dgvProduct.Rows[i].Cells["dgvProductName"].Value = dt.Rows[i]["ProductName"];
                    dgvProduct.Rows[i].Cells["dgvPrice"].Value = string.Format(new CultureInfo("vi-VN"), "{0:#,0}", dt.Rows[i]["Price"]);
                    dgvProduct.Rows[i].Cells["dgvCategory"].Value = dt.Rows[i]["CategoryName"];
                    if (!Categories.Contains(dt.Rows[i]["CategoryName"]))
                    {
                        Categories.Add(dt.Rows[i]["CategoryName"].ToString());
                    }
                }
                int count = dgvProduct.RowCount;
                if (count == 0) labelNumberResultFound.Text = $"Result not found";
                if (count == 1) labelNumberResultFound.Text = $"{count} result found";
                else labelNumberResultFound.Text = $"{count} results found";
                dgvProduct.AllowUserToAddRows = false;
                cbbCategories.DataSource = Categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào Header
            {

                if (e.ColumnIndex == dgvProduct.Columns["dgvedit"].Index)
                {
                    string productID = dgvProduct.Rows[e.RowIndex].Cells["dgvProductID"].Value.ToString();
                    int id = Convert.ToInt32(productID);

                    frmProductAdd frm = new frmProductAdd(id);
                    frm.txtName.Text = Convert.ToString(dgvProduct.CurrentRow.Cells["dgvProductName"].Value);
                    frm.txtPrice.Text = Convert.ToString(dgvProduct.CurrentRow.Cells["dgvPrice"].Value);
                    frm.picImage.Image = ConvertByteArrayToImage((byte[])dt.Rows[e.RowIndex]["Image"]);
                    frm.ShowDialog();
                    LoadProductData();
                }

                if (e.ColumnIndex == dgvProduct.Columns["dgvdel"].Index)
                {
                    string productID = dgvProduct.Rows[e.RowIndex].Cells["dgvProductID"].Value.ToString();
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm {productID}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "UPDATE Products SET IsDeleted = 1 WHERE ProductID = @ProductID";
                        SqlParameter[] param = { new SqlParameter("@ProductID", productID) };

                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(deleteQuery, param);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Đã xóa sản phẩm {productID} thành công!");
                            LoadProductData(); // Cập nhật lại danh sách sản phẩm
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa sản phẩm!");
                        }
                    }
                }
            }
        }

        private Image ConvertByteArrayToImage(byte[] ByteArray)
        {
            using (MemoryStream ms = new MemoryStream(ByteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd(-1);
            frm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            string searchValue = txtSearch.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.Cells["dgvProductID"].Value != null && row.Cells["dgvProductName"].Value != null && row.Cells["dgvCategory"].Value != null)
                {
                    string productId = row.Cells["dgvProductID"].Value.ToString().ToLower();
                    string productName = row.Cells["dgvProductName"].Value.ToString().ToLower();
                    string productCatagory = row.Cells["dgvCategory"].Value.ToString().ToLower();
                    bool isContain = productId.Contains(searchValue) || productName.Contains(searchValue) || productCatagory.Contains(searchValue);
                    row.Visible = isContain;
                    if (isContain) count++;
                }
            }
            if (count == 0) labelNumberResultFound.Text = $"Result not found";
            if (count == 1) labelNumberResultFound.Text = $"{count} result found";
            else labelNumberResultFound.Text = $"{count} results found";
        }

        private void cbbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterValue = cbbCategories.Text;
            if (filterValue == "Category")
            {
                cbbCategories.SelectedText = "Category";
                cbbCategories.ForeColor = Color.Gray;
                LoadProductData();
            }
            else
            {
                cbbCategories.ForeColor = Color.Black;
                string query = $"SELECT * FROM Products WHERE CategoryName = N'{filterValue}'";
                try
                {
                    dt = DatabaseHelper.ExecuteQuery(query);
                    dgvProduct.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvProduct.Rows.Add();
                        dgvProduct.Rows[i].Cells["dgvSno"].Value = i + 1;
                        dgvProduct.Rows[i].Cells["dgvProductID"].Value = dt.Rows[i]["ProductID"];
                        dgvProduct.Rows[i].Cells["dgvProductName"].Value = dt.Rows[i]["ProductName"];
                        dgvProduct.Rows[i].Cells["dgvPrice"].Value = dt.Rows[i]["Price"];
                        dgvProduct.Rows[i].Cells["dgvCategory"].Value = dt.Rows[i]["CategoryName"];
                    }
                    int count = dgvProduct.RowCount;
                    if (count == 0) labelNumberResultFound.Text = $"Result not found";
                    if (count == 1) labelNumberResultFound.Text = $"{count} result found";
                    else labelNumberResultFound.Text = $"{count} results found";
                    dgvProduct.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProduct_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Excel File |*.xlsx";
                save.Title = "Chọn nơi lưu file Excel";
                save.FileName = "SanPham.xlsx";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.License.SetNonCommercialPersonal("Excel");
                        using (ExcelPackage pack = new ExcelPackage())
                        {
                            var ws = pack.Workbook.Worksheets.Add("Sheet1");
                            int month = DateTime.Now.Month;
                            ws.Cells[1, 1].Value = $"DANH SÁCH SẢN PHẨM THÁNG {month}";
                            ws.Cells[1, 1, 1, dgvProduct.Columns.Count - 1].Merge = true;
                            ws.Cells[1, 1].Style.Font.Size = 20;
                            ws.Cells[1, 1].Style.Font.Bold = true;
                            ws.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                            for (int i = 0; i < dgvProduct.Columns.Count - 2; i++)
                            {
                                ws.Cells[3, i + 1].Value = dgvProduct.Columns[i].HeaderText;
                            }

                            for (int i = 0; i < dgvProduct.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvProduct.Columns.Count - 2; j++)
                                {
                                    ws.Cells[i + 3, j + 1].Value = dgvProduct.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            FileInfo info = new FileInfo(save.FileName);
                            pack.SaveAs(info);
                            MessageBox.Show("Đã xuất Excel thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file excel: " + ex.Message);
                    }

                }
            }
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            string query = null;
            if (cbbCategories.Text == "Category")
            {
                query = @"SELECT * FROM Products WHERE IsDeleted = 0";
            }
            else
            {
                query = $@"SELECT * FROM Employees WHERE CategoryName = N'{cbbCategories.Text}' and IsDeleted = 0";
            }
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            ProductReport rpt = new ProductReport();
            rpt.SetDataSource(dt);
            try
            {
                rpt.SetParameterValue("ManagerName", manager.LastName + " " + manager.FirstName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gán parameter ManagerName: " + ex.Message);
            }


            //rpt.SetParameterValue("ManagerName", manager.LastName + " " + manager.FirstName);
            frmReportView report = new frmReportView(manager, rpt);
            report.ShowDialog();
        }
    }
}
