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
    public partial class frmProductAdd : SampleAdd
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }
     

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Chọn ảnh sản phẩm";

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

        public override void btnSave_Click(object sender, EventArgs e)
        {

            string strProductID = txtProductID.Text;
            string productName = txtName.Text;
            string strPrice = txtPrice.Text;
            string category = cmbCategory.SelectedItem.ToString();
            int productID = int.Parse(strProductID); 
            decimal price = decimal.Parse(strPrice);
            byte[] imageBytes = ConvertImageToByteArray(picImage);
  
            string query = "INSERT INTO Products(ProductID, ProductName, Price, Image,CategoryName) " +
                           "VALUES(@ProductID, @ProductName, @Price, @Image, @CategoryName )";

     
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductID", productID), 
                new SqlParameter("@ProductName", productName),
                new SqlParameter("@Price", price),
                new SqlParameter("@Image", SqlDbType.VarBinary) { Value = (imageBytes != null ? (object)imageBytes : DBNull.Value) },
                new SqlParameter("@CategoryName", category)
            };

            try
            {
       
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

          
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sản phẩm đã được thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.");
                }
            }
            catch (Exception ex)
            {
    
                MessageBox.Show("Lỗi khi thực thi câu lệnh SQL: " + ex.Message);
            }


        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            LoadCategories(); // Gọi hàm tải danh mục khi Form load
        }

        private void LoadCategories()
        {
            string query = "SELECT DISTINCT CategoryName FROM Categories";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            cmbCategory.Items.Clear(); 

            foreach (DataRow row in dt.Rows)
            {
                cmbCategory.Items.Add(row["CategoryName"].ToString()); 
            }

            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0; 
            }
        }





    }
}
