using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant_Management_System.Model;

namespace Restaurant_Management_System
{
    public partial class frmLoginRegister : Form
    {
        public frmLoginRegister()
        {
            InitializeComponent();

            DisplayLogin();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
        );
        private void DisplayLogin()
        {
            // Tạo và hiển thị UserControl đăng nhập
            ucLogin loginControl = new ucLogin();
            loginControl.Dock = DockStyle.Fill;
            loginControl.OnSwitchToRegister += SwitchToRegister; // Đăng ký sự kiện chuyển qua đăng ký
            this.Controls.Clear(); // Xóa các điều khiển cũ
            this.Controls.Add(loginControl); // Thêm UserControl đăng nhập
    
        }

        private void DisplayRegister()
        {
            // Tạo và hiển thị UserControl đăng ký
            ucRegister registerControl = new ucRegister();
            registerControl.Dock = DockStyle.Fill;
            registerControl.OnSwitchToLogin += SwitchToLogin; // Đăng ký sự kiện chuyển qua đăng nhập
            this.Controls.Clear(); // Xóa các điều khiển cũ
            this.Controls.Add(registerControl); // Thêm UserControl đăng ký
        
        }

        private void SwitchToRegister()
        {
            // Khi người dùng nhấn nút chuyển sang đăng ký
            DisplayRegister();
        }

        private void SwitchToLogin()
        {
            // Khi người dùng nhấn nút chuyển sang đăng nhập
            DisplayLogin();
        }

        private void bogocmainfrm()
        {
            int radius = 100; // Độ bo góc tuỳ chỉnh
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                // Thêm các cung tròn vào path
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);                      // Góc trên trái
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);         // Góc trên phải
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);   // Góc dưới phải
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);         // Góc dưới trái
                path.CloseFigure();// Gán region cho Form
                this.Region = new Region(path);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLoginRegister_Load_1(object sender, EventArgs e)
        {
            bogocmainfrm();
        }

        
    }
}