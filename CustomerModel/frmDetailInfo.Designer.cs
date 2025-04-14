namespace Restaurant_Management_System.CustomerModel
{
    partial class frmDetailInfo
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ucDetail1 = new Restaurant_Management_System.CustomerModel.ucDetail();
            this.pbBack = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.pbBack);
            this.guna2Panel1.Controls.Add(this.ucDetail1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1262, 799);
            this.guna2Panel1.TabIndex = 29;
            // 
            // ucDetail1
            // 
            this.ucDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucDetail1.Name = "ucDetail1";
            this.ucDetail1.Size = new System.Drawing.Size(1262, 799);
            this.ucDetail1.TabIndex = 0;
            // 
            // pbBack
            // 
            this.pbBack.Image = global::Restaurant_Management_System.Properties.Resources.back_button;
            this.pbBack.ImageRotate = 0F;
            this.pbBack.Location = new System.Drawing.Point(13, 700);
            this.pbBack.Margin = new System.Windows.Forms.Padding(4);
            this.pbBack.Name = "pbBack";
            this.pbBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbBack.Size = new System.Drawing.Size(47, 33);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 22;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // frmDetailInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 759);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDetailInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetailInfo";
            this.Load += new System.EventHandler(this.frmDetailInfo_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private ucDetail ucDetail1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbBack;
    }
}