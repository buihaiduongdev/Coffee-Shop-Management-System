using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant_Management_System.Customer;

namespace Restaurant_Management_System.Model
{
    public partial class ucProductDetail : UserControl
    {
        public ucProductDetail()
        {
            InitializeComponent();
            pnlProduct.BorderRadius = 20;
            btnAddToCart.Click += btnAddToCart2_Click;
        }
        public event EventHandler onSelect = null;

        public event EventHandler<Product> ClickAddItem;

        public int id { get; set; }
        private decimal _pPrice;

        public decimal PPrice
        {
            get
            {
                string rawText = lblProductPrice2.Text.Replace(" VND", "").Trim();
                if (decimal.TryParse(rawText, out decimal parsedValue))
                {
                    _pPrice = parsedValue;
                }
                return _pPrice;
            }
            set
            {
                _pPrice = value;
                lblProductPrice2.Text = $"{value.ToString("0.##")}";
            }
        }
        public string PName
        {
            get { return lblProductName2.Text; }
            set { lblProductName2.Text = value; }
        }
        public string category { get; set; }
        public Image PImage
        {
            get { return pbImage.Image; }
            set { pbImage.Image = value; }
        }
        private void txtImage_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void btnAddToCart2_Click(object sender, EventArgs e)
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

        private void btnAddToCart2_MouseDown(object sender, MouseEventArgs e)
        {
            btnAddToCart2.FillColor = ColorTranslator.FromHtml("#18CB6C");
        }
        private void btnAddToCart2_MouseUp(object sender, MouseEventArgs e)
        {
            btnAddToCart2.FillColor = Color.Silver;
        }


        public event Action OnClose;
        private void pbBack_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke();
        }
    }
}
