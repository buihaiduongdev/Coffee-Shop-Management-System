using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

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
    }
}
