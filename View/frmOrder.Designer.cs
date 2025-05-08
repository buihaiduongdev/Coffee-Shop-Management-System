namespace Restaurant_Management_System.Model
{
    partial class frmOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.dgvBill = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvview = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblBillList = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.guna20HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna20HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNumberOder = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.btnDinein = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAllType = new Guna.UI2.WinForms.Guna2Button();
            this.btnTakeAway = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBill
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBill.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvBill.ColumnHeadersHeight = 40;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSrNo,
            this.dgvOrderID,
            this.dgvOrderType,
            this.dgvOrderDay,
            this.dgvTotal,
            this.dgvview});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBill.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBill.Location = new System.Drawing.Point(80, 271);
            this.dgvBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.RowHeadersVisible = false;
            this.dgvBill.RowHeadersWidth = 51;
            this.dgvBill.RowTemplate.Height = 35;
            this.dgvBill.Size = new System.Drawing.Size(1423, 337);
            this.dgvBill.TabIndex = 9;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBill.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.dgvBill.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBill.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBill.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBill.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBill.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBill.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBill.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvBill.ThemeStyle.ReadOnly = false;
            this.dgvBill.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBill.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBill.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBill.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBill.ThemeStyle.RowsStyle.Height = 35;
            this.dgvBill.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBill.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellClick);
            // 
            // dgvSrNo
            // 
            this.dgvSrNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvSrNo.FillWeight = 70F;
            this.dgvSrNo.HeaderText = "No.";
            this.dgvSrNo.MinimumWidth = 70;
            this.dgvSrNo.Name = "dgvSrNo";
            this.dgvSrNo.Width = 70;
            // 
            // dgvOrderID
            // 
            this.dgvOrderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvOrderID.FillWeight = 74.08759F;
            this.dgvOrderID.HeaderText = "ID";
            this.dgvOrderID.MinimumWidth = 6;
            this.dgvOrderID.Name = "dgvOrderID";
            this.dgvOrderID.Width = 170;
            // 
            // dgvOrderType
            // 
            this.dgvOrderType.HeaderText = "Type";
            this.dgvOrderType.MinimumWidth = 6;
            this.dgvOrderType.Name = "dgvOrderType";
            // 
            // dgvOrderDay
            // 
            this.dgvOrderDay.HeaderText = "Day";
            this.dgvOrderDay.MinimumWidth = 6;
            this.dgvOrderDay.Name = "dgvOrderDay";
            // 
            // dgvTotal
            // 
            this.dgvTotal.HeaderText = "Total";
            this.dgvTotal.MinimumWidth = 6;
            this.dgvTotal.Name = "dgvTotal";
            // 
            // dgvview
            // 
            this.dgvview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvview.FillWeight = 50F;
            this.dgvview.HeaderText = "View";
            this.dgvview.Image = global::Restaurant_Management_System.Properties.Resources.edit1;
            this.dgvview.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvview.MinimumWidth = 50;
            this.dgvview.Name = "dgvview";
            this.dgvview.Width = 50;
            // 
            // lblBillList
            // 
            this.lblBillList.AutoSize = false;
            this.lblBillList.BackColor = System.Drawing.Color.Transparent;
            this.lblBillList.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillList.Location = new System.Drawing.Point(80, 36);
            this.lblBillList.Name = "lblBillList";
            this.lblBillList.Size = new System.Drawing.Size(429, 53);
            this.lblBillList.TabIndex = 10;
            this.lblBillList.Text = "BILL LIST";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Controls.Add(this.lblRevenue);
            this.guna2Panel1.Controls.Add(this.guna20HtmlLabel1);
            this.guna2Panel1.Location = new System.Drawing.Point(1158, 23);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(314, 141);
            this.guna2Panel1.TabIndex = 11;
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblRevenue.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(215)))), ((int)(((byte)(166)))));
            this.lblRevenue.Location = new System.Drawing.Point(16, 59);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(256, 45);
            this.lblRevenue.TabIndex = 14;
            this.lblRevenue.Text = "+ 120.000 VNĐ";
            this.lblRevenue.Click += new System.EventHandler(this.label1_Click);
            // 
            // guna20HtmlLabel1
            // 
            this.guna20HtmlLabel1.AutoSize = false;
            this.guna20HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna20HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna20HtmlLabel1.Location = new System.Drawing.Point(3, 3);
            this.guna20HtmlLabel1.Name = "guna20HtmlLabel1";
            this.guna20HtmlLabel1.Size = new System.Drawing.Size(342, 39);
            this.guna20HtmlLabel1.TabIndex = 12;
            this.guna20HtmlLabel1.Text = "TOTAL REVENUE";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(206)))));
            this.guna2Panel2.Controls.Add(this.guna20HtmlLabel2);
            this.guna2Panel2.Controls.Add(this.lblNumberOder);
            this.guna2Panel2.Location = new System.Drawing.Point(814, 23);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(305, 141);
            this.guna2Panel2.TabIndex = 12;
            // 
            // guna20HtmlLabel2
            // 
            this.guna20HtmlLabel2.AutoSize = false;
            this.guna20HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna20HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna20HtmlLabel2.Location = new System.Drawing.Point(15, 3);
            this.guna20HtmlLabel2.Name = "guna20HtmlLabel2";
            this.guna20HtmlLabel2.Size = new System.Drawing.Size(226, 39);
            this.guna20HtmlLabel2.TabIndex = 12;
            this.guna20HtmlLabel2.Text = "QUANTITY";
            // 
            // lblNumberOder
            // 
            this.lblNumberOder.AutoSize = true;
            this.lblNumberOder.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOder.Location = new System.Drawing.Point(111, 45);
            this.lblNumberOder.Name = "lblNumberOder";
            this.lblNumberOder.Size = new System.Drawing.Size(54, 62);
            this.lblNumberOder.TabIndex = 13;
            this.lblNumberOder.Text = "3";
            this.lblNumberOder.Click += new System.EventHandler(this.lblNumberOder_Click);
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(505, 202);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(200, 38);
            this.dtDate.TabIndex = 13;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // btnDinein
            // 
            this.btnDinein.BorderColor = System.Drawing.Color.Silver;
            this.btnDinein.BorderRadius = 5;
            this.btnDinein.BorderThickness = 1;
            this.btnDinein.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDinein.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDinein.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDinein.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDinein.FillColor = System.Drawing.Color.Silver;
            this.btnDinein.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDinein.ForeColor = System.Drawing.Color.White;
            this.btnDinein.Location = new System.Drawing.Point(347, 198);
            this.btnDinein.Name = "btnDinein";
            this.btnDinein.Size = new System.Drawing.Size(127, 42);
            this.btnDinein.TabIndex = 22;
            this.btnDinein.Text = "Dine-in";
            this.btnDinein.Click += new System.EventHandler(this.btnDinein_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtSearch.BorderRadius = 5;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.Location = new System.Drawing.Point(1082, 202);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Search by, id, type,...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(557, 42);
            this.txtSearch.TabIndex = 23;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // btnAllType
            // 
            this.btnAllType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAllType.BorderRadius = 5;
            this.btnAllType.BorderThickness = 1;
            this.btnAllType.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAllType.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAllType.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAllType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAllType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAllType.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllType.ForeColor = System.Drawing.Color.White;
            this.btnAllType.Location = new System.Drawing.Point(81, 198);
            this.btnAllType.Name = "btnAllType";
            this.btnAllType.Size = new System.Drawing.Size(127, 42);
            this.btnAllType.TabIndex = 24;
            this.btnAllType.Text = "All Type";
            this.btnAllType.Click += new System.EventHandler(this.btnAllType_Click);
            // 
            // btnTakeAway
            // 
            this.btnTakeAway.BorderColor = System.Drawing.Color.Silver;
            this.btnTakeAway.BorderRadius = 5;
            this.btnTakeAway.BorderThickness = 1;
            this.btnTakeAway.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTakeAway.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTakeAway.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTakeAway.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTakeAway.FillColor = System.Drawing.Color.Silver;
            this.btnTakeAway.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeAway.ForeColor = System.Drawing.Color.White;
            this.btnTakeAway.Location = new System.Drawing.Point(214, 198);
            this.btnTakeAway.Name = "btnTakeAway";
            this.btnTakeAway.Size = new System.Drawing.Size(127, 42);
            this.btnTakeAway.TabIndex = 25;
            this.btnTakeAway.Text = "Take Away";
            this.btnTakeAway.Click += new System.EventHandler(this.btnTakeAway_Click);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1623, 639);
            this.Controls.Add(this.btnTakeAway);
            this.Controls.Add(this.btnAllType);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDinein);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblBillList);
            this.Controls.Add(this.dgvBill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmOrder";
            this.Text = "NV";
            this.Load += new System.EventHandler(this.frmBillList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public Guna.UI2.WinForms.Guna2DataGridView dgvBill;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBillList;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna20HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna20HtmlLabel2;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblNumberOder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTotal;
        private System.Windows.Forms.DataGridViewImageColumn dgvview;
        private System.Windows.Forms.DateTimePicker dtDate;
        private Guna.UI2.WinForms.Guna2Button btnDinein;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnAllType;
        private Guna.UI2.WinForms.Guna2Button btnTakeAway;
    }
}