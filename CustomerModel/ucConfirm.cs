using Restaurant_Management_System.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class ucConfirm : UserControl
    {
        orderInfo currentOrder;
        //orderID detailOrder;
        public ucConfirm()
        {
            InitializeComponent();
        }

        public void SetData(orderInfo order)
        {
            currentOrder = order;
            lblOrderID.Text = "Đơn hàng: " + order.OrderID.ToString();
            lblOrderDate.Text = "Ngày đặt:\n"+ order.Orderdate.ToString("dd/MM/yyyy");
            lblStatus.Text ="Trạng thái: \n" + order.Status;

            switch (order.Status)
            {
                case "Pending":
                    btnAction.Text = "Hủy đơn";
                    break;
                case "Confirmed":
                    btnAction.Text = "Nhận hàng";
                    break;
                case "Received":
                    btnAction.Text = "Đánh giá";
                    break;
                default:
                    btnAction.Visible = false; 
                    break;
            }
        }
            
        
        public void SetButtonLabel(string text)
        {
            btnAction.Text = text;
        }
        private void btnAction_Click(object sender, EventArgs e)
        {
            switch (currentOrder.Status)
            {
                case "Pending":
                    MessageBox.Show($"Bạn đã hủy đơn hàng #{currentOrder.OrderID}");
                    CancelOrder();
                    break;

                case "Confirmed":
                    MessageBox.Show($"Bạn xác nhận đã nhận đơn hàng #{currentOrder.OrderID}");
                    MarkAsReceived();
                    break;

                case "Received":
                    MessageBox.Show($"Đi đến đánh giá đơn hàng #{currentOrder.OrderID}");
                    // TODO: mở form đánh giá
                    break;
            }
        }

        private void CancelOrder()
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy đơn hàng này không?",
                "Xác nhận hủy đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return; // người dùng chọn No thì thoát luôn

            string query = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", "Rejected"),
                new SqlParameter("@OrderID", currentOrder.OrderID)
                    };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Đã hủy đơn hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAction.Visible = false;
                currentOrder.Status = "Rejected";
            }
            else
            {
                MessageBox.Show("Hủy đơn hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarkAsReceived()
        {
            string query = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", "Received"),
                new SqlParameter("@OrderID", currentOrder.OrderID)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Xác nhận đã nhận hàng thành công.");
                btnAction.Text = "Đánh giá";
                currentOrder.Status = "Received";
            }
            else
            {
                MessageBox.Show("Xác nhận thất bại.");
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblOrderID_Click(object sender, EventArgs e)
        {

        }

        private void lblOrderDate_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderDetail_Click_1(object sender, EventArgs e)
        {
            frmDetailInfo detailInfo = new frmDetailInfo(currentOrder.OrderID);
            detailInfo.ShowDialog();
        }
    }
}
