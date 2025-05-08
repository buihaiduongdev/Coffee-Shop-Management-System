using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Restaurant_Management_System.View
{
    public partial class frmHome : Form
    {
        private string language = ucLogin.languages;
        public frmHome()
        {
            InitializeComponent();
            setUpCirclePicture();
            setUpChart();

        }
        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);

            label4.Text = LocalizationHelper.GetString("label4");
            label8.Text = LocalizationHelper.GetString("label8");
            label11.Text = LocalizationHelper.GetString("label11");
            Lbl.Text = LocalizationHelper.GetString("Lbl");
            label18.Text = LocalizationHelper.GetString("label18");
            label7.Text = LocalizationHelper.GetString("label7");
            label1.Text = LocalizationHelper.GetString("label1");
            label10.Text = LocalizationHelper.GetString("label10");
            label3.Text = LocalizationHelper.GetString("label3");
            label17.Text = LocalizationHelper.GetString("label17");
            label20.Text = LocalizationHelper.GetString("label20");


        }

        public void setUpCirclePicture()
        {
            CrptUser.HoverState.FillColor = CrptUser.FillColor;
            CrptProcess.HoverState.FillColor = CrptProcess.FillColor;
            CrptDelivered.HoverState.FillColor = CrptDelivered.FillColor;
            CrptList.HoverState.FillColor = CrptList.FillColor;
        }

        public void setUpChart()
        {
            chartSales.Series.Clear();
            Series sales = chartSales.Series.Add("Sales");
            sales.ChartType = SeriesChartType.Column;
            sales.Color = Color.FromArgb(246, 215, 139);
            Series revenue = chartSales.Series.Add("Revenue");
            revenue.ChartType = SeriesChartType.Column;
            revenue.Color = Color.FromArgb(163, 122, 92);


            string[] days = { "26/3", "27/3", "28/3", "29/3", "30/3", "31/3", "1/4" };
            int[] productsSold = { 50, 70, 60, 80, 90, 110, 100 };
            double[] revenueData = { 100000, 150000, 125000, 180000, 200000, 250000, 220000 };

            for (int i = 0; i < revenueData.Length; i++)
            {
                sales.Points.AddXY(days[i], productsSold[i]);
                revenue.Points.AddXY(days[i], revenueData[i]);
            }

            chartSales.Legends[0].Docking = Docking.Top;
            chartSales.Legends[0].Alignment = StringAlignment.Center;
            chartSales.Legends[0].LegendStyle = LegendStyle.Row;

            chartSales.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            sales.YAxisType = AxisType.Secondary;
            revenue.YAxisType = AxisType.Primary;

            chartSales.BorderlineWidth = 0;
            chartSales.BorderlineColor = Color.Transparent;

            chartSales.Series[0].XAxisType = AxisType.Primary;
            chartSales.Series[1].XAxisType = AxisType.Primary;

            chartSales.ChartAreas[0].AxisX2.Enabled = AxisEnabled.False;
            chartSales.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartSales.ChartAreas[0].AxisX.MinorGrid.Enabled = false;

            chartSales.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartSales.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblDay.Text = DateTime.Now.ToString("dd");
            lblMonth.Text = DateTime.Now.ToString("MM");
            LoadData();
            load_language(language);
        }

        private void LoadData()
        {
            // 1. Số bàn trống
            string querytable = @"SELECT COUNT(*) FROM Tables WHERE Status = 'Empty' AND IsDeleted = 0";
            object ob = DatabaseHelper.ExecuteScalar(querytable);
            lblNumberNewOrder.Text = (ob == DBNull.Value || ob == null) ? "0" : ob.ToString();

            // 2. Tổng số ghế trống
            string queryEmpty = @"SELECT SUM(t.Capacity) FROM Tables AS t WHERE t.Status = 'Empty' AND t.IsDeleted = 0";
            object ob2 = DatabaseHelper.ExecuteScalar(queryEmpty);
            lblEmtySeat.Text = (ob2 == DBNull.Value || ob2 == null) ? "0" : string.Format("{0:0,0}", Convert.ToDouble(ob2));

            // 3. Tổng doanh thu hôm nay
            string queryTotalToday = @"SELECT SUM(od.Quantity * od.UnitPrice) AS TotalRevenue
                               FROM [Order Details] AS od
                               JOIN Orders AS o ON o.OrderID = od.OrderID
                               WHERE CAST(o.OrderDay AS DATE) = CAST(GETDATE() AS DATE)";
            object ob3 = DatabaseHelper.ExecuteScalar(queryTotalToday);
            string totalTodayStr = (ob3 == DBNull.Value || ob3 == null) ? "0" : string.Format("{0:+#,# VNĐ;-#,# VNĐ;0 VNĐ}", Convert.ToDouble(ob3));
            lblTotalToday.Text = totalTodayStr;
            lblTotalToday2.Text = totalTodayStr;

            // 4. Tổng số đơn hôm nay
            string queryTotalOrder = @"SELECT COUNT(OrderID) AS TotalOrders
                               FROM Orders
                               WHERE CAST(OrderDay AS DATE) = CAST(GETDATE() AS DATE)";
            object ob4 = DatabaseHelper.ExecuteScalar(queryTotalOrder);
            lblTotalOrder.Text = (ob4 == DBNull.Value || ob4 == null) ? "0" : ob4.ToString();
            // Top 3 sản phẩm bán chạy nhất trong tháng này
            string queryTop3BestSales = @"
                                        SELECT TOP 3 
                                            p.ProductName, 
                                            SUM(od.Quantity) AS TotalQuantity
                                        FROM Products AS p
                                        JOIN [Order Details] AS od ON p.ProductID = od.ProductID
                                        JOIN Orders AS o ON o.OrderID = od.OrderID
                                        WHERE 
                                            p.IsDeleted = 0 AND 
                                            MONTH(o.OrderDay) = MONTH(GETDATE()) AND 
                                            YEAR(o.OrderDay) = YEAR(GETDATE())
                                        GROUP BY p.ProductName
                                        ORDER BY SUM(od.Quantity) DESC
                                    ";

            DataTable dt = DatabaseHelper.ExecuteQuery(queryTop3BestSales);

            dgvBestSalers.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dgvBestSalers.Rows.Add(
                        row["ProductName"].ToString(),
                        Convert.ToInt32(row["TotalQuantity"])
                    );
                }
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào được bán trong tháng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Truy vấn doanh thu tháng này
            string queryCurrentMonth = @"
                        SELECT SUM(od.Quantity * od.UnitPrice) AS Revenue
                        FROM [Order Details] AS od
                        JOIN Orders AS o ON o.OrderID = od.OrderID
                        WHERE MONTH(o.OrderDay) = MONTH(GETDATE()) AND YEAR(o.OrderDay) = YEAR(GETDATE())";

            // Truy vấn doanh thu tháng trước
            string queryLastMonth = @"
                        SELECT SUM(od.Quantity * od.UnitPrice) AS Revenue
                        FROM [Order Details] AS od
                        JOIN Orders AS o ON o.OrderID = od.OrderID
                        WHERE MONTH(o.OrderDay) = MONTH(DATEADD(MONTH, -1, GETDATE()))
                        AND YEAR(o.OrderDay) = YEAR(DATEADD(MONTH, -1, GETDATE()))";

            object curObj = DatabaseHelper.ExecuteScalar(queryCurrentMonth);
            object lastObj = DatabaseHelper.ExecuteScalar(queryLastMonth);

            double curRevenue = (curObj == DBNull.Value || curObj == null) ? 0 : Convert.ToDouble(curObj);
            double lastRevenue = (lastObj == DBNull.Value || lastObj == null) ? 0 : Convert.ToDouble(lastObj);

            double percentChange = (lastRevenue == 0) ? 100 : ((curRevenue - lastRevenue) / lastRevenue) * 100;
            string percentStr = $"{Math.Round(percentChange, 1)}%";

            string revenueDiffStr = string.Format("{0:+#,# VNĐ;-#,# VNĐ;0 VNĐ}", curRevenue - lastRevenue);

            // Tính chênh lệch và phần trăm thay đổi
            double change = curRevenue - lastRevenue;

            // Hiển thị phần trăm thay đổi
            lblRate.Text = $"{Math.Round(percentChange, 1)}%";

            // Hiển thị số tiền chênh lệch, ví dụ: +$120,000 hoặc -$50,000
            lblRevenueChange.Text = string.Format("{0:+#,# VNĐ;-#,# VNĐ;0 VNĐ}", change);

            // Đổi màu: xanh nếu tăng, đỏ nếu giảm
            if (change >= 0)
            {
                lblRate.ForeColor = Color.Green;
                lblRevenueChange.ForeColor = Color.Green;
            }
            else
            {
                lblRate.ForeColor = Color.Red;
                lblRevenueChange.ForeColor = Color.Red;
            }

            string queryTotalEmployee = @"SELECT COUNT(*) FROM Employees WHERE IsDeleted = 0";
            object ob5 = DatabaseHelper.ExecuteScalar(queryTotalEmployee);
            lblTotalEmployee.Text = (ob5 == DBNull.Value || ob5 == null) ? "0" : ob5.ToString();
          //  lblTotalEmployee2.Text = (ob5 == DBNull.Value || ob5 == null) ? "0" : ob5.ToString();

            string queryMonth = @"

                WITH Last7Days AS (
                    SELECT CAST(GETDATE() AS DATE) AS Ngay
                    UNION ALL
                    SELECT DATEADD(DAY, -1, Ngay) FROM Last7Days WHERE DATEADD(DAY, -1, Ngay) >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
                )

                SELECT 
                    FORMAT(d.Ngay, 'dd/MM') AS Ngay,
                    ISNULL(SUM(od.Quantity), 0) AS Sales,
                    ISNULL(SUM(od.Quantity * od.UnitPrice), 0) AS Revenue
                FROM Last7Days d
                LEFT JOIN Orders o ON CAST(o.OrderDay AS DATE) = d.Ngay
                LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
                GROUP BY d.Ngay
                ORDER BY d.Ngay
                OPTION (MAXRECURSION 0);

";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(queryMonth);

            // Xóa series cũ
            chartSales.Series.Clear();

            // Tạo series mới
            Series seriesSales = chartSales.Series.Add("Sales");
            seriesSales.ChartType = SeriesChartType.Column;
            seriesSales.Color = Color.FromArgb(246, 215, 139); // Vàng nhạt

            Series seriesRevenue = chartSales.Series.Add("Revenue");
            seriesRevenue.ChartType = SeriesChartType.Column;
            seriesRevenue.Color = Color.FromArgb(163, 122, 92); // Nâu đậm

            double totalRevenue = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                string date = row["Ngay"].ToString();
                int sales = row["Sales"] == DBNull.Value ? 0 : Convert.ToInt32(row["Sales"]);
                double revenue = row["Revenue"] == DBNull.Value ? 0 : Convert.ToDouble(row["Revenue"]);

                seriesSales.Points.AddXY(date, sales);
                seriesRevenue.Points.AddXY(date, revenue);

                totalRevenue += revenue;
            }

            // Hiển thị tổng doanh thu dạng VNĐ
            lblWeeklyRevenue.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,0} VNĐ", totalRevenue);

        }

    }
}
