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
        public frmCategoryAdd()
        {
            InitializeComponent();

        }

        private void frmCategoryAdd_Load(object sender, EventArgs e)
        {

        }


        public override void btnSave_Click(object sender, EventArgs e)
        {
            string categoryID = txtCategoryID.Text.Trim();
            string categoryName = txtCategoryName.Text.Trim();

            try
            {
        
                string query = "INSERT INTO Categories (CategoryID, CategoryName) VALUES (@CategoryID, @CategoryName)";


                SqlParameter[] parameters = {
                    new SqlParameter("@CategoryID", categoryID),
                    new SqlParameter("@CategoryName", categoryName)
                };

 
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCategoryID.Clear();
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

    }
}
