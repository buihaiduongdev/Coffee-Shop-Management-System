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
using Restaurant_Management_System.Backend;

namespace Restaurant_Management_System.Barista
{
    public partial class frmOrderDetail : Form
    {
        int PreID = -1;
        private string status;
        public frmOrderDetail(int preID, string status)
        {
            InitializeComponent();
            this.PreID = preID;
            this.status = status;
            loadOderInfo();

            if(status == "Completed")
            {
                btnCancel.Visible = false;
                btnCancel.Enabled = false;
            }
        }

        private void loadOderInfo(){
            if (PreID != -1) {
                string query = @"
                SELECT C.FirstName AS CusFirstName, C.LastName AS CusLastName, 
                E.FirstName AS EmpFirstName, E.LastName AS EmpLastName, 
                O.OrderID, O.OrderDay, O.OrderType
                FROM Orders as O
                INNER JOIN Preparations Pre ON O.OrderID = Pre.OrderID
                INNER JOIN Customers C ON O.CustomerID = C.CustomerID
                INNER JOIN Employees E ON O.EmployeeID = E.EmployeeID
                WHERE Pre.PreparationID = @PreID;
                ";

                SqlParameter[] parameters = new SqlParameter[]
                {
                 new SqlParameter("@PreID", PreID)
                };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 1) 
                {
                    DataRow row = dt.Rows[0]; // Lấy dòng đầu tiên
                    string oID = row["OrderID"].ToString(); // Lấy OrderID từ dòng
                    string cusName = row["CusFirstName"].ToString() + " " + row["CusLastName"].ToString();
                    string empName = row["EmpFirstName"].ToString() + " " + row["EmpLastName"].ToString();
                    string orderDayStr = Convert.ToDateTime(row["OrderDay"]).ToString("dd-MM-yyyy");
                    string oType = row["OrderType"].ToString();

                    lblOID.Text = oID;
                    lblCusName.Text = cusName;
                    lblImName.Text = empName;
                    lblODay.Text = orderDayStr;
                    lblOType.Text = oType;

                }
                else
                {
                    MessageBox.Show($"Dữ liệu không hợp lệ! Số dòng trả về: {dt.Rows.Count}");
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (PreID != -1)
            {
                string query = @"
                DELETE 
                FROM Preparations
                WHERE PreparationID = @PreID;
                ";
                SqlParameter[] parameters = new SqlParameter[]
                {
                 new SqlParameter("@PreID", PreID)
                };
                int rowEffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                this.Close();
                if (rowEffected > 0) {
                    frmKitchen.FrmKitchen.LoadOrders(status);
                }
            }
        }
    }
}
