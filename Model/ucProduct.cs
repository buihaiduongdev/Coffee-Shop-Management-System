using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            get { return Convert.ToDecimal(lblProductPrice.Text); }
            set { lblProductPrice.Text = value.ToString("0.##") + " VND"; }
        }
        public string PName 
        { 
            get { return lblProductName.Text; } 
            set { lblProductName.Text = value; }
        }

        public string category { get; set; }
        public Image PImage {
            get { return txtImage.Image; }
            set{ txtImage.Image = value; }
        }


        private void txtImage_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
