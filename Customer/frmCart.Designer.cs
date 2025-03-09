namespace Restaurant_Management_System.Customer
{
    partial class frmCart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(150)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("JetBrains Mono NL", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("JetBrains Mono NL", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeight = 50;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.colPrice,
            this.colQuantity,
            this.colDelete});
            this.dgvCart.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(150)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgvCart.Location = new System.Drawing.Point(131, 12);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(150)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(150)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCart.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCart.RowTemplate.Height = 40;
            this.dgvCart.Size = new System.Drawing.Size(515, 461);
            this.dgvCart.TabIndex = 3;
            this.dgvCart.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.GreenSea;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(150)))), ((int)(((byte)(63)))));
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("JetBrains Mono NL", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCart.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("JetBrains Mono NL", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCart.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvCart.ThemeStyle.ReadOnly = false;
            this.dgvCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(150)))), ((int)(((byte)(63)))));
            this.dgvCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCart.ThemeStyle.RowsStyle.Height = 40;
            this.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellClick);
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.FillWeight = 216.8008F;
            this.colProductName.HeaderText = "Tên";
            this.colProductName.MinimumWidth = 240;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 240;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.FillWeight = 76.14214F;
            this.colPrice.HeaderText = "Giá";
            this.colPrice.MinimumWidth = 75;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 90;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.FillWeight = 7.057093F;
            this.colQuantity.HeaderText = "Số lượng";
            this.colQuantity.MinimumWidth = 115;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 115;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.MinimumWidth = 20;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDelete.Width = 20;
            // 
            // frmCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 504);
            this.Controls.Add(this.dgvCart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCart";
            this.Text = "frmCart";
            this.Load += new System.EventHandler(this.frmCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
    }
}