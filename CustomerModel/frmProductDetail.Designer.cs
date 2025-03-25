namespace Restaurant_Management_System.Customer
{
    partial class frmProductDetail
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
            this.ucProductDetail1 = new Restaurant_Management_System.Model.ucProductDetail();
            this.SuspendLayout();
            // 
            // ucProductDetail1
            // 
            this.ucProductDetail1.category = null;
            this.ucProductDetail1.id = 0;
            this.ucProductDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucProductDetail1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucProductDetail1.Name = "ucProductDetail1";
            this.ucProductDetail1.PIce = "50%";
            this.ucProductDetail1.PImage = null;
            this.ucProductDetail1.PName = "Tên";
            this.ucProductDetail1.PPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucProductDetail1.PSize = "M";
            this.ucProductDetail1.PSugar = "50%";
            this.ucProductDetail1.Size = new System.Drawing.Size(611, 634);
            this.ucProductDetail1.TabIndex = 0;
            // 
            // frmProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 634);
            this.Controls.Add(this.ucProductDetail1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmProductDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductDetail";
            this.ResumeLayout(false);

        }

        #endregion

        private Model.ucProductDetail ucProductDetail1;
    }
}