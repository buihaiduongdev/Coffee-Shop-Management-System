using System;
using System.Windows.Forms;
using Restaurant_Management_System.Backend;

namespace Restaurant_Management_System.Barista
{
    public partial class ucKitchen : UserControl
    {
        private Timer timer;
        private DateTime orderTime;
        private int preparationID; // ID đơn hàng để cập nhật trạng thái
        public Action RefreshOrders; // Delegate để gọi LoadOrders()

        public ucKitchen(int preparationID, string productName, string status, TimeSpan elapsedTime)
        {
            InitializeComponent();
            this.preparationID = preparationID;
            this.ProductName = productName;
            this.Status = status;
            this.orderTime = DateTime.Now - elapsedTime;

            UpdateWaitingTime(); // Cập nhật thời gian chờ ngay khi load

            if (status == "Pending")
            {
                btnAction.Text = "Take";
                btnAction.Visible = true;
            }
            else if (status == "Processing")
            {
                btnAction.Text = "Done";
                btnAction.Visible = true;
            }
            else
            {
                btnAction.Visible = false; // Ẩn nút nếu đơn hàng đã hoàn thành
            }

            if (status != "Completed")
            {
                InitializeTimer();
                timer.Start();
            }
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // Cập nhật mỗi giây
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateWaitingTime();
        }

        private void UpdateWaitingTime()
        {
            TimeSpan elapsed = DateTime.Now - orderTime;
            WaitingTime = $"{elapsed.Minutes} min {elapsed.Seconds} sec";
        }

        public string WaitingTime
        {
            get { return lblWaitingTime.Text; }
            private set { lblWaitingTime.Text = value; }
        }

        public string ProductName
        {
            get { return lblProductName.Text; }
            set { lblProductName.Text = value; }
        }

        public string Status
        {
            get { return lblStatus.Text; }
            set
            {
                lblStatus.Text = value;

                if (value == "Pending")
                {
                    btnAction.Text = "Take";
                    btnAction.Visible = true;
                }
                else if (value == "Processing")
                {
                    btnAction.Text = "Done";
                    btnAction.Visible = true;
                }
                else
                {
                    btnAction.Visible = false; // Ẩn nút nếu đơn đã hoàn thành
                }

                if (value == "Completed")
                {
                    timer?.Stop();
                    WaitingTime = "Đã hoàn thành";
                }
            }
        }

        private void UpdateOrderStatus(string newStatus)
        {
            string query = $"UPDATE Preparations SET Status = '{newStatus}' WHERE PreparationID = {this.preparationID}";
            DatabaseHelper.ExecuteNonQuery(query);

            this.Status = newStatus; // Cập nhật giao diện ngay lập tức
        }

        private void btnAction_Click_1(object sender, EventArgs e)
        {
            if (Status == "Pending")
            {
                UpdateOrderStatus("Processing");
                
            }
            else if (Status == "Processing")
            {
                UpdateOrderStatus("Completed");
            }
            RefreshOrders?.Invoke(); // Gọi LoadOrders() từ frmKitchen

        }
    }

}

