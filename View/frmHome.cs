using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Restaurant_Management_System.View
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            setUpCirclePicture();
            setUpChart();

        }

        public void setUpCirclePicture()
        {
            CrptUser.HoverState.FillColor = CrptUser.FillColor;
            CrptProcess.HoverState.FillColor = CrptProcess.FillColor;
            CrptDelivered.HoverState.FillColor = CrptDelivered.FillColor;
            CrptList.HoverState.FillColor = CrptList.FillColor;
            CrptNumberNewOrder.HoverState.FillColor = CrptNumberNewOrder.FillColor;
        }

        public void setUpChart()
        {
            chartSalesWeek.Series.Clear();
            Series sales = chartSalesWeek.Series.Add("Sales");
            sales.ChartType = SeriesChartType.Column;
            sales.Color = Color.FromArgb(246, 215, 139);
            Series revenue = chartSalesWeek.Series.Add("Revenue");
            revenue.ChartType = SeriesChartType.Column;
            revenue.Color = Color.FromArgb(163, 122, 92);


            string[] days = { "26/3", "27/3", "28/3", "29/3", "30/3", "31/3", "1/4" };
            int[] productsSold = { 50, 70, 60, 80, 90, 110, 100 };
            double[] revenueData = { 10000, 15000, 12500, 18000, 20000, 25000, 22000 };

            for (int i = 0; i < revenueData.Length; i++)
            {
                sales.Points.AddXY(days[i], productsSold[i]);
                revenue.Points.AddXY(days[i],revenueData[i]);
            }

            chartSalesWeek.Legends[0].Docking = Docking.Top;
            chartSalesWeek.Legends[0].Alignment = StringAlignment.Center;
            chartSalesWeek.Legends[0].LegendStyle = LegendStyle.Row;

            chartSalesWeek.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            sales.YAxisType = AxisType.Secondary;
            revenue.YAxisType = AxisType.Primary;

            chartSalesWeek.BorderlineWidth = 0;
            chartSalesWeek.BorderlineColor = Color.Transparent;

            chartSalesWeek.Series[0].XAxisType = AxisType.Primary;
            chartSalesWeek.Series[1].XAxisType = AxisType.Primary;

            chartSalesWeek.ChartAreas[0].AxisX2.Enabled = AxisEnabled.False;
            chartSalesWeek.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartSalesWeek.ChartAreas[0].AxisX.MinorGrid.Enabled = false;

            chartSalesWeek.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartSalesWeek.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
        }

        private void chartSalesWeek_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            HitTestResult result = chartSalesWeek.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;

                double sales = chartSalesWeek.Series[0].Points[index].YValues[0];
                double revenue = chartSalesWeek.Series[1].Points[index].YValues[0];
                string day = chartSalesWeek.Series[0].Points[index].XValue.ToString();

                toolTip.Show($"Date {day}\nSales: {sales} Products\nRevenue: ${revenue}", chartSalesWeek, e.X, e.Y - 15);
            }
            else toolTip.Hide(chartSalesWeek);
        }
    }
}
