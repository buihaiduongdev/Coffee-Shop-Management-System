namespace Restaurant_Management_System.Model
{
    partial class ucProduct
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProductPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProductName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ShadowPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImage)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.panel1);
            this.guna2ShadowPanel1.Controls.Add(this.txtImage);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Font = new System.Drawing.Font("Onest", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(258, 259);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.lblProductPrice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Onest", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 77);
            this.panel1.TabIndex = 1;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblProductPrice.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(173)))), ((int)(((byte)(105)))));
            this.lblProductPrice.Location = new System.Drawing.Point(166, 3);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(31, 25);
            this.lblProductPrice.TabIndex = 4;
            this.lblProductPrice.Text = "Giá";
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(31, 3);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(35, 25);
            this.lblProductName.TabIndex = 5;
            this.lblProductName.Text = "Tên";
            // 
            // txtImage
            // 
            this.txtImage.BackColor = System.Drawing.Color.Transparent;
            this.txtImage.Image = global::Restaurant_Management_System.Properties.Resources.store;
            this.txtImage.ImageRotate = 0F;
            this.txtImage.Location = new System.Drawing.Point(31, 6);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(176, 170);
            this.txtImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.txtImage.TabIndex = 0;
            this.txtImage.TabStop = false;
            this.txtImage.UseTransparentBackground = true;
            this.txtImage.Click += new System.EventHandler(this.txtImage_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Gray;
            this.guna2Button1.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(21, 37);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(215, 32);
            this.guna2Button1.TabIndex = 6;
            this.guna2Button1.Text = "Thêm vào giỏ hàng";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ucProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(258, 259);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox txtImage;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProductName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProductPrice;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
