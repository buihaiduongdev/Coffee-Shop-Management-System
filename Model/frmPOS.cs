using Guna.UI2.WinForms;
using Restaurant_Management_System.Backend;
using Restaurant_Management_System.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class frmPOS : Form
    {
        private frmMain mainForm; // Biến để lưu tham chiếu đến frmMain

        public frmPOS()
        {
            InitializeComponent();
        }

        public int MainID = 0;
        public string orderType;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain frmMain = new frmMain();
            frmMain.AddControls(new frmHome());
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            dgvPOS.BorderStyle = BorderStyle.FixedSingle;
            LoadCategories();
            ProductPanel.Controls.Clear();
            loadProducts();

        }

        //SYS6 23:00
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        private void addItems(string ProductID,  string ProductName, string Price, Image image, string CategoryName)
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
                    item["Price"].ToString() ,
                    Image.FromStream(new MemoryStream(imagearray)),
                    item["CategoryName"].ToString()
                );
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            dgvPOS.Rows.Clear();
            MainID = 0;
            lblCost.Text = "0.00";
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            orderType = "Delivery";

            frmAddCustomer frmAddCustomer = new frmAddCustomer();  
            //Them mainclass.cs moi goi duoc frm nay
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            orderType = "Take Away";

        }

        //thieu BE de add data vao 
        private void btnDinIn_Click(object sender, EventArgs e)
        {
            //need to crate form for table selection and waier selection
            frmTableSelect frmTableSelect = new frmTableSelect();
            //MainClass.BlurBackground(frm);       
            if(frmTableSelect.tableName != "")
            {
                lblTable.Text = frmTableSelect.tableName;
                lblTable.Visible = true;
            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;
            }

            frmWaiterSelect frmWaiterSelect = new frmWaiterSelect();
            //MainClass.BlurBackground(frm);       
            if (frmWaiterSelect.waiterName != "")
            {
                lblTable.Text = frmWaiterSelect.waiterName;
                lblWaiter.Visible=true;
            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible=false;    
            }

        }
        //cac ham BE load tu 23p den het video
        //O duoi tinh tu 1:07 cua video sys 9
        private void btnBill_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvPOS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvPOS.Rows)
            {
                count++;
                row.Cells[0].Value = count;
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



        private void btnBillList_Click(object sender, EventArgs e)
        {
            //phut 10:55 sys9
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            //frmCheckout frm = new frmCheckout();
            //frm.MainID = id;
            //MainID = 0;
            //dgvPOS.Rows.Clear();
            //lblTable.Text = "";
            //lblWaiter.Text = "";
            //lblTable.Visible = false;
            //lblWaiter.Visible = false;
            //lblTotal.Text = "00";
        }

        //SYS 10 0:00
        private void btnHold_Click(object sender, EventArgs e)
        {

        }

        private void frmPOS_FormClosed(object sender, FormClosedEventArgs e)
        {
            //mainForm.AddControls(new frmHome());
        }
    }
}
