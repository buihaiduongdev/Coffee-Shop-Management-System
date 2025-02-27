namespace Restaurant_Management_System.Barista
{
    partial class frmKitchen
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
            this.flpOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.tnPending = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnProcessing = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnCompleted = new Guna.UI2.WinForms.Guna2TileButton();
            this.SuspendLayout();
            // 
            // flpOrders
            // 
            this.flpOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpOrders.Location = new System.Drawing.Point(9, 64);
            this.flpOrders.Name = "flpOrders";
            this.flpOrders.Size = new System.Drawing.Size(825, 385);
            this.flpOrders.TabIndex = 3;
            // 
            // tnPending
            // 
            this.tnPending.BackColor = System.Drawing.Color.White;
            this.tnPending.BorderColor = System.Drawing.Color.Teal;
            this.tnPending.BorderRadius = 10;
            this.tnPending.BorderThickness = 2;
            this.tnPending.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.tnPending.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.tnPending.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.tnPending.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tnPending.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tnPending.FillColor = System.Drawing.Color.Teal;
            this.tnPending.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tnPending.ForeColor = System.Drawing.Color.White;
            this.tnPending.Location = new System.Drawing.Point(9, 12);
            this.tnPending.Name = "tnPending";
            this.tnPending.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tnPending.Size = new System.Drawing.Size(138, 46);
            this.tnPending.TabIndex = 11;
            this.tnPending.Text = "Pending";
            this.tnPending.Click += new System.EventHandler(this.tnPending_Click);
            // 
            // btnProcessing
            // 
            this.btnProcessing.BackColor = System.Drawing.Color.White;
            this.btnProcessing.BorderColor = System.Drawing.Color.Teal;
            this.btnProcessing.BorderRadius = 10;
            this.btnProcessing.BorderThickness = 2;
            this.btnProcessing.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnProcessing.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProcessing.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProcessing.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProcessing.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProcessing.FillColor = System.Drawing.Color.Teal;
            this.btnProcessing.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProcessing.ForeColor = System.Drawing.Color.White;
            this.btnProcessing.Location = new System.Drawing.Point(153, 12);
            this.btnProcessing.Name = "btnProcessing";
            this.btnProcessing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnProcessing.Size = new System.Drawing.Size(138, 46);
            this.btnProcessing.TabIndex = 12;
            this.btnProcessing.Text = "Processing";
            this.btnProcessing.Click += new System.EventHandler(this.btnProcessing_Click);
            // 
            // btnCompleted
            // 
            this.btnCompleted.BackColor = System.Drawing.Color.White;
            this.btnCompleted.BorderColor = System.Drawing.Color.Teal;
            this.btnCompleted.BorderRadius = 10;
            this.btnCompleted.BorderThickness = 2;
            this.btnCompleted.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnCompleted.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCompleted.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCompleted.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCompleted.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCompleted.FillColor = System.Drawing.Color.Teal;
            this.btnCompleted.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCompleted.ForeColor = System.Drawing.Color.White;
            this.btnCompleted.Location = new System.Drawing.Point(297, 12);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCompleted.Size = new System.Drawing.Size(138, 46);
            this.btnCompleted.TabIndex = 13;
            this.btnCompleted.Text = "Completed";
            this.btnCompleted.Click += new System.EventHandler(this.btnCompleted_Click);
            // 
            // frmKitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 504);
            this.Controls.Add(this.btnCompleted);
            this.Controls.Add(this.btnProcessing);
            this.Controls.Add(this.tnPending);
            this.Controls.Add(this.flpOrders);
            this.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmKitchen";
            this.Text = "frmKitchen";
            this.Load += new System.EventHandler(this.frmKitchen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpOrders;
        private Guna.UI2.WinForms.Guna2TileButton tnPending;
        private Guna.UI2.WinForms.Guna2TileButton btnProcessing;
        private Guna.UI2.WinForms.Guna2TileButton btnCompleted;
    }
}