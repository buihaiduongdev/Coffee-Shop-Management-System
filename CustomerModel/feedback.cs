using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class feedback : Form
    {
        int OrderID;

        public feedback(int OrderID)
        {
            InitializeComponent();
            this.OrderID = OrderID;
            SetupPictureBoxes();
        }


        private int currentRating = 0;
        private void SetupPictureBoxes()
        {
            Star1.MouseEnter += pictureBox_MouseEnter;
            Star2.MouseEnter += pictureBox_MouseEnter;
            Star3.MouseEnter += pictureBox_MouseEnter;
            Star4.MouseEnter += pictureBox_MouseEnter;
            Star5.MouseEnter += pictureBox_MouseEnter;

            Star1.MouseLeave += pictureBox_MouseLeave;
            Star2.MouseLeave += pictureBox_MouseLeave;
            Star3.MouseLeave += pictureBox_MouseLeave;
            Star4.MouseLeave += pictureBox_MouseLeave;
            Star5.MouseLeave += pictureBox_MouseLeave;

            Star1.Click += pictureBox_Click;
            Star2.Click += pictureBox_Click;
            Star3.Click += pictureBox_Click;
            Star4.Click += pictureBox_Click;
            Star5.Click += pictureBox_Click;

            ResetStars();
        }
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox hoveredPictureBox = sender as PictureBox;
            int hoveredIndex = int.Parse(hoveredPictureBox.Name.Replace("Star", ""));
            for (int i = 1; i <= hoveredIndex; i++)
            {
                PictureBox pb = (PictureBox)this.Controls["Star" + i];
                pb.Image = new Bitmap(@"star.jpg"); //"C:\Users\dinhv\OneDrive\Downloads\CoffeeShopManagement\bin\Debug\Resources\star.jpg"
            }
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            UpdateStars();
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            currentRating = int.Parse(clickedPictureBox.Name.Replace("Star", ""));
            UpdateStars();
        }

        private void UpdateStars()
        {
            for (int i = 1; i <= 5; i++)
            {
                PictureBox pb = (PictureBox)this.Controls["Star" + i];
                if (i <= currentRating)
                {
                    pb.Image = new Bitmap(@"star.jpg");
                }
                else
                {
                    pb.Image = null;
                }
            }
        }
        private void ResetStars()
        {
            currentRating = 0;
            UpdateStars();
        }

        private void btnSendFeedback_Click(object sender, EventArgs e)
        {


            btnSend.Enabled = false;
            Star1.Enabled = false;
            Star2.Enabled = false;
            Star3.Enabled = false;
            Star4.Enabled = false;
            Star5.Enabled = false;
            txtFeedback.Enabled = false;

        }

        private void feedback_Load(object sender, EventArgs e)
        {
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string txt = txtFeedback.Text;
            int rating = currentRating;
            if (rating == 0)
            {
                MessageBox.Show("Vui lòng đánh giá trước khi gửi");
                return;
            }
            int id = OrderID;

            string queryInsert = @"
                INSERT INTO Feedbacks (OrderID, Rating, Comment) 
                VALUES (@OrderID, @Rating, @Comment)";

            string queryUpdate = @"
                UPDATE Orders 
                SET Status = 'Feedbacked' 
                WHERE OrderID = @OrderID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", id),
                new SqlParameter("@Rating", rating),
                new SqlParameter("@Comment", txt)
                    };

            // Insert feedback
            int rowsAffectedInsert = DatabaseHelper.ExecuteNonQuery(queryInsert, parameters);

            // Update status
            SqlParameter[] updateParams = new SqlParameter[]
            {
                new SqlParameter("@OrderID", id)
            };
            int rowsAffectedUpdate = DatabaseHelper.ExecuteNonQuery(queryUpdate, updateParams);

            if (rowsAffectedInsert > 0 && rowsAffectedUpdate > 0)
            {
                MessageBox.Show("Cảm ơn quý khách!", "Notification");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào được thực hiện.", "Notification");
            }
        }

        private void btnExcellent_Click(object sender, EventArgs e)
        {
            AppendFeedback("Sản phẩm rất tuyệt vời!");
            HandleButtonClick((Guna2Button)sender);
        }

        private void btnFastDelivery_Click_1(object sender, EventArgs e)
        {
            AppendFeedback("Thời gian vận chuyển nhanh!");
            HandleButtonClick((Guna2Button)sender);
        }

        private void btnPerfect_Click(object sender, EventArgs e)
        {
            AppendFeedback("Hoàn hảo");
            HandleButtonClick((Guna2Button)sender);
        }

        private void btnVerySatisfied_Click(object sender, EventArgs e)
        {
            AppendFeedback("Tôi rất hài lòng!");
            HandleButtonClick((Guna2Button)sender);
        }
        private void AppendFeedback(string text)
        {
            if (!txtFeedback.Text.Contains(text))
            {
                if (!string.IsNullOrWhiteSpace(txtFeedback.Text))
                    txtFeedback.Text += " ";
                txtFeedback.Text += text;
            }
        }

        private void HandleButtonClick(Guna2Button clickedButton)
        {

            if (clickedButton == btnExcellent)
            {
                btnFastDelivery.Enabled = false;
                btnPerfect.Enabled = false;
                btnVerySatisfied.Enabled = false;
            }
           
            else if (clickedButton == btnFastDelivery)
            {
                btnExcellent.Enabled = false;
                btnPerfect.Enabled = false;
                btnVerySatisfied.Enabled = false;
            }
           
            else if (clickedButton == btnPerfect)
            {
                btnExcellent.Enabled = false;
                btnFastDelivery.Enabled = false;
                btnVerySatisfied.Enabled = false;
            }
            
            else if (clickedButton == btnVerySatisfied)
            {
                btnExcellent.Enabled = false;
                btnFastDelivery.Enabled = false;
                btnPerfect.Enabled = false;
            }

           
            clickedButton.Enabled = true;
        }

        private void btnCancel_Click_2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

      
    }
}
