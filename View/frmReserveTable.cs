using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class frmReserveTable : Form
    {
        private string language = ucLogin.languages;
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
            loadtable();
            load_language(language);
        }
        DataTable dt = new DataTable();
        private void loadtable()
        {
            string query = @"SELECT * FROM Tables WHERE IsDeleted = 0";
            dt = DatabaseHelper.ExecuteQuery(query);
            flpTable.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                Table tableData = new Table(
                    Convert.ToInt32(row["TableID"]),
                    Convert.ToInt32(row["Capacity"]),
                    (row["Status"]).ToString()
                );

                var tableUC = new ucTable(tableData);

                tableUC.OnTableSelected += (tableName) =>
                {
                    updateStatus(tableName, "Occupy");
                    loadtable();
                    SelectedTableName = tableName;
                };

                tableUC.OnTableUnselected += (tableName) =>
                {
                    updateStatus(tableName, "Empty");
                    loadtable();
                };


                flpTable.Controls.Add(tableUC);
            }
        }

        private void updateStatus(string tableName, string newStatus)
        {
            int tableID = int.Parse(tableName.Replace("Bàn ", ""));

            string query = @"UPDATE Tables 
                            SET Status = @Status 
                            WHERE TableID = @TableID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Status", newStatus),
                new SqlParameter("@TableID", tableID)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

            if (rowsAffected == 0)
            {
                if (language == "en") MessageBox.Show("Update failed");
                else MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);
            
            lblBookTable.Text = LocalizationHelper.GetString("lblBookTable");
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBookTable_Click(object sender, EventArgs e)
        {

        }



        //private void frmReserveTable_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    dt.Clear();
        //}
    }
}
