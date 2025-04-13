using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class ucDetail : UserControl
    {
        orderdetailInfo currentOrderDetail;

        public ucDetail()
        {
            InitializeComponent();
        }

        public void SetData(orderdetailInfo detail)
        {
            currentOrderDetail = detail;

            lblOrderID.Text = "Mã đơn hàng: " + detail.OrderDetailID;
            lblUnitPrice.Text = "Đơn giá: " + detail.UnitPrice.ToString("N0") + " VNĐ";
            lblQuantity.Text = "Số lượng: " + detail.Quantity;
            lblIce.Text = "Đá: " + detail.Ice;
            lblSugar.Text = "Đường: " + detail.Sugar;
            lblSize.Text = "Size: " + detail.Size;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblOrderID_Click(object sender, EventArgs e)
        {

        }
    }
}
