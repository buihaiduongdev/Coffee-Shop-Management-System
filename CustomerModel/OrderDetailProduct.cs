using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.CustomerModel
{
    public class OrderDetailProduct
    {
        // Thông tin từ Order Details
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Ice { get; set; }
        public string Sugar { get; set; }
        public string Size { get; set; }
        public DateTime OrderDate { get; set; }

        // Thông tin từ Product
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public byte[] ProductImage { get; set; }

        // Tính toán
        public decimal TotalPrice => UnitPrice * Quantity;
        public string PriceFormatted => UnitPrice.ToString("N0") + " VNĐ";
        public string TotalPriceFormatted => TotalPrice.ToString("N0") + " VNĐ";
    }
}
