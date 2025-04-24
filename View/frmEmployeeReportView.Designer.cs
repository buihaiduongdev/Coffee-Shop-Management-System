namespace Restaurant_Management_System.View
{
    partial class frmEmployeeReportView
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
            this.rpvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rpvReport
            // 
            this.rpvReport.ActiveViewIndex = -1;
            this.rpvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rpvReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.rpvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvReport.Location = new System.Drawing.Point(0, 0);
            this.rpvReport.Name = "rpvReport";
            this.rpvReport.Size = new System.Drawing.Size(1102, 854);
            this.rpvReport.TabIndex = 0;
            this.rpvReport.Load += new System.EventHandler(this.rpvReport_Load);
            // 
            // frmEmployeeReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 854);
            this.Controls.Add(this.rpvReport);
            this.Name = "frmEmployeeReportView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeeReportView";
            this.Load += new System.EventHandler(this.frmEmployeeReportView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rpvReport;
    }
}