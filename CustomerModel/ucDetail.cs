
using Restaurant_Management_System.CustomerModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class ucDetail : UserControl
    {
        private List<OrderDetailProduct> orderDetail = new List<OrderDetailProduct>();
        public ucDetail()
        {
            InitializeComponent();
            flpOrderItems.AutoScroll = true;
        }


        public void SetData(List<OrderDetailProduct> details, int orderId)
        {
            orderDetail = details ?? new List<OrderDetailProduct>();

            flpOrderItems.Controls.Clear();

            lblOrderID.Text = $"Mã đơn hàng: {orderId}";

            if (orderDetail.Any())
            {
                flpOrderItems.SuspendLayout();

                // Số sản phẩm trên một hàng (2 hoặc 3)
                int itemsPerRow = 2; // Có thể đổi thành 2 nếu muốn 2 sản phẩm/hàng
                int itemWidth = (flpOrderItems.Width - (itemsPerRow + 1) * 10) / itemsPerRow; // 10 là khoảng cách giữa các sản phẩm

                foreach (var detail in orderDetail)
                {
                    var item = new ucItemOrder();
                    item.SetData(detail);
                    item.Width = itemWidth; // Đặt chiều rộng để hiển thị 3 sản phẩm trên 1 hàng
                    flpOrderItems.Controls.Add(item);
                }

                flpOrderItems.ResumeLayout();

                //decimal total = orderDetail.Sum(d => d.TotalPrice);
            }
            else
            {
                MessageBox.Show("Không có chi tiết đơn hàng để hiển thị.");
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            var parentForm = this.Parent as Form;
            parentForm?.Close();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}


