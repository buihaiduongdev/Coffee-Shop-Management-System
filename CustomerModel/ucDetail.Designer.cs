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
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.flpOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.ucItemOrder1 = new Restaurant_Management_System.CustomerModel.ucItemOrder();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.guna2Panel2.SuspendLayout();
            this.flpOrderItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.guna2Panel2.BorderColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderRadius = 35;
            this.guna2Panel2.Controls.Add(this.flpOrderItems);
            this.guna2Panel2.Controls.Add(this.lblOrderID);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1237, 778);
            this.guna2Panel2.TabIndex = 30;
            // 
            // flpOrderItems
            // 
            this.flpOrderItems.Controls.Add(this.ucItemOrder1);
            this.flpOrderItems.Location = new System.Drawing.Point(3, 58);
            this.flpOrderItems.Name = "flpOrderItems";
            this.flpOrderItems.Size = new System.Drawing.Size(1234, 668);
            this.flpOrderItems.TabIndex = 28;
            // 
            // ucItemOrder1
            // 
            this.ucItemOrder1.Location = new System.Drawing.Point(3, 3);
            this.ucItemOrder1.Name = "ucItemOrder1";
            this.ucItemOrder1.Size = new System.Drawing.Size(465, 292);
            this.ucItemOrder1.TabIndex = 0;
            // 
            // lblOrderID
            // 
            this.lblOrderID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.lblOrderID.Location = new System.Drawing.Point(183, 12);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(264, 43);
            this.lblOrderID.TabIndex = 19;
            this.lblOrderID.Text = "Chi tiết đơn hàng";
            // 
            // ucDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel2);
            this.Name = "ucDetail";
            this.Size = new System.Drawing.Size(1237, 778);
            this.guna2Panel2.ResumeLayout(false);
            this.flpOrderItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.FlowLayoutPanel flpOrderItems;
        private ucItemOrder ucItemOrder1;
    }
}
