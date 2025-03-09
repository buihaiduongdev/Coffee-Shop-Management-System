using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.Customer
{
    public partial class frmCart : Form
    {

        BindingList<Item> itemList;
        public frmCart(BindingList<Item> cart)
        {
            InitializeComponent();
            itemList = cart;
            itemList.ListChanged += (s, e) => loadItem();
        }


        private void frmCart_Load(object sender, EventArgs e)
        {
            loadItem();
            config();
        }
        private void config()
        {
            dgvCart.AlternatingRowsDefaultCellStyle = null;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCart.Height = dgvCart.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + dgvCart.ColumnHeadersHeight;
            dgvCart.Columns["colQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void loadItem()
        {
            var rowTotalPrice = new
            {
                ProductName = "Tổng",
                Price = itemList.Sum(item => item.Product.Price * item.Quantity),
                Quantity = itemList.Sum(item => item.Quantity)
            };

            dgvCart.DataSource = itemList.Select(item => new
            {
                ProductName = item.Product.ProductName,
                Price = item.Product.Price,
                Quantity = item.Quantity
            }).Append(rowTotalPrice).ToList();

            var totalRow = dgvCart.Rows[dgvCart.Rows.Count - 1];
            totalRow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#804000"); ;
            totalRow.DefaultCellStyle.ForeColor = Color.White;
            totalRow.DefaultCellStyle.Font = new Font("Jetbrains Mono", 13, FontStyle.Bold);

            DataGridViewImageColumn colDelete = (DataGridViewImageColumn)dgvCart.Columns["colDelete"];
            colDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
            for (int i = 0; i < dgvCart.Rows.Count; i++) 
            {
                dgvCart.Rows[i].Cells["colDelete"].Value = Properties.Resources.delete;
            }



        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["colDelete"].Index && e.RowIndex >= 0)
            { 
                if (e.RowIndex == itemList.Count)
                {
                    itemList.Clear();
                } else
                {
                    itemList.RemoveAt(e.RowIndex);
                }
            }
            loadItem();
        }
    }
}
