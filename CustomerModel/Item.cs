using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Customer
{
    public class Item
    {
        private Product product;
        private int quantity;

        public Item(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
        public Item() { }

        public Product Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
