using Restaurant_Management_System.Customer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class ucTable : UserControl
    {
        private Table table;
        private bool isReserved = false;


        public event Action<ucTable> OnTableClicked;
        public event Action<string> OnTableSelected;
        public ucTable(Table table)
        {
            InitializeComponent();
            this.table = table;

            lblNameTable.Text = $"Bàn {table.TableID}";

            lblCapicity.Text = $"{table.Capacity} chỗ";
 
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn chọn bàn này không?",
                "Xác nhận chọn bàn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if ( result == DialogResult.Yes )
            {
                OnTableClicked?.Invoke(this);

                isReserved = true;

                UpdateUI();

                OnTableSelected?.Invoke(lblNameTable.Text);
            }
        }

        private void UpdateUI()
        {
            if (isReserved)
            {
                btnReserve.Text = "Đã chọn";
                btnReserve.FillColor = ColorTranslator.FromHtml("#F87168");
            }
            else
            {
                btnReserve.Text = "Chọn bàn";
                btnReserve.FillColor = ColorTranslator.FromHtml("#3B9E62");
            }
        }

        private void lblNameTable_Click(object sender, EventArgs e)
        {
            
        }
    }
}
