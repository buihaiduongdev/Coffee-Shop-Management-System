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

namespace Restaurant_Management_System.CustomerModel
{
    public partial class frmReserveTable : Form
    {
        public frmReserveTable()
        {
            InitializeComponent();
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
        private void borderRadius(int radius = 105)
        {
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

        private void frmReserveTable_Load(object sender, EventArgs e)
        {
            borderRadius();
            for (int i = 1; i <= 18; i++)
            {
                // Khởi tạo UC
                ucTable table = new ucTable();

                // Set thuộc tính nếu cần (ví dụ: số bàn)
                //table.lblTable = i;
                //table.TableName = "Bàn " + i.ToString();

                // Thêm vào FlowLayoutPanel
                flpTable.Controls.Add(table);
                //guna2Panel1.Controls.Add(table);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
