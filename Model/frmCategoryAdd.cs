using Restaurant_Management_System.Backend;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmCategoryAdd :SampleAdd
    {
        public frmCategoryAdd(int categoryID)
        {
            InitializeComponent();
            CategoryID = categoryID;

        }
        int CategoryID;
        private void frmCategoryAdd_Load(object sender, EventArgs e)
        {
            
        }
        private void InsertCategory()
        {
            string query = "SELECT MAX(CategoryID) FROM Categories";
            object result = DatabaseHelper.ExecuteScalar(query);
            int categoryID = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1; // Bắt đầu từ 1 nếu bảng trống
            string categoryName = txtCategoryName.Text.Trim();

            try
            {

                string query2 = "INSERT INTO Categories (CategoryID, CategoryName) VALUES (@CategoryID, @CategoryName)";


                SqlParameter[] parameters = {
                    new SqlParameter("@CategoryID", categoryID),
                    new SqlParameter("@CategoryName", categoryName)
                };


                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query2, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCategoryName.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm danh mục thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCategory(int CategoryID)
        {
            try
            {
                string categoryName = txtCategoryName.Text.Trim();

                if (string.IsNullOrEmpty(categoryName))
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string queryUpdate = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";

                SqlParameter[] parameters = {
            new SqlParameter("@CategoryID", CategoryID),
            new SqlParameter("@CategoryName", categoryName)
        };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(queryUpdate, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Danh mục đã được cập nhật thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật danh mục: " + ex.Message);
            }
        }


        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (CategoryID == -1)
            {
                InsertCategory();
                this.Close();
            }
            else
            {
                UpdateCategory(CategoryID);
                this.Close();
            }
        }

    }
}
