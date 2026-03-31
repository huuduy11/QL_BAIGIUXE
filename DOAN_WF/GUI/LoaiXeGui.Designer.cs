namespace DOAN_WF.GUI
{
    partial class LoaiXeGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoaiXeGui));
            this.dgv_loaixe = new System.Windows.Forms.DataGridView();
            this.MaLoaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhomXe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_quanlyxethang = new System.Windows.Forms.Panel();
            this.lbl_quanlyxethang = new System.Windows.Forms.Label();
            this.ptb_icon = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_taomoi = new System.Windows.Forms.Button();
            this.btn_dieuchinh = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_loaixe)).BeginInit();
            this.pnl_quanlyxethang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_icon)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_loaixe
            // 
            this.dgv_loaixe.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_loaixe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_loaixe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiXe,
            this.TenLoaiXe,
            this.NhomXe});
            this.dgv_loaixe.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_loaixe.Location = new System.Drawing.Point(0, 111);
            this.dgv_loaixe.Name = "dgv_loaixe";
            this.dgv_loaixe.RowHeadersWidth = 51;
            this.dgv_loaixe.Size = new System.Drawing.Size(1165, 552);
            this.dgv_loaixe.TabIndex = 9;
            this.dgv_loaixe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_loaixe_CellContentClick);
            // 
            // MaLoaiXe
            // 
            this.MaLoaiXe.DataPropertyName = "MaLoaiXe";
            this.MaLoaiXe.HeaderText = "Mã Loại Xe";
            this.MaLoaiXe.MinimumWidth = 6;
            this.MaLoaiXe.Name = "MaLoaiXe";
            this.MaLoaiXe.Width = 125;
            // 
            // TenLoaiXe
            // 
            this.TenLoaiXe.DataPropertyName = "TenLoaiXe";
            this.TenLoaiXe.HeaderText = "Tên Loại Xe";
            this.TenLoaiXe.MinimumWidth = 6;
            this.TenLoaiXe.Name = "TenLoaiXe";
            this.TenLoaiXe.Width = 125;
            // 
            // NhomXe
            // 
            this.NhomXe.DataPropertyName = "NhomXe";
            this.NhomXe.HeaderText = "Nhóm Xe";
            this.NhomXe.MinimumWidth = 6;
            this.NhomXe.Name = "NhomXe";
            this.NhomXe.Width = 125;
            // 
            // pnl_quanlyxethang
            // 
            this.pnl_quanlyxethang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.pnl_quanlyxethang.Controls.Add(this.lbl_quanlyxethang);
            this.pnl_quanlyxethang.Controls.Add(this.ptb_icon);
            this.pnl_quanlyxethang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_quanlyxethang.Location = new System.Drawing.Point(0, 0);
            this.pnl_quanlyxethang.Name = "pnl_quanlyxethang";
            this.pnl_quanlyxethang.Size = new System.Drawing.Size(1165, 34);
            this.pnl_quanlyxethang.TabIndex = 10;
            // 
            // lbl_quanlyxethang
            // 
            this.lbl_quanlyxethang.AutoSize = true;
            this.lbl_quanlyxethang.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_quanlyxethang.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_quanlyxethang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lbl_quanlyxethang.Location = new System.Drawing.Point(57, 0);
            this.lbl_quanlyxethang.Name = "lbl_quanlyxethang";
            this.lbl_quanlyxethang.Size = new System.Drawing.Size(242, 32);
            this.lbl_quanlyxethang.TabIndex = 1;
            this.lbl_quanlyxethang.Text = "Danh Mục Loại Xe";
            this.lbl_quanlyxethang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptb_icon
            // 
            this.ptb_icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptb_icon.Image = ((System.Drawing.Image)(resources.GetObject("ptb_icon.Image")));
            this.ptb_icon.Location = new System.Drawing.Point(0, 0);
            this.ptb_icon.Name = "ptb_icon";
            this.ptb_icon.Size = new System.Drawing.Size(57, 34);
            this.ptb_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_icon.TabIndex = 0;
            this.ptb_icon.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btn_taomoi);
            this.flowLayoutPanel2.Controls.Add(this.btn_dieuchinh);
            this.flowLayoutPanel2.Controls.Add(this.btn_xoa);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 34);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1165, 71);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // btn_taomoi
            // 
            this.btn_taomoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.btn_taomoi.FlatAppearance.BorderSize = 0;
            this.btn_taomoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_taomoi.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_taomoi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_taomoi.Image = ((System.Drawing.Image)(resources.GetObject("btn_taomoi.Image")));
            this.btn_taomoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_taomoi.Location = new System.Drawing.Point(3, 3);
            this.btn_taomoi.Name = "btn_taomoi";
            this.btn_taomoi.Size = new System.Drawing.Size(163, 54);
            this.btn_taomoi.TabIndex = 0;
            this.btn_taomoi.Text = "Tạo Mới";
            this.btn_taomoi.UseVisualStyleBackColor = false;
            this.btn_taomoi.Click += new System.EventHandler(this.btn_taomoi_Click);
            // 
            // btn_dieuchinh
            // 
            this.btn_dieuchinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.btn_dieuchinh.FlatAppearance.BorderSize = 0;
            this.btn_dieuchinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dieuchinh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_dieuchinh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_dieuchinh.Image = ((System.Drawing.Image)(resources.GetObject("btn_dieuchinh.Image")));
            this.btn_dieuchinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dieuchinh.Location = new System.Drawing.Point(172, 3);
            this.btn_dieuchinh.Name = "btn_dieuchinh";
            this.btn_dieuchinh.Size = new System.Drawing.Size(183, 54);
            this.btn_dieuchinh.TabIndex = 1;
            this.btn_dieuchinh.Text = "Điều Chỉnh";
            this.btn_dieuchinh.UseVisualStyleBackColor = false;
            this.btn_dieuchinh.Click += new System.EventHandler(this.btn_dieuchinh_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.btn_xoa.FlatAppearance.BorderSize = 0;
            this.btn_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_xoa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_xoa.Image")));
            this.btn_xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xoa.Location = new System.Drawing.Point(361, 3);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(127, 54);
            this.btn_xoa.TabIndex = 2;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // LoaiXeGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 666);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.pnl_quanlyxethang);
            this.Controls.Add(this.dgv_loaixe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoaiXeGui";
            this.Text = "LoaiXeGui";
            this.Load += new System.EventHandler(this.LoaiXeGui_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_loaixe)).EndInit();
            this.pnl_quanlyxethang.ResumeLayout(false);
            this.pnl_quanlyxethang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_icon)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_loaixe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhomXe;
        private System.Windows.Forms.Panel pnl_quanlyxethang;
        private System.Windows.Forms.Label lbl_quanlyxethang;
        private System.Windows.Forms.PictureBox ptb_icon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btn_taomoi;
        private System.Windows.Forms.Button btn_dieuchinh;
        private System.Windows.Forms.Button btn_xoa;
    }
}