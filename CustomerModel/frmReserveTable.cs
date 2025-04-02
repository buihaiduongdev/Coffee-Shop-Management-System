using Restaurant_Management_System.Backend;
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
        public string SelectedTableName { get; private set; }

        private void frmReserveTable_Load(object sender, EventArgs e)
        {
            borderRadius();

            string query = @"SELECT * FROM Tables";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            flpTable.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                var tableData = new Table(
                    Convert.ToInt32(row["TableID"]),
                    Convert.ToInt32(row["Capacity"]),
                    (row["Status"]).ToString()
                );

                var tableUC = new ucTable(tableData);
                tableUC.OnTableSelected += (tableName) =>
                {
                    this.SelectedTableName = tableName;
                    this.DialogResult = DialogResult.OK;
                    this.Close(); 
                };
                flpTable.Controls.Add(tableUC);
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
