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
using Restaurant_Management_System.Customer;

namespace Restaurant_Management_System.Model
{
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
            pnlProduct.BorderRadius = 20;
            btnAddToCart.Click += btnAddToCart_Click;
        }
        public event EventHandler onSelect = null;

        public event EventHandler<Product> ClickAddItem;

        public int id { get; set; }
        public decimal PPrice {
            get { return Convert.ToDecimal(lblProductPrice2.Text.Replace(" VND", "").Trim());}
            set { lblProductPrice2.Text = value.ToString("0.##"); }
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
        private void txtImage_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
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
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                ProductID = this.id,
                ProductName = this.PName,
                Price = this.PPrice,
                Image = this.PImage,
                CategoryName = this.category
            };

            ClickAddItem?.Invoke(this, product);
        }

        private void lblProductPrice2_Click(object sender, EventArgs e)
        {

        }
    }
}
