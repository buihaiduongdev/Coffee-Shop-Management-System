namespace Restaurant_Management_System.Barista
{
    partial class ucKitchen
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
            this.components = new System.ComponentModel.Container();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnAction = new Guna.UI2.WinForms.Guna2Button();
            this.lblWaitingTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProductName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtImageStatus = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImageStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.btnAction);
            this.guna2ShadowPanel1.Controls.Add(this.lblWaitingTime);
            this.guna2ShadowPanel1.Controls.Add(this.lblStatus);
            this.guna2ShadowPanel1.Controls.Add(this.lblProductName);
            this.guna2ShadowPanel1.Controls.Add(this.txtImageStatus);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(150, 200);
            this.guna2ShadowPanel1.TabIndex = 4;
            // 
            // btnAction
            // 
            this.btnAction.BorderRadius = 20;
            this.btnAction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAction.FillColor = System.Drawing.Color.Gray;
            this.btnAction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(13, 153);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(126, 30);
            this.btnAction.TabIndex = 6;
            this.btnAction.Text = "Take";
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click_1);
            // 
            // lblWaitingTime
            // 
            this.lblWaitingTime.BackColor = System.Drawing.Color.Transparent;
            this.lblWaitingTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingTime.Location = new System.Drawing.Point(13, 110);
            this.lblWaitingTime.Name = "lblWaitingTime";
            this.lblWaitingTime.Size = new System.Drawing.Size(95, 23);
            this.lblWaitingTime.TabIndex = 7;
            this.lblWaitingTime.Text = "Waiting Time";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(13, 81);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 23);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status";
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(173)))), ((int)(((byte)(105)))));
            this.lblProductName.Location = new System.Drawing.Point(15, 48);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(55, 27);
            this.lblProductName.TabIndex = 4;
            this.lblProductName.Text = "Name";
            // 
            // txtImageStatus
            // 
            this.txtImageStatus.BackColor = System.Drawing.Color.Transparent;
            this.txtImageStatus.Image = global::Restaurant_Management_System.Properties.Resources.store;
            this.txtImageStatus.ImageRotate = 0F;
            this.txtImageStatus.Location = new System.Drawing.Point(15, 12);
            this.txtImageStatus.Name = "txtImageStatus";
            this.txtImageStatus.Size = new System.Drawing.Size(34, 30);
            this.txtImageStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.txtImageStatus.TabIndex = 0;
            this.txtImageStatus.TabStop = false;
            this.txtImageStatus.UseTransparentBackground = true;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ucKitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "ucKitchen";
            this.Size = new System.Drawing.Size(150, 200);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImageStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWaitingTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2Button btnAction;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProductName;
        private Guna.UI2.WinForms.Guna2PictureBox txtImageStatus;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
