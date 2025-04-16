namespace Restaurant_Management_System.CustomerModel
{
    partial class frmInfoOrder
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReceived = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnWaitConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirmed = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnFeedback = new Guna.UI2.WinForms.Guna2Button();
            this.pbBack = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(39, 181);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1368, 624);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btnReceived
            // 
            this.btnReceived.BorderRadius = 20;
            this.btnReceived.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReceived.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReceived.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReceived.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReceived.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(60)))), ((int)(((byte)(20)))));
            this.btnReceived.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceived.ForeColor = System.Drawing.Color.White;
            this.btnReceived.Location = new System.Drawing.Point(3, 3);
            this.btnReceived.Name = "btnReceived";
            this.btnReceived.PressedDepth = 25;
            this.btnReceived.Size = new System.Drawing.Size(255, 64);
            this.btnReceived.TabIndex = 0;
            this.btnReceived.Text = "Đã nhận";
            this.btnReceived.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.flowLayoutPanel2.Controls.Add(this.btnReceived);
            this.flowLayoutPanel2.Controls.Add(this.btnWaitConfirm);
            this.flowLayoutPanel2.Controls.Add(this.btnConfirmed);
            this.flowLayoutPanel2.Controls.Add(this.btnCancel);
            this.flowLayoutPanel2.Controls.Add(this.btnFeedback);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(39, 90);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1362, 73);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btnWaitConfirm
            // 
            this.btnWaitConfirm.BorderRadius = 20;
            this.btnWaitConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnWaitConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnWaitConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnWaitConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnWaitConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(60)))), ((int)(((byte)(20)))));
            this.btnWaitConfirm.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWaitConfirm.ForeColor = System.Drawing.Color.White;
            this.btnWaitConfirm.Location = new System.Drawing.Point(264, 3);
            this.btnWaitConfirm.Name = "btnWaitConfirm";
            this.btnWaitConfirm.PressedDepth = 25;
            this.btnWaitConfirm.Size = new System.Drawing.Size(259, 64);
            this.btnWaitConfirm.TabIndex = 1;
            this.btnWaitConfirm.Text = "Chờ xác nhận";
            this.btnWaitConfirm.Click += new System.EventHandler(this.btnWaitConfirm_Click);
            // 
            // btnConfirmed
            // 
            this.btnConfirmed.BorderRadius = 20;
            this.btnConfirmed.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmed.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmed.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirmed.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirmed.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(60)))), ((int)(((byte)(20)))));
            this.btnConfirmed.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmed.ForeColor = System.Drawing.Color.White;
            this.btnConfirmed.Location = new System.Drawing.Point(529, 3);
            this.btnConfirmed.Name = "btnConfirmed";
            this.btnConfirmed.PressedDepth = 25;
            this.btnConfirmed.Size = new System.Drawing.Size(265, 64);
            this.btnConfirmed.TabIndex = 2;
            this.btnConfirmed.Text = "Hoàn thành ";
            this.btnConfirmed.Click += new System.EventHandler(this.btnConfirmed_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 20;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(60)))), ((int)(((byte)(20)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(800, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PressedDepth = 25;
            this.btnCancel.Size = new System.Drawing.Size(245, 64);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Đã hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFeedback
            // 
            this.btnFeedback.BorderRadius = 20;
            this.btnFeedback.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFeedback.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFeedback.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFeedback.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFeedback.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(60)))), ((int)(((byte)(20)))));
            this.btnFeedback.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedback.ForeColor = System.Drawing.Color.White;
            this.btnFeedback.Location = new System.Drawing.Point(1051, 3);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.PressedDepth = 25;
            this.btnFeedback.Size = new System.Drawing.Size(248, 64);
            this.btnFeedback.TabIndex = 3;
            this.btnFeedback.Text = "Đánh giá";
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // pbBack
            // 
            this.pbBack.Image = global::Restaurant_Management_System.Properties.Resources.back_button;
            this.pbBack.ImageRotate = 0F;
            this.pbBack.Location = new System.Drawing.Point(39, 844);
            this.pbBack.Margin = new System.Windows.Forms.Padding(4);
            this.pbBack.Name = "pbBack";
            this.pbBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbBack.Size = new System.Drawing.Size(47, 33);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 24;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1378, 56);
            this.guna2Panel1.TabIndex = 25;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(540, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(544, 39);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "THÔNG TIN ĐƠN HÀNG";
            // 
            // frmInfoOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1378, 901);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInfoOrder";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInfoOrder";
            this.Load += new System.EventHandler(this.frmInfoOrder_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnReceived;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button btnWaitConfirm;
        private Guna.UI2.WinForms.Guna2Button btnConfirmed;
        private Guna.UI2.WinForms.Guna2Button btnFeedback;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbBack;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}