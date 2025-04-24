using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Customer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class ucTable : UserControl
    {
        private Table table;
        string status;
       
        public event Action<string> OnTableSelected;
        int tableID;
        public ucTable(Table Table)
        {
            InitializeComponent();
            
            table = Table;
            tableID = table.TableID;    
            lblNameTable.Text = $"Bàn {table.TableID}";
            lblCapicity.Text = $"{table.Capacity} chỗ";
            status = table.Status?.Trim();
            UpdateUI();

        }

        private void btnReserve_Click(object sender, EventArgs e)
        {

            if (status.Trim().Equals("Empty", StringComparison.OrdinalIgnoreCase))
            {
                var result = MessageBox.Show(
                    "Bạn có chắc muốn chọn bàn này không?",
                    "Xác nhận chọn bàn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
 
                    OnTableSelected?.Invoke(lblNameTable.Text);

                }
            }
            else
            {
                MessageBox.Show("Bàn này đã được đặt trước!");
            }
        }


        private void UpdateUI()
        {

            if (status == "Empty")
            {
                btnReserve.Text = "Chọn bàn";
                btnReserve.FillColor = ColorTranslator.FromHtml("#3B9E62");


            }
            else
            {
                btnReserve.Text = "Đã chọn";
                btnReserve.FillColor = ColorTranslator.FromHtml("#F87168");


            }
        }

        private void ucTable_Load(object sender, EventArgs e)
        {



        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
     
        }
    }
}