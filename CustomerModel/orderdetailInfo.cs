using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.CustomerModel
{
    public class orderdetailInfo
    {
        private int productID;
        private decimal unitPrice;
        private int quantity;
        private int orderDetailID;
        private string ice;
        private string size;
        private string sugar;
    
        private DateTime orderdate;

        public orderdetailInfo() { }

        public orderdetailInfo( int productID, decimal unitPrice, int quantity,
                               int orderDetailID, string ice, string size, string sugar,
                                DateTime orderdate)
        {
            this.productID = productID;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
            this.orderDetailID = orderDetailID;
            this.ice = ice;
            this.size = size;
            this.sugar = sugar;

            this.orderdate = orderdate;
        }

        public int ProductID { get => productID; set => productID = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int OrderDetailID { get => orderDetailID; set => orderDetailID = value; }
        public string Ice { get => ice; set => ice = value; }
        public string Size { get => size; set => size = value; }
        public string Sugar { get => sugar; set => sugar = value; }
        public DateTime Orderdate { get => orderdate; set => orderdate = value; }
    }
}
