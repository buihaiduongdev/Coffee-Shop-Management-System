using System;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class ucTable : UserControl
    {
        public int TableID { get; set; }
        //public string Status { get; set; }
        public bool IsReserved { get; private set; }

        public event Action<ucTable> OnTableClicked;

        public ucTable()
        {
            InitializeComponent();
            this.Click += btnReserve_Click;
            UpdateUI();
            lblNameTable.Text = $"Bàn {TableID}";
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            OnTableClicked?.Invoke(this);
            IsReserved = !IsReserved;

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (IsReserved)
            {
                btnReserve.Text = "Đã đặt";
                btnReserve.FillColor = ColorTranslator.FromHtml("#F87168");
            }
            else
            {
                btnReserve.Text = "Đặt bàn";
                btnReserve.FillColor = ColorTranslator.FromHtml("#3B9E62");
            }
        }

    }
}