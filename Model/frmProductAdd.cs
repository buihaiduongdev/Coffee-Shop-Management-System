using Restaurant_Management_System.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmProductAdd : Form
    {
        private string language = ucLogin.languages;
        public frmProductAdd(int productID)
        {
            InitializeComponent();
            ProductID = productID;
            pbHeaderIcon.Image = Properties.Resources.Products;
        }
        int ProductID;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = language == "en" ? "Choose product image":"Chọn ảnh sản phẩm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh trong PictureBox
                picImage.Image = Image.FromFile(openFileDialog.FileName);
                picImage.SizeMode = PictureBoxSizeMode.StretchImage; // Hiển thị ảnh vừa khung
            }
        }

        private byte[] ConvertImageToByteArray(PictureBox pictureBox)
        {
            MemoryStream ms = new MemoryStream();

            pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        private void InsertProduct()
        {
            string productName = txtName.Text;
            string strPrice = txtPrice.Text;
            string category = cmbCategory.SelectedItem.ToString();
            byte[] imageBytes = ConvertImageToByteArray(picImage);

            string query = "INSERT INTO Products(ProductName, Price, Image,CategoryName) " +
                           "VALUES( @ProductName, @Price, @Image, @CategoryName )";

            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(strPrice) || string.IsNullOrEmpty(category))
            {
                if (language == "en") throw new Exception("Input error! Please enter full product information!");
                else throw new Exception("Lỗi nhập liệu! Vui lòng nhập đầy đủ thông tin sản phẩm!");
            }

            if (!decimal.TryParse(strPrice, out decimal price) || price <= 0)
            {
                if (language == "en") throw new Exception("Input error! Please enter full product information!");
                else throw new Exception("Input error! Product price is invalid!");
            }

            SqlParameter[] parameters = new SqlParameter[]
{

                new SqlParameter("@ProductName", productName),
                new SqlParameter("@Price", price),
                new SqlParameter("@Image", SqlDbType.VarBinary) { Value = (imageBytes != null ? (object)imageBytes : DBNull.Value) },
                new SqlParameter("@CategoryName", category)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);


            if (rowsAffected > 0)
            {
                if (language == "en") MessageBox.Show("Product has been added successfully!", "Notification");
                else MessageBox.Show("Sản phẩm đã được thêm thành công!", "Thông báo");
            }
            else
            {
                if (language == "en") MessageBox.Show("No changes were made.", "Notification");
                else MessageBox.Show("Không có thay đổi nào được thực hiện.", "Thông báo");
            }
        }

        public void UpdateProduct(int productID)
        {
                string productName = txtName.Text.Trim();
                string strPrice = txtPrice.Text.Trim();
                string category = cmbCategory.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(strPrice) || string.IsNullOrEmpty(category))
                {
                    if (language == "en") throw new Exception("Input error! Please enter full product information!");
                    else throw new Exception("Lỗi nhập liệu! Vui lòng nhập đầy đủ thông tin sản phẩm!");
                }

                if (!decimal.TryParse(strPrice, out decimal price) || price <= 0)
                {
                    if (language == "en") throw new Exception("Input error! Product price is invalid!");
                    else throw new Exception("Lỗi nhập liệu! Giá sản phẩm không hợp lệ!");
                }

                byte[] imageBytes = ConvertImageToByteArray(picImage);

                string query = @"
                    UPDATE Products 
                    SET ProductName = @ProductName, 
                        Price = @Price, 
                        Image = @Image, 
                        CategoryName = @CategoryName
                    WHERE ProductID = @ProductID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ProductID", productID),
                    new SqlParameter("@ProductName", productName),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@Image", (object)imageBytes ?? DBNull.Value),
                    new SqlParameter("@CategoryName", category)
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    if (language == "en") MessageBox.Show("Product has been updated successfully!", "Notification");
                    else MessageBox.Show("Sản phẩm đã được cập nhật thành công!", "Notification");
                }
                else
                {
                    if (language == "en") MessageBox.Show("No changes were made.", "Notification");
                    else MessageBox.Show("Không có thay đổi nào được thực hiện.", "Notification");
                }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            bool AddProduct = false;
            try
            {
                if (ProductID == -1)
                {
                    AddProduct = true;
                    InsertProduct();
                    this.Close();
                }
                else
                {
                    UpdateProduct(ProductID);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (AddProduct)
                {
                    if (language == "en") MessageBox.Show("Error adding product: " + ex.Message, "Notification");
                    else if (language == "vi") MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Notification");
                }
                else
                {
                    if (language == "en") MessageBox.Show("Error updating product: " + ex.Message, "Notification");
                    else MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message, "Notification");
                }
            }
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            LoadCategories(); // Gọi hàm tải danh mục khi Form load
            load_language(language);
        }

        private void LoadCategories()
        {
            string query = "SELECT DISTINCT CategoryName FROM Categories";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("");

            foreach (DataRow row in dt.Rows)
            {
                cmbCategory.Items.Add(row["CategoryName"].ToString()); 
            }

            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0; 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void picImage_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (language == "en") openFileDialog.Title = "Choose product image";
            else if (language == "vi") openFileDialog.Title = "Chọn ảnh sản phẩm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh trong PictureBox
                picImage.Image = Image.FromFile(openFileDialog.FileName);
                picImage.SizeMode = PictureBoxSizeMode.StretchImage; // Hiển thị ảnh vừa khung
            }
        }
        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            btnClose.Text = LocalizationHelper.GetString("btnClose");
            btnSave.Text = LocalizationHelper.GetString("btnSave");
            lblProductAdd.Text = LocalizationHelper.GetString("btnProductAdd");
            lblProductName.Text = LocalizationHelper.GetString("lblProductName");
            lblPrice.Text = LocalizationHelper.GetString("lblPrice");
            txtName.Text = LocalizationHelper.GetString("txtName");
            txtPrice.Text = LocalizationHelper.GetString("txtPrice");
            btnBrowse.Text = LocalizationHelper.GetString("btnBrowser");
        }

    }
}
