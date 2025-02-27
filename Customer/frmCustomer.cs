using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;

namespace Restaurant_Management_System.Customer
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImagePath { get; set; }
        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            ProductPanel.Controls.Clear();

            loadCategories();
            loadProducts();

        }
        private void addItems(string ProductID, string ProductName, string Price, Image image, string CategoryName)
        {
            var u = new ucProduct()
            {
                PName = ProductName,
                PPrice = Convert.ToDecimal(Price),
                PImage = image,
                category = CategoryName,
                id = Convert.ToInt32(ProductID)

            };
            ProductPanel.Controls.Add(u);
        }
        private void loadProducts()
        {
            string qry = "SELECT * FROM Products ";
            DataTable dt = DatabaseHelper.ExecuteQuery(qry);

            foreach (DataRow item in dt.Rows)
            {
                Byte[] imagearray = (byte[])item["Image"];
                byte[] imagebytearray = imagearray;

                addItems(
                    item["ProductID"].ToString(),
                    item["ProductName"].ToString(),
                    item["Price"].ToString(),
                    Image.FromStream(new MemoryStream(imagearray)),
                    item["CategoryName"].ToString()
                );
            }
        }
        private void loadCategories()
        {
            flpCategory.FlowDirection = FlowDirection.BottomUp;

            string query = "SELECT DISTINCT CategoryName FROM Categories";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            int buttonWidth = 150;
            int margin = (flpCategory.Width - (buttonWidth * dt.Rows.Count)) / (dt.Rows.Count * 2);

            foreach (DataRow row in dt.Rows)
            {
                Guna2Button btnCategory = new Guna2Button();

                btnCategory.Text = row["CategoryName"].ToString();
                btnCategory.FillColor = this.BackColor;
                btnCategory.ForeColor = ColorTranslator.FromHtml("#533914");
                btnCategory.Size = new Size(buttonWidth, 40);
                btnCategory.Font = new Font("JetBrains Mono NL", 14, FontStyle.Bold);
                btnCategory.BorderRadius = 20;
                btnCategory.Margin = new Padding(margin, 0, margin, 0);

                btnCategory.Click += (sender, e) =>
                {
                    foreach (var control in flpCategory.Controls)
                    {
                        Guna2Button btn = (Guna2Button)control;

                        if (btn == sender)
                        {
                            btn.FillColor = ColorTranslator.FromHtml("#533914");
                            btn.ForeColor = ColorTranslator.FromHtml("#FDF1DB");
                        }
                        else
                        {
                            btn.FillColor = this.BackColor;
                            btn.ForeColor = ColorTranslator.FromHtml("#533914");
                        }
                    }

                    string categoryName = ((Guna2Button)sender).Text;
                    FilterProductsByCategory(categoryName);
                };
                flpCategory.Controls.Add(btnCategory);

            }
        }
        private void FilterProductsByCategory(string categoryName)
        {
            // Sử dụng tham số thay vì string interpolation để tránh SQL injection
            string query = "SELECT * FROM Products WHERE CategoryName = @Category";

            // Tạo tham số SQL
            SqlParameter categoryParam = new SqlParameter("@Category", SqlDbType.NVarChar);
            categoryParam.Value = categoryName;

            // Chuyển List<SqlParameter> thành mảng SqlParameter[]
            SqlParameter[] parameters = new SqlParameter[] { categoryParam };

            // Thực thi câu truy vấn với tham số
            DataTable dtProducts = DatabaseHelper.ExecuteQuery(query, parameters);

            // Cập nhật giao diện với danh sách sản phẩm đã lọc
            ProductPanel.Controls.Clear(); // Xóa trước khi thêm lại
            redisplayProduct(dtProducts);
        }
        private void redisplayProduct(DataTable products)
        {
            foreach (DataRow item in products.Rows)
            {
                Byte[] imagearray = (byte[])item["Image"];
                byte[] imagebytearray = imagearray;

                addItems(
                    item["ProductID"].ToString(),
                    item["ProductName"].ToString(),
                    item["Price"].ToString(),
                    Image.FromStream(new MemoryStream(imagearray)),
                    item["CategoryName"].ToString()
                );
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

    }
}
