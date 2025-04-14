using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class ucItemOrder : UserControl
    {
        public ucItemOrder()
        {
            InitializeComponent();
        }
        public void SetData(OrderDetailProduct detail)
        {
            lblProductName.Text = $"Tên món: {detail?.ProductName ?? "Không có tên"}";
            lblPrice.Text = $"Đơn giá: {detail?.PriceFormatted ?? "0"}";
            lblQuantity.Text = $"Số lượng: {detail?.Quantity.ToString() ?? "0"}";
            lblIce.Text = $"Đá: {detail?.Ice ?? "Không có"}";
            lblSugar.Text = $"Đường: {detail?.Sugar ?? "Không có"}";
            lblSize.Text = $"Size: {detail?.Size ?? "Không có"}";
            lblTotal.Text = $"Thành tiền: {detail.TotalPriceFormatted.ToString()}";

            if (detail?.ProductImage != null)
            {
                using (var ms = new MemoryStream(detail.ProductImage))
                {
                    picProduct.Image = Image.FromStream(ms);
                }
            }
            else
            {
                picProduct.Image = null;
            }
        }
    }
}
