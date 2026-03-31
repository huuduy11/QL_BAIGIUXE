namespace DoAn_demo
{
    partial class frm_baocao
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
                this.rpt_baocao = new Microsoft.Reporting.WinForms.ReportViewer();
                this.SuspendLayout();
                // 
                // rpt_baocao
                // 
                this.rpt_baocao.Dock = System.Windows.Forms.DockStyle.Fill;
                this.rpt_baocao.Location = new System.Drawing.Point(0, 0);
                this.rpt_baocao.Name = "rpt_baocao";
                //this.rpt_baocao.ServerReport.BearerToken = null;
                this.rpt_baocao.Size = new System.Drawing.Size(1158, 602);
                this.rpt_baocao.TabIndex = 0;
                // 
                // frm_baocao
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(1158, 602);
                this.Controls.Add(this.rpt_baocao);
                this.Name = "frm_baocao";
                this.Text = "Báo cáo";
                this.Load += new System.EventHandler(this.BAOCAO_Load);
                this.ResumeLayout(false);

            }

            #endregion

        public Microsoft.Reporting.WinForms.ReportViewer rpt_baocao;
    }
}