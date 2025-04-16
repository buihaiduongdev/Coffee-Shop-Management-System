namespace Restaurant_Management_System.CustomerModel
{
    partial class ucDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOrderID = new System.Windows.Forms.Label();
            this.pbBack = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.flpOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.ucItemOrder1 = new Restaurant_Management_System.CustomerModel.ucItemOrder();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.flpOrderItems.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOrderID
            // 
            this.lblOrderID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.lblOrderID.Location = new System.Drawing.Point(550, 14);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(267, 32);
            this.lblOrderID.TabIndex = 19;
            this.lblOrderID.Text = "MÃ ĐƠN HÀNG";
            this.lblOrderID.Click += new System.EventHandler(this.lblOrderID_Click);
            // 
            // pbBack
            // 
            this.pbBack.Image = global::Restaurant_Management_System.Properties.Resources.back_button;
            this.pbBack.ImageRotate = 0F;
            this.pbBack.Location = new System.Drawing.Point(3, 812);
            this.pbBack.Margin = new System.Windows.Forms.Padding(4);
            this.pbBack.Name = "pbBack";
            this.pbBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbBack.Size = new System.Drawing.Size(58, 39);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 23;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // flpOrderItems
            // 
            this.flpOrderItems.Controls.Add(this.ucItemOrder1);
            this.flpOrderItems.Location = new System.Drawing.Point(3, 58);
            this.flpOrderItems.Name = "flpOrderItems";
            this.flpOrderItems.Size = new System.Drawing.Size(1337, 747);
            this.flpOrderItems.TabIndex = 28;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.guna2Panel2.BorderColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderRadius = 35;
            this.guna2Panel2.Controls.Add(this.flpOrderItems);
            this.guna2Panel2.Controls.Add(this.pbBack);
            this.guna2Panel2.Controls.Add(this.lblOrderID);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1318, 866);
            this.guna2Panel2.TabIndex = 30;
            // 
            // ucItemOrder1
            // 
            this.ucItemOrder1.Location = new System.Drawing.Point(3, 3);
            this.ucItemOrder1.Name = "ucItemOrder1";
            this.ucItemOrder1.Size = new System.Drawing.Size(505, 268);
            this.ucItemOrder1.TabIndex = 0;
            // 
            // ucDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel2);
            this.Name = "ucDetail";
            this.Size = new System.Drawing.Size(1318, 866);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.flpOrderItems.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOrderID;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbBack;
        private System.Windows.Forms.FlowLayoutPanel flpOrderItems;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private ucItemOrder ucItemOrder1;
    }
}
