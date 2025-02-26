using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            u.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;

                foreach (DataGridViewRow item in dgvPOS.Rows)
                {
                    // this will check if product already there then add one to quantity and update price
                    if (Convert.ToInt32(item.Cells["dgvId"].Value) == wdg.id)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) *
                                                         double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        GetTotal();
                        return;

                    }
                }
                dgvPOS.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                GetTotal();

            };

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

            foreach (DataRow row in dt.Rows)
            {
                Guna2Button btnCategory = new Guna2Button();

                btnCategory.Text = row["CategoryName"].ToString();
                btnCategory.FillColor = this.BackColor;
                btnCategory.ForeColor = ColorTranslator.FromHtml("#C0AA83");
                btnCategory.Size = new Size(150, 40);
                btnCategory.Font = new Font("Onest", 14, FontStyle.Bold);
                btnCategory.BorderRadius = 20;

                flpCategory.Controls.Add(btnCategory);
            }
        }

        private void GetTotal()
        {
            double tot = 0;
            lblCost.Text = "";

            foreach (DataGridViewRow item in dgvPOS.Rows)
            {
                // Kiểm tra nếu ô không null
                if (item.Cells["dgvAmount"].Value != null &&
                    double.TryParse(item.Cells["dgvAmount"].Value.ToString(), out double amount))
                {
                    tot += amount;
                }
            }

            lblCost.Text = tot.ToString();
        }

        private void ProductPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
