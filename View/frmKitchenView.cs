using Restaurant_Management_System.Backend;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.View
{
    public partial class frmKitchenView : Form
    {
        public frmKitchenView()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmKitchenView_Load(object sender, EventArgs e)
        {
            GetOrders();
        }
        //system 8: phut 5:15
        private void GetOrders()
        {
            flowLayoutPanel1.Controls.Clear();
            string query = "SELECT * FROM Preparations";
            DataTable dt1 = DatabaseHelper.ExecuteQuery(query);

            FlowLayoutPanel p1;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                p1 = new FlowLayoutPanel();
                p1.AutoSize = true;
                p1.Width = 230;
                p1.Height = 350;
                p1.FlowDirection = FlowDirection.TopDown;
                p1.BorderStyle = BorderStyle.FixedSingle;
                p1.Margin = new Padding(10, 10, 10, 10);

                FlowLayoutPanel p2 = new FlowLayoutPanel();
                p2.BackColor = Color.FromArgb(50, 55, 89);
                p2.AutoSize = true;
                p2.Width = 230;
                p2.Height = 350;
                p2.FlowDirection = FlowDirection.TopDown;
                p2.BorderStyle = BorderStyle.FixedSingle;
                p2.Margin = new Padding(10, 10, 10, 10);

                Label lb1 = new Label();
                lb1.ForeColor = Color.White;
                lb1.Margin = new Padding(10, 10, 3, 0);
                lb1.AutoSize = true;

                Label lb2 = new Label();
                lb2.ForeColor = Color.White;
                lb2.Margin = new Padding(10, 5, 3, 0);
                lb2.AutoSize = true;

                Label lb3 = new Label();
                lb3.ForeColor = Color.White;
                lb3.Margin = new Padding(10, 5, 3, 0);
                lb3.AutoSize = true;

                Label lb4 = new Label();
                lb4.ForeColor = Color.White;
                lb4.Margin = new Padding(10, 5, 3, 0);
                lb4.AutoSize = true;

                Label lb5 = new Label();
                lb5.ForeColor = Color.White;
                lb5.Margin = new Padding(10, 5, 3, 0);
                lb5.AutoSize = true;

                lb1.Text = "Order Time : " + dt1.Rows[1]["OrderID"].ToString();
                lb2.Text = "Product  : " + dt1.Rows[1]["ProductID"].ToString();
                lb3.Text = "Waiter : " + dt1.Rows[1]["EmployeeID"].ToString();
                lb4.Text = "Status : " + dt1.Rows[1]["Status"].ToString();
                lb5.Text = "End time : " + dt1.Rows[1]["EndTime"].ToString();


                p2.Controls.Add(lb1);
                p2.Controls.Add(lb2);
                p2.Controls.Add(lb3);
                p2.Controls.Add(lb4);
                p2.Controls.Add(lb5);
                p1.Controls.Add(p2);
                flowLayoutPanel1.Controls.Add(p1);

                //int mid = 0;
                //mid = Convert.ToInt32(dt1.Rows[i]["MainID"].ToString());

                //string qry2 = @"Select * from tblMain 
                //                inner join tblDetails d on m.MainID = d.MainID
                //                inner join products p on p.pID = d.proID
                //                 where m.MainID = " + mid + "";

                //SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                //DataTable dt2 = new DataTable();
                //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                //da2.Fill(dt2);

                //for (int j = 0; j < dt2.Rows.Count; j++)
                //{
                //    Label lb5 = new Label();
                //    lb5.ForeColor = Color.White;
                //    lb5.Margin = new Padding(10, 5, 3, 0);
                //    lb5.AutoSize = true;

                //    int no = j + 1;

                //    lb5.Text = no + ". " + dt2.Rows[j]["pName"].ToString() + " - " + dt2.Rows[j]["qty"].ToString();
                //    p1.Controls.Add(lb5);
                //}
                //Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                //b.AutoRoundedCorners = true;
                //b.Size = new Size(100, 35);
                //b.FillColor = Color.FromArgb(241, 85, 126);
                //b.Margin = new Padding(60, 5, 3, 10);
                //b.Text = "Complete";
                //b.Tag = dt1.Rows[i]["MainID"].ToString();

                //b.Click += new EventHandler(b_click);
            }
        }
        //private void b_click(object sender, EventArgs e)
        //{
        //    int id = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString());
        //    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
        //    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
        //    if (Guna2MessageDialog1.Show("Bạn có muốn xóa không?") == DialogResult.Yes)
        //    {
        //        string qry = @"Update tblMain set status = 'Complete' where MainID = @ID";
        //        Hashtable ht = new Hashtable();
        //        ht.Add("@ID", id);

        //        if(MainClass.SQl(qry, ht) > 0)
        //        {
        //            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
        //            guna2MessageDialog1.Show("Saved Successfully");
        //        }
        //        GetOrders();
        //    }
        //}
    }

}
