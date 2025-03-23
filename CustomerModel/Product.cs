using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Customer
{
    public class Product
    {
        public int productID;
        public string productName;
        public decimal price;
        public Image productImage;
        public string categoryName;

        private string ice;
        private string size;
        private string sugar;


        public Product(int productID, string productName, decimal price, Image image, string categoryName, string ice, string size, string sugar)
        {
            this.productID = productID;
            this.productName = productName;
            this.price = price;
            this.productImage = image;
            this.categoryName = categoryName;
            this.ice = ice;
            this.size = size;
            this.sugar = sugar;
        }

        public Product() { }

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public decimal Price { get => price; set => price = value; }
        public Image Image { get => productImage; set => productImage = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string Ice { get => ice; set => ice = value; }
        public string Size { get => size; set => size = value; }
        public string Sugar { get => sugar; set => sugar = value; }
    }
}
