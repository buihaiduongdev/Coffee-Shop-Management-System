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

namespace Restaurant_Management_System.Customer
{
    public partial class frmProductDetail : Form
    {
        public event EventHandler<Product> ClickAddItem;



        public frmProductDetail(int productId, string productName, decimal price, Image image, string category)
        {
            InitializeComponent();
            bogocmainfrm();

            ucProductDetail1.id = productId;
            ucProductDetail1.PName = productName;
            ucProductDetail1.PPrice = price;
            ucProductDetail1.PImage = image;
            ucProductDetail1.category = category;

            ucProductDetail1.ClickAddItem += (sender, product) =>
            {
                ClickAddItem?.Invoke(this, product);
            };

            ucProductDetail1.OnClose += () => this.Close();
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

        private void bogocmainfrm()
        {
            int radius = 40; // Độ bo góc tuỳ chỉnh
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

    }
}
