namespace DOAN_WF.GUI
{
    partial class frm_suco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_suco));
            this.pnl_tieude = new System.Windows.Forms.Panel();
            this.lbl_tieude = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.lbl_tungay = new System.Windows.Forms.Label();
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.lbl_denngay = new System.Windows.Forms.Label();
            this.cmb_trangthai = new System.Windows.Forms.ComboBox();
            this.lbl_trangthai = new System.Windows.Forms.Label();
            this.pnl_button = new System.Windows.Forms.Panel();
            this.pnl_right = new System.Windows.Forms.Panel();
            this.dgv_thongtinsuco = new System.Windows.Forms.DataGridView();
            this.pnl_tieude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_button.SuspendLayout();
            this.pnl_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtinsuco)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_tieude
            // 
            this.pnl_tieude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.pnl_tieude.Controls.Add(this.lbl_tieude);
            this.pnl_tieude.Controls.Add(this.pictureBox1);
            this.pnl_tieude.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_tieude.Location = new System.Drawing.Point(0, 0);
            this.pnl_tieude.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnl_tieude.Name = "pnl_tieude";
            this.pnl_tieude.Size = new System.Drawing.Size(1587, 57);
            this.pnl_tieude.TabIndex = 0;
            // 
            // lbl_tieude
            // 
            this.lbl_tieude.AutoSize = true;
            this.lbl_tieude.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_tieude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lbl_tieude.Location = new System.Drawing.Point(101, 13);
            this.lbl_tieude.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_tieude.Name = "lbl_tieude";
            this.lbl_tieude.Size = new System.Drawing.Size(198, 32);
            this.lbl_tieude.TabIndex = 1;
            this.lbl_tieude.Text = "Báo Cáo Sự Cố";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_tungay.Location = new System.Drawing.Point(126, 17);
            this.dtp_tungay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(334, 30);
            this.dtp_tungay.TabIndex = 1;
            // 
            // lbl_tungay
            // 
            this.lbl_tungay.AutoSize = true;
            this.lbl_tungay.Location = new System.Drawing.Point(31, 23);
            this.lbl_tungay.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_tungay.Name = "lbl_tungay";
            this.lbl_tungay.Size = new System.Drawing.Size(85, 22);
            this.lbl_tungay.TabIndex = 0;
            this.lbl_tungay.Text = "Từ Ngày:";
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_denngay.Location = new System.Drawing.Point(602, 17);
            this.dtp_denngay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(312, 30);
            this.dtp_denngay.TabIndex = 3;
            // 
            // lbl_denngay
            // 
            this.lbl_denngay.AutoSize = true;
            this.lbl_denngay.Location = new System.Drawing.Point(507, 23);
            this.lbl_denngay.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_denngay.Name = "lbl_denngay";
            this.lbl_denngay.Size = new System.Drawing.Size(94, 22);
            this.lbl_denngay.TabIndex = 2;
            this.lbl_denngay.Text = "Đến Ngày:";
            // 
            // cmb_trangthai
            // 
            this.cmb_trangthai.FormattingEnabled = true;
            this.cmb_trangthai.Location = new System.Drawing.Point(154, 72);
            this.cmb_trangthai.Name = "cmb_trangthai";
            this.cmb_trangthai.Size = new System.Drawing.Size(173, 30);
            this.cmb_trangthai.TabIndex = 4;
            this.cmb_trangthai.SelectedIndexChanged += new System.EventHandler(this.cmb_trangthai_SelectedIndexChanged);
            // 
            // lbl_trangthai
            // 
            this.lbl_trangthai.AutoSize = true;
            this.lbl_trangthai.Location = new System.Drawing.Point(31, 82);
            this.lbl_trangthai.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_trangthai.Name = "lbl_trangthai";
            this.lbl_trangthai.Size = new System.Drawing.Size(102, 22);
            this.lbl_trangthai.TabIndex = 5;
            this.lbl_trangthai.Text = "Trạng Thái:";
            // 
            // pnl_button
            // 
            this.pnl_button.Controls.Add(this.lbl_trangthai);
            this.pnl_button.Controls.Add(this.cmb_trangthai);
            this.pnl_button.Controls.Add(this.lbl_denngay);
            this.pnl_button.Controls.Add(this.dtp_denngay);
            this.pnl_button.Controls.Add(this.lbl_tungay);
            this.pnl_button.Controls.Add(this.dtp_tungay);
            this.pnl_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_button.Location = new System.Drawing.Point(0, 57);
            this.pnl_button.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnl_button.Name = "pnl_button";
            this.pnl_button.Size = new System.Drawing.Size(1587, 136);
            this.pnl_button.TabIndex = 2;
            // 
            // pnl_right
            // 
            this.pnl_right.Controls.Add(this.dgv_thongtinsuco);
            this.pnl_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_right.Location = new System.Drawing.Point(0, 193);
            this.pnl_right.Name = "pnl_right";
            this.pnl_right.Size = new System.Drawing.Size(1587, 490);
            this.pnl_right.TabIndex = 4;
            // 
            // dgv_thongtinsuco
            // 
            this.dgv_thongtinsuco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thongtinsuco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_thongtinsuco.Location = new System.Drawing.Point(0, 0);
            this.dgv_thongtinsuco.Name = "dgv_thongtinsuco";
            this.dgv_thongtinsuco.RowHeadersWidth = 51;
            this.dgv_thongtinsuco.RowTemplate.Height = 24;
            this.dgv_thongtinsuco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_thongtinsuco.Size = new System.Drawing.Size(1587, 490);
            this.dgv_thongtinsuco.TabIndex = 0;
            this.dgv_thongtinsuco.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_thongtinsuco_CellContentClick);
            this.dgv_thongtinsuco.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_thongtinsuco_CellEndEdit);
            // 
            // frm_suco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 683);
            this.Controls.Add(this.pnl_right);
            this.Controls.Add(this.pnl_button);
            this.Controls.Add(this.pnl_tieude);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frm_suco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_suco_Load);
            this.pnl_tieude.ResumeLayout(false);
            this.pnl_tieude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_button.ResumeLayout(false);
            this.pnl_button.PerformLayout();
            this.pnl_right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtinsuco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_tieude;
        private System.Windows.Forms.Label lbl_tieude;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        private System.Windows.Forms.Label lbl_tungay;
        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.Label lbl_denngay;
        private System.Windows.Forms.ComboBox cmb_trangthai;
        private System.Windows.Forms.Label lbl_trangthai;
        private System.Windows.Forms.Panel pnl_button;
        private System.Windows.Forms.Panel pnl_right;
        private System.Windows.Forms.DataGridView dgv_thongtinsuco;
    }
}