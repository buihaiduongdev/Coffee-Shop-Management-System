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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlProduct = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.pbImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddToCart = new Guna.UI2.WinForms.Guna2Button();
            this.lblProductName2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblProductPrice2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlProduct
            // 
            this.pnlProduct.BackColor = System.Drawing.Color.Transparent;
            this.pnlProduct.Controls.Add(this.pbImage);
            this.pnlProduct.Controls.Add(this.panel2);
            this.pnlProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProduct.Location = new System.Drawing.Point(0, 0);
            this.pnlProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(410, 409);
            this.pnlProduct.TabIndex = 2;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.Image = global::Restaurant_Management_System.Properties.Resources.store;
            this.pbImage.ImageRotate = 0F;
            this.pbImage.Location = new System.Drawing.Point(59, 0);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(280, 280);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 3;
            this.pbImage.TabStop = false;
            this.pbImage.UseTransparentBackground = true;
            this.pbImage.MouseEnter += new System.EventHandler(this.pbImage_MouseEnter);
            this.pbImage.MouseLeave += new System.EventHandler(this.pbImage_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddToCart);
            this.panel2.Controls.Add(this.lblProductName2);
            this.panel2.Controls.Add(this.lblProductPrice2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Onest", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 281);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 128);
            this.panel2.TabIndex = 2;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BorderRadius = 17;
            this.btnAddToCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddToCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddToCart.FillColor = System.Drawing.Color.Silver;
            this.btnAddToCart.FocusedColor = System.Drawing.Color.Lime;
            this.btnAddToCart.Font = new System.Drawing.Font("Sitka Banner", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(55, 69);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(295, 43);
            this.btnAddToCart.TabIndex = 6;
            this.btnAddToCart.Text = "Thêm vào giỏ hàng";
            this.btnAddToCart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAddToCart_MouseDown);
            this.btnAddToCart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAddToCart_MouseUp);
            // 
            // lblProductName2
            // 
            this.lblProductName2.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName2.Font = new System.Drawing.Font("Sitka Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName2.Location = new System.Drawing.Point(39, 16);
            this.lblProductName2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblProductName2.Name = "lblProductName2";
            this.lblProductName2.Size = new System.Drawing.Size(44, 38);
            this.lblProductName2.TabIndex = 5;
            this.lblProductName2.Text = "Tên";
            // 
            // lblProductPrice2
            // 
            this.lblProductPrice2.BackColor = System.Drawing.Color.Transparent;
            this.lblProductPrice2.Font = new System.Drawing.Font("Sitka Banner", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(188)))), ((int)(((byte)(122)))));
            this.lblProductPrice2.Location = new System.Drawing.Point(325, 16);
            this.lblProductPrice2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblProductPrice2.Name = "lblProductPrice2";
            this.lblProductPrice2.Size = new System.Drawing.Size(38, 38);
            this.lblProductPrice2.TabIndex = 4;
            this.lblProductPrice2.Text = "Giá";
            this.lblProductPrice2.Click += new System.EventHandler(this.lblProductPrice2_Click);
            // 
            // ucProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlProduct);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(410, 409);
            this.pnlProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlProduct;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnAddToCart;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProductName2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProductPrice2;
        private Guna.UI2.WinForms.Guna2PictureBox pbImage;
    }
}
