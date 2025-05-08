using Restaurant_Management_System.Backend;
using Restaurant_Management_System.Customer;
using Restaurant_Management_System.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurant_Management_System.CustomerModel
{
    public partial class ucTable : UserControl
    {
        private Table table;
        string status;
        private string language = ucLogin.languages;
        public event Action<string> OnTableSelected;
        public event Action<string> OnTableUnselected;
        int tableID;
        public ucTable(Table Table)
        {
            InitializeComponent();
            
            table = Table;
            tableID = table.TableID;    
            lblNameTable.Text = $"Table {table.TableID}";
            lblCapicity.Text = $"{table.Capacity} Capacity";
            status = table.Status?.Trim();
            
            load_language(language);
            UpdateUI();

        }

        private void btnReserve_Click(object sender, EventArgs e)
        {

            if (status.Trim().Equals("Empty", StringComparison.OrdinalIgnoreCase))
            {
                var result = MessageBox.Show(
                    "Bạn có chắc muốn chọn bàn này không?",
                    "Xác nhận chọn bàn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
 
                    OnTableSelected?.Invoke(lblNameTable.Text);
                }
            }
            else
            {
                var result = MessageBox.Show(
                    "Bạn có chắc hủy chọn bàn này không?",
                    "Xác nhận hủy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {

                    OnTableUnselected?.Invoke(lblNameTable.Text);
                }
            }
        }
        private void load_language(string languages)
        {
            LocalizationHelper.SetLanguage(languages);

            lblNameTable.Text = string.Format(LocalizationHelper.GetString("lblNameTable"), table.TableID);
            lblCapicity.Text = string.Format(LocalizationHelper.GetString("lblCapicity"), table.Capacity);
            //UpdateUI();
        }


        private void UpdateUI()
        {
            if (status.Trim() == "Empty")
            {
                btnReserve.Text = LocalizationHelper.GetString("btnReserveEmpty");
                btnReserve.FillColor = ColorTranslator.FromHtml("#3B9E62");
            }
            else
            {
                btnReserve.Text = LocalizationHelper.GetString("btnReserveChosen");
                btnReserve.FillColor = ColorTranslator.FromHtml("#F87168");
            }
            //if (status == "Empty")
            //{
            //    btnReserve.Text = "Chọn bàn";
            //    btnReserve.FillColor = ColorTranslator.FromHtml("#3B9E62");
            //}
            //else
            //{
            //    btnReserve.Text = "Đã chọn";
            //    btnReserve.FillColor = ColorTranslator.FromHtml("#F87168");
            //}
        }

        private void lblCapicity_Click(object sender, EventArgs e)
        {

        }
    }
}