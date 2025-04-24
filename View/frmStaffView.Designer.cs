namespace Restaurant_Management_System.View
{
    partial class frmStaffView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaffView));
            this.dgvEmployee = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvedit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvdel = new System.Windows.Forms.DataGridViewImageColumn();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.restaurantDBDataSet = new Restaurant_Management_System.restaurantDBDataSet();
            this.employeesTableAdapter = new Restaurant_Management_System.restaurantDBDataSetTableAdapters.EmployeesTableAdapter();
            this.lblNumberEmployee = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnBarista = new Guna.UI2.WinForms.Guna2Button();
            this.btnWaiter = new Guna.UI2.WinForms.Guna2Button();
            this.btnReceptionist = new Guna.UI2.WinForms.Guna2Button();
            this.btnManager = new Guna.UI2.WinForms.Guna2Button();
            this.btnAllPeople = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveExcel = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSaveAsReport = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployee
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(184)))));
            this.dgvEmployee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEmployee.ColumnHeadersHeight = 40;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSno,
            this.dgvEmployeeID,
            this.dgvFullName,
            this.dgvPhone,
            this.dgvRole,
            this.dgvSalary,
            this.dgvedit,
            this.dgvdel});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(189)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployee.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEmployee.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(218)))), ((int)(((byte)(171)))));
            this.dgvEmployee.Location = new System.Drawing.Point(66, 184);
            this.dgvEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersVisible = false;
            this.dgvEmployee.RowHeadersWidth = 51;
            this.dgvEmployee.RowTemplate.Height = 35;
            this.dgvEmployee.Size = new System.Drawing.Size(1340, 500);
            this.dgvEmployee.TabIndex = 10;
            this.dgvEmployee.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Orange;
            this.dgvEmployee.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(184)))));
            this.dgvEmployee.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvEmployee.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvEmployee.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvEmployee.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvEmployee.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvEmployee.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(218)))), ((int)(((byte)(171)))));
            this.dgvEmployee.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.dgvEmployee.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEmployee.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEmployee.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEmployee.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvEmployee.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvEmployee.ThemeStyle.ReadOnly = false;
            this.dgvEmployee.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(207)))));
            this.dgvEmployee.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEmployee.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEmployee.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvEmployee.ThemeStyle.RowsStyle.Height = 35;
            this.dgvEmployee.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(189)))), ((int)(((byte)(97)))));
            this.dgvEmployee.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvEmployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellClick);
            // 
            // dgvSno
            // 
            this.dgvSno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvSno.FillWeight = 70F;
            this.dgvSno.HeaderText = "No.";
            this.dgvSno.MinimumWidth = 70;
            this.dgvSno.Name = "dgvSno";
            this.dgvSno.Width = 70;
            // 
            // dgvEmployeeID
            // 
            this.dgvEmployeeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvEmployeeID.FillWeight = 74.08759F;
            this.dgvEmployeeID.HeaderText = "EmployeeID";
            this.dgvEmployeeID.MinimumWidth = 6;
            this.dgvEmployeeID.Name = "dgvEmployeeID";
            this.dgvEmployeeID.Width = 179;
            // 
            // dgvFullName
            // 
            this.dgvFullName.FillWeight = 74.08759F;
            this.dgvFullName.HeaderText = "FullName";
            this.dgvFullName.MinimumWidth = 6;
            this.dgvFullName.Name = "dgvFullName";
            // 
            // dgvPhone
            // 
            this.dgvPhone.HeaderText = "Phone";
            this.dgvPhone.MinimumWidth = 6;
            this.dgvPhone.Name = "dgvPhone";
            // 
            // dgvRole
            // 
            this.dgvRole.HeaderText = "Role";
            this.dgvRole.MinimumWidth = 6;
            this.dgvRole.Name = "dgvRole";
            // 
            // dgvSalary
            // 
            this.dgvSalary.HeaderText = "Salary";
            this.dgvSalary.MinimumWidth = 6;
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.ReadOnly = true;
            // 
            // dgvedit
            // 
            this.dgvedit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvedit.FillWeight = 50F;
            this.dgvedit.HeaderText = "Action";
            this.dgvedit.Image = global::Restaurant_Management_System.Properties.Resources.change;
            this.dgvedit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvedit.MinimumWidth = 60;
            this.dgvedit.Name = "dgvedit";
            this.dgvedit.Width = 60;
            // 
            // dgvdel
            // 
            this.dgvdel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvdel.FillWeight = 50F;
            this.dgvdel.HeaderText = "";
            this.dgvdel.Image = global::Restaurant_Management_System.Properties.Resources.delete;
            this.dgvdel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvdel.MinimumWidth = 50;
            this.dgvdel.Name = "dgvdel";
            this.dgvdel.Width = 56;
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataMember = "Employees";
            this.employeesBindingSource.DataSource = this.restaurantDBDataSet;
            // 
            // restaurantDBDataSet
            // 
            this.restaurantDBDataSet.DataSetName = "restaurantDBDataSet";
            this.restaurantDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeesTableAdapter
            // 
            this.employeesTableAdapter.ClearBeforeFill = true;
            // 
            // lblNumberEmployee
            // 
            this.lblNumberEmployee.AutoSize = true;
            this.lblNumberEmployee.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberEmployee.Location = new System.Drawing.Point(56, 23);
            this.lblNumberEmployee.Name = "lblNumberEmployee";
            this.lblNumberEmployee.Size = new System.Drawing.Size(340, 59);
            this.lblNumberEmployee.TabIndex = 14;
            this.lblNumberEmployee.Text = "Employee [140]";
            // 
            // btnAdd
            // 
            this.btnAdd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.BorderThickness = 1;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(783, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 42);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "+ Add Employee";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBarista
            // 
            this.btnBarista.BorderColor = System.Drawing.Color.Silver;
            this.btnBarista.BorderRadius = 5;
            this.btnBarista.BorderThickness = 1;
            this.btnBarista.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBarista.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBarista.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBarista.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBarista.FillColor = System.Drawing.Color.Silver;
            this.btnBarista.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarista.ForeColor = System.Drawing.Color.White;
            this.btnBarista.Location = new System.Drawing.Point(1099, 121);
            this.btnBarista.Name = "btnBarista";
            this.btnBarista.Size = new System.Drawing.Size(127, 42);
            this.btnBarista.TabIndex = 19;
            this.btnBarista.Text = "Barista";
            this.btnBarista.Click += new System.EventHandler(this.btnBarista_Click);
            // 
            // btnWaiter
            // 
            this.btnWaiter.BorderColor = System.Drawing.Color.Silver;
            this.btnWaiter.BorderRadius = 5;
            this.btnWaiter.BorderThickness = 1;
            this.btnWaiter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnWaiter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnWaiter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnWaiter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnWaiter.FillColor = System.Drawing.Color.Silver;
            this.btnWaiter.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWaiter.ForeColor = System.Drawing.Color.White;
            this.btnWaiter.Location = new System.Drawing.Point(1250, 121);
            this.btnWaiter.Name = "btnWaiter";
            this.btnWaiter.Size = new System.Drawing.Size(127, 42);
            this.btnWaiter.TabIndex = 20;
            this.btnWaiter.Text = "Waiter";
            this.btnWaiter.Click += new System.EventHandler(this.btnWaiter_Click);
            // 
            // btnReceptionist
            // 
            this.btnReceptionist.BorderColor = System.Drawing.Color.Silver;
            this.btnReceptionist.BorderRadius = 5;
            this.btnReceptionist.BorderThickness = 1;
            this.btnReceptionist.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReceptionist.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReceptionist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReceptionist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReceptionist.FillColor = System.Drawing.Color.Silver;
            this.btnReceptionist.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceptionist.ForeColor = System.Drawing.Color.White;
            this.btnReceptionist.Location = new System.Drawing.Point(797, 121);
            this.btnReceptionist.Name = "btnReceptionist";
            this.btnReceptionist.Size = new System.Drawing.Size(127, 42);
            this.btnReceptionist.TabIndex = 21;
            this.btnReceptionist.Text = "Receptionist";
            this.btnReceptionist.Click += new System.EventHandler(this.btnReceptionist_Click);
            // 
            // btnManager
            // 
            this.btnManager.BorderColor = System.Drawing.Color.Silver;
            this.btnManager.BorderRadius = 5;
            this.btnManager.BorderThickness = 1;
            this.btnManager.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnManager.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnManager.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnManager.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnManager.FillColor = System.Drawing.Color.Silver;
            this.btnManager.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManager.ForeColor = System.Drawing.Color.White;
            this.btnManager.Location = new System.Drawing.Point(948, 121);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(127, 42);
            this.btnManager.TabIndex = 18;
            this.btnManager.Text = "Manager";
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnAllPeople
            // 
            this.btnAllPeople.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAllPeople.BorderRadius = 5;
            this.btnAllPeople.BorderThickness = 1;
            this.btnAllPeople.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAllPeople.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAllPeople.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAllPeople.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAllPeople.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAllPeople.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllPeople.ForeColor = System.Drawing.Color.White;
            this.btnAllPeople.Location = new System.Drawing.Point(646, 121);
            this.btnAllPeople.Name = "btnAllPeople";
            this.btnAllPeople.Size = new System.Drawing.Size(127, 42);
            this.btnAllPeople.TabIndex = 17;
            this.btnAllPeople.Text = "All people";
            this.btnAllPeople.Click += new System.EventHandler(this.btnAllPeople_Click);
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.BorderRadius = 5;
            this.btnSaveExcel.BorderThickness = 2;
            this.btnSaveExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveExcel.FillColor = System.Drawing.Color.White;
            this.btnSaveExcel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExcel.ForeColor = System.Drawing.Color.Black;
            this.btnSaveExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveExcel.Image")));
            this.btnSaveExcel.ImageOffset = new System.Drawing.Point(40, 0);
            this.btnSaveExcel.Location = new System.Drawing.Point(995, 40);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(180, 42);
            this.btnSaveExcel.TabIndex = 22;
            this.btnSaveExcel.Text = "Save as ";
            this.btnSaveExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSaveExcel.TextOffset = new System.Drawing.Point(30, 0);
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
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
            this.txtSearch.Location = new System.Drawing.Point(66, 121);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Search by, id, name, phone, role...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(557, 42);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSaveAsReport
            // 
            this.btnSaveAsReport.BorderRadius = 5;
            this.btnSaveAsReport.BorderThickness = 2;
            this.btnSaveAsReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveAsReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveAsReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveAsReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveAsReport.FillColor = System.Drawing.Color.White;
            this.btnSaveAsReport.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAsReport.ForeColor = System.Drawing.Color.Black;
            this.btnSaveAsReport.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAsReport.Image")));
            this.btnSaveAsReport.ImageOffset = new System.Drawing.Point(40, 0);
            this.btnSaveAsReport.Location = new System.Drawing.Point(1197, 40);
            this.btnSaveAsReport.Name = "btnSaveAsReport";
            this.btnSaveAsReport.Size = new System.Drawing.Size(180, 42);
            this.btnSaveAsReport.TabIndex = 23;
            this.btnSaveAsReport.Text = "Save as ";
            this.btnSaveAsReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSaveAsReport.TextOffset = new System.Drawing.Point(30, 0);
            this.btnSaveAsReport.Click += new System.EventHandler(this.btnSaveAsReport_Click);
            // 
            // frmStaffView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1500, 744);
            this.Controls.Add(this.btnSaveAsReport);
            this.Controls.Add(this.btnSaveExcel);
            this.Controls.Add(this.btnWaiter);
            this.Controls.Add(this.btnAllPeople);
            this.Controls.Add(this.btnBarista);
            this.Controls.Add(this.btnReceptionist);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblNumberEmployee);
            this.Controls.Add(this.dgvEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmStaffView";
            this.Text = "frmStaffView";
            this.Load += new System.EventHandler(this.frmStaffView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvEmployee;
        private restaurantDBDataSet restaurantDBDataSet;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private restaurantDBDataSetTableAdapters.EmployeesTableAdapter employeesTableAdapter;
        private System.Windows.Forms.Label lblNumberEmployee;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnBarista;
        private Guna.UI2.WinForms.Guna2Button btnWaiter;
        private Guna.UI2.WinForms.Guna2Button btnReceptionist;
        private Guna.UI2.WinForms.Guna2Button btnManager;
        private Guna.UI2.WinForms.Guna2Button btnAllPeople;
        private Guna.UI2.WinForms.Guna2Button btnSaveExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSalary;
        private System.Windows.Forms.DataGridViewImageColumn dgvedit;
        private System.Windows.Forms.DataGridViewImageColumn dgvdel;
        private Guna.UI2.WinForms.Guna2Button btnSaveAsReport;
    }
}