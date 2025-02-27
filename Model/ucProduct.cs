using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Restaurant_Management_System.Model
{
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
        }
        public event EventHandler onSelect = null;

        public int id { get; set; }
        public decimal PPrice {
            get { return Convert.ToDecimal(lblProductPrice2.Text); }
            set { lblProductPrice2.Text = value.ToString("0.##") + " VND"; }
        }
        public string PName 
        { 
            get { return lblProductName2.Text; } 
            set { lblProductName2.Text = value; }
        }

        public string category { get; set; }
        public Image PImage {
            get { return pbImage.Image; }
            set{ pbImage.Image = value; }
        }

        private void ucProduct_Load(object sender, EventArgs e)
        {
            pnlProduct.BorderRadius = 20;

        }

        private void txtImage_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void lblProductName2_Click(object sender, EventArgs e)
        {

        }


        private void btnAddToCart_MouseDown(object sender, MouseEventArgs e)
        {
            btnAddToCart.FillColor = ColorTranslator.FromHtml("#0ACD4D");
        }

        private void btnAddToCart_MouseUp(object sender, MouseEventArgs e)
        {
            btnAddToCart.FillColor = Color.Silver;
        }


        private void pbImage_MouseEnter(object sender, EventArgs e)
        {
            pbImage.Size = new Size(pbImage.Width + 20, pbImage.Height + 20);
            lblProductName2.ForeColor = ColorTranslator.FromHtml("#F1BC7A");
        }

        private void pbImage_MouseLeave(object sender, EventArgs e)
        {
            pbImage.Size = new Size(pbImage.Width - 20, pbImage.Height - 20);
            lblProductName2.ForeColor = ColorTranslator.FromHtml("#533914");
        }

    }
}
